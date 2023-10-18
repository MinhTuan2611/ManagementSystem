using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagementSystem.AccountingApi.Migrations
{
    public partial class AddSearchingStore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE OR ALTER  PROCEDURE [dbo].[sp_SearchInventoryVoucher]
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

					INSERT INTO #web_column_mapping VALUES('FromDate', 'FORMAT(iv.TransactionDate, ''yyyy-MM-dd'')', '>=')
					INSERT INTO #web_column_mapping VALUES('ToDate', 'FORMAT(iv.TransactionDate, ''yyyy-MM-dd'')', '<=')

					SELECT @sqlQuery_condition = CONCAT(@sqlQuery_condition,+ ' AND '
										+ col_map.DB_COLUMN_ALIAS
										+ col_map.DB_COLUMN_OPERATION
										+ '''' + xml_parsed.[Value] + ''''
										+ (CHAR(10)) )
					FROM @SearchCriteriaTable xml_parsed
					JOIN #web_column_mapping col_map ON xml_parsed.[Key] = col_map.WEB_COLUMN

					-- Handle Pagination
					SET @pagingString = CONCAT(@pagingString,' 
														OFFSET ', CONVERT(NVARCHAR(30), @PageNumber - 1), '*', CONVERT(NVARCHAR(30),@pageSize), ' ROWS 
														FETCH NEXT ', CONVERT(NVARCHAR(30), @pageSize), ' ROWS ONLY ')
					-- Handle OrderBy
					SET @orderBy = 'ORDER BY iv.TransactionDate DESC'

					-- Return result
					SET @sqlQuery = CONCAT('
											SELECT DISTINCT iv.DocummentNumber
												,iv.CustomerId
												,c.CustomerName
												,iv.PurchasingRepresentive
												,iv.RepresentivePhone
												,iv.Note
												,iv.UserId
												,u.FirstName
												,u.LastName
												,u.Email
												,u.PhoneNumber
												,iv.ReasonFor
									--            ,p.PaymentMethodName
												--,p.PaymentMethodCode
												--,bp.Amount AS PaymentAmount
												,iv.TransactionDate
												,s.StorageName
												,r.CreditAccountId AS InventoryCreditAccout
												,r.DebitAccountId AS InventoryDebitAccount
												,iv.BillId
										FROM InventoryVouchers iv
										LEFT JOIN StoragesDb.dbo.BillPayments bp ON bp.BillId = iv.BillId
										-- LEFT JOIN StoragesDb.dbo.PaymentMethods p On bp.PaymentMethodId = p.PaymentMethodId
										LEFT JOIN StoragesDb.dbo.customers c ON iv.CustomerId = c.CustomerId
										LEFT JOIN AccountsDb.dbo.Users u ON iv.UserId = u.UserId
										LEFT JOIN StoragesDb.dbo.Storages s ON s.StorageId = iv.StorageId
										LEFT JOIN Recordingtransactions r ON r.ReasonGroup = iv.ReasonFor
						WHERE 1 = 1
					', @sqlQuery_condition, @orderBy, @pagingString)

					EXEC (@sqlQuery)
				END
            ");

			migrationBuilder.Sql(@"
				CREATE OR ALTER  PROCEDURE [dbo].[sp_SearchReceipts]
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

					INSERT INTO #web_column_mapping VALUES('FromDate', 'FORMAT(r.TransactionDate, ''yyyy-MM-dd'')', '>=')
					INSERT INTO #web_column_mapping VALUES('ToDate', 'FORMAT(r.TransactionDate, ''yyyy-MM-dd'')', '<=')

					SELECT @sqlQuery_condition = CONCAT(@sqlQuery_condition,+ ' AND '
										+ col_map.DB_COLUMN_ALIAS
										+ col_map.DB_COLUMN_OPERATION
										+ '''' + xml_parsed.[Value] + ''''
										+ (CHAR(10)) )
					FROM @SearchCriteriaTable xml_parsed
					JOIN #web_column_mapping col_map ON xml_parsed.[Key] = col_map.WEB_COLUMN

					-- Handle Pagination
					SET @pagingString = CONCAT(@pagingString,' 
														OFFSET ', CONVERT(NVARCHAR(30), @PageNumber - 1), '*', CONVERT(NVARCHAR(30),@pageSize), ' ROWS 
														FETCH NEXT ', CONVERT(NVARCHAR(30), @pageSize), ' ROWS ONLY ')
					-- Handle OrderBy
					SET @orderBy = 'ORDER BY r.TransactionDate DESC'

					-- Return result
					SET @sqlQuery = CONCAT('
							SELECT r.DocumentNumber
									,r.TransactionDate
									,c.CustomerId
									,c.CustomerName
									,c.CustomerName AS Payer
									,r.ForReason
									,r.TotalMoney
									,u.UserId
									,u.UserName AS Cashier
							FROM Receipts r
							JOIN StoragesDB.dbo.Customers c ON r.CustomerId = c.CustomerId
							JOIN AccountsDb.dbo.Users u ON u.UserId = r.UserId
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
