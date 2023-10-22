using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagementSystem.StoragesApi.Migrations
{
    public partial class AddSearchBillStore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
				CREATE OR ALTER  PROCEDURE [dbo].[sp_SearchBills]
					@xmlString NVARCHAR(MAX)
					,@pageNumber INT = 1
					,@pageSize INT = 10
				AS
				BEGIN
					DECLARE @sqlQuery VARCHAR(MAX)
							,@sqlQuery_condition VARCHAR(MAX)
							,@pagingString VARCHAR(MAX)
							,@orderBy VARCHAR(MAX)

					DECLARE @xml XML
					SET @xml = CAST(@xmlString AS XML)

					-- Create a table variable to store the parsed values
					DECLARE @SearchCriteriaTable TABLE
					(
						[Key] NVARCHAR(255),
						[Value] NVARCHAR(255)
					)

					-- Insert the values from XML into the table variable
					INSERT INTO @SearchCriteriaTable ([Key], [Value])
					SELECT
						Criteria.value('(Key)[1]', 'NVARCHAR(255)') AS [Key],
						Criteria.value('(Value)[1]', 'NVARCHAR(255)') AS [Value]
					FROM @xml.nodes('/SearchCriteria/Criteria') AS SearchCriteria(Criteria)

					-- Map to create dynamic condition
					DROP TABLE IF EXISTS #web_column_mapping
					CREATE TABLE #web_column_mapping
					(
						WEB_COLUMN VARCHAR(128)
						,DB_COLUMN_ALIAS VARCHAR(MAX)
						,DB_COLUMN_OPERATION VARCHAR(8) DEFAULT ' = '
					)

					INSERT INTO #web_column_mapping VALUES('FromDate', 'FORMAT(b.CreateDate, ''yyyy-MM-dd'')', '>=')
					INSERT INTO #web_column_mapping VALUES('ToDate', 'FORMAT(b.CreateDate, ''yyyy-MM-dd'')', '<=')

					SELECT @sqlQuery_condition = CONCAT(@sqlQuery_condition,+ ' AND '
										+ col_map.DB_COLUMN_ALIAS
										+ col_map.DB_COLUMN_OPERATION
										+ '''' + xml_parsed.[Value] + ''''
										+ (CHAR(10)) )
					FROM @SearchCriteriaTable xml_parsed
					JOIN #web_column_mapping col_map ON xml_parsed.[Key] = col_map.WEB_COLUMN
					WHERE xml_parsed.[Key] NOT IN ('CustomerName', 'BillId')


					IF EXISTS (SELECT 1 FROM @SearchCriteriaTable WHERE [Key] = 'CustomerName')
					BEGIN
						SELECT @sqlQuery_condition = CONCAT (@sqlQuery_condition, ' AND ',
							'c.CustomerName LIKE N'''+'%' +xml_parsed.[Value]+ '%' + '''')
						FROM @SearchCriteriaTable xml_parsed
						WHERE xml_parsed.[Key] = 'CustomerName'
					END


					IF EXISTS (SELECT 1 FROM @SearchCriteriaTable WHERE [Key] = 'BillId')
					BEGIN
						SELECT @sqlQuery_condition = CONCAT (@sqlQuery_condition, ' AND ',
							'CONVERT(VARCHAR(12), b.BillId) LIKE '''+'%' +xml_parsed.[Value]+ '%' + '''')
						FROM @SearchCriteriaTable xml_parsed
						WHERE xml_parsed.[Key] = 'BillId'
					END

					-- Handle Pagination
					SET @pagingString = CONCAT(@pagingString,' 
														OFFSET ', CONVERT(NVARCHAR(30), @PageNumber - 1), '*', CONVERT(NVARCHAR(30),@pageSize), ' ROWS 
														FETCH NEXT ', CONVERT(NVARCHAR(30), @pageSize), ' ROWS ONLY ')
					-- Handle OrderBy
					SET @orderBy = 'ORDER BY b.CreateDate DESC'

					-- Return result
					SET @sqlQuery = CONCAT('
														SELECT b.BillId
									,b.totalAmount
									,b.totalPaid
									,b.totalChange
									,b.CustomerId
									,u.UserId
									,u.UserName
									,s.ShiftId
									,s.ShiftName
									,bc.BranchId
									,bc.BranchName
									,b.CreateDate
									, CASE
										WHEN COALESCE(c.CustomerName, '''') = '''' THEN N''Khách Lẻ''
										ELSE c.CustomerName
									END AS CustomerName
							FROM dbo.Bills b
							LEFT JOIN dbo.Customers c ON b.CustomerId = c.CustomerId
							LEFT JOIN AccountsDb.dbo.Users u ON b.CreateBy = u.UserId
							LEFT JOIN AccountsDb.dbo.EmployeeShifts s ON s.ShiftId = b.ShiftId
							LEFT JOIN AccountsDb.dbo.UserBranchs ub ON ub.UserId = u.UserId
							LEFT JOIN dbo.Branches bc ON ub.BranchId = bc.BranchId
						WHERE 1 = 1
					', @sqlQuery_condition, @orderBy, @pagingString)

					EXEC (@sqlQuery)
				END

            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
