using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace ManagementSystem.Common.Models
{
    public static class GenericSearchRepository<TEntity> where TEntity : class
    {

        public static async Task<(List<TEntity>, int)> ExecutePagedStoredProcedureCommonAsync<TEntity>(
            DbContext dbContext,
            string storedProcedureName,
            int pageNumber,
            int pageSize,
            SqlParameter[] parameters)
        {

            using var connection = dbContext.Database.GetDbConnection() as SqlConnection;
            await connection.OpenAsync();

            using var command = new SqlCommand(storedProcedureName, connection);
            command.CommandType = CommandType.StoredProcedure;

            // Input parameters
            command.Parameters.AddWithValue("@pageNumber", pageNumber);
            command.Parameters.AddWithValue("@pageSize", pageSize);

            if (parameters != null)
            {
                command.Parameters.AddRange(parameters);
            }

            // Output parameter for total records
            var totalRecordsParam = new SqlParameter("@TotalRecords", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(totalRecordsParam);

            using var adapter = new SqlDataAdapter(command);
            var dataTable = new DataTable();
            adapter.Fill(dataTable);

            // Retrieve the total records from the output parameter
            int totalRecords = (int)totalRecordsParam.Value;

            // Optionally, you can map the DataTable to a list of TEntity using a mapping library like Dapper
            List<TEntity> pagedData = MapDataTableToEntities<TEntity>(dataTable);

            return (pagedData, totalRecords);
        }

        private static List<TEntity> MapDataTableToEntities<TEntity>(DataTable dataTable)
        {
            var entities = new List<TEntity>();

            try
            {
                var columnNames = dataTable.Columns.Cast<DataColumn>().Select(c => c.ColumnName).ToList();

                foreach (DataRow row in dataTable.Rows)
                {
                    var entity = Activator.CreateInstance<TEntity>();

                    foreach (var columnName in columnNames)
                    {
                        var property = typeof(TEntity).GetProperty(columnName);

                        if (property != null)
                        {
                            if (row[columnName] != DBNull.Value)
                            {
                                // Check if the property type is nullable (e.g., int?)
                                var isNullable = property.PropertyType.IsGenericType &&
                                                property.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>);

                                // Get the underlying type of the property
                                var propertyType = isNullable ? Nullable.GetUnderlyingType(property.PropertyType) : property.PropertyType;

                                // Convert the value to the property's type
                                var safeValue = Convert.ChangeType(row[columnName], propertyType);

                                // Set the property value
                                property.SetValue(entity, safeValue);
                            }
                            else
                            {
                                // Handle NULL values by setting the property to its default value
                                property.SetValue(entity, null);
                            }
                        }
                    }

                    entities.Add(entity);
                }

                return entities;
            }
            catch (Exception ex)
            {
                // Handle or log the exception as needed
                throw ex;
            }
        }
    }
}
