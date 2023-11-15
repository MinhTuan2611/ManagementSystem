using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagementSystem.AccountingApi.Migrations
{
    public partial class updatestore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
						CREATE OR ALTER PROCEDURE dbo.sp_SearchInventoryVoucher
								@xmlString NVARCHAR(MAX)
								,@pageNumber INT = 1
								,@pageSize INT = 10
								,@TotalRecords INT OUTPUT
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

								-- Create a temporary table
								CREATE TABLE #tmp_records (
									DocummentNumber INT,
									CustomerId INT,
									CustomerName NVARCHAR(255),
									PurchasingRepresentive NVARCHAR(255),
									RepresentivePhone NVARCHAR(255),
									Note NVARCHAR(MAX),
									UserId INT,
									FirstName NVARCHAR(255),
									LastName NVARCHAR(255),
									Email NVARCHAR(255),
									PhoneNumber NVARCHAR(255),
									ReasonFor NVARCHAR(MAX),
									TransactionDate DATETIME,
									StorageName NVARCHAR(255),
									InventoryCreditAccout INT,
									InventoryDebitAccount INT,
									BillId INT
								);

								-- Return result
								SET @sqlQuery = CONCAT('
											INSERT INTO #tmp_records
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
												,iv.CreditAccount AS InventoryCreditAccout
												,iv.DebitAccount AS InventoryDebitAccount
												,iv.BillId
										FROM InventoryVouchers iv
										LEFT JOIN StoragesDb.dbo.BillPayments bp ON bp.BillId = iv.BillId
										-- LEFT JOIN StoragesDb.dbo.PaymentMethods p On bp.PaymentMethodId = p.PaymentMethodId
										LEFT JOIN StoragesDb.dbo.customers c ON iv.CustomerId = c.CustomerId
										LEFT JOIN AccountsDb.dbo.Users u ON iv.UserId = u.UserId
										LEFT JOIN StoragesDb.dbo.Storages s ON s.StorageId = iv.StorageId
										WHERE 1 = 1
								', @sqlQuery_condition)

								EXEC (@sqlQuery)
								SELECT @TotalRecords = COUNT(1) FROM #tmp_records
				
								SELECT *
								FROM #tmp_records
								ORDER BY TransactionDate DESC
								OFFSET (@PageNumber - 1) * @PageSize ROWS FETCH NEXT @pageSize ROWS ONLY
							END      
				GO

            ");

			migrationBuilder.Sql(@"
				CREATE OR ALTER PROCEDURE dbo.sp_SearchCreditVouchers
								@xmlString NVARCHAR(MAX)
								,@pageNumber INT = 1
								,@pageSize INT = 10
								,@TotalRecords INT OUTPUT
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

								-- Create a temporary table
								DROP TABLE IF EXISTS #tmp_records
								CREATE TABLE #tmp_records
								(
									DocumentNumber INT,
									TransactionDate DATETIME,
									CustomerId INT,
									CustomerName NVARCHAR(255),
									Payer NVARCHAR(255),
									ForReason NVARCHAR(MAX),
									TotalMoney DECIMAL(18, 2),
									UserId INT,
									Cashier NVARCHAR(255),
									PaymentMethodCode VARCHAR(128),
									PaymentMethodName NVARCHAR(128),
									CreditAccount VARCHAR(128),
									DebitAccount VARCHAR(128)
								);

								-- Return result
								SET @sqlQuery = CONCAT('
										INSERT INTO #tmp_records
										SELECT r.DocumentNumber
												,r.TransactionDate
												,c.CustomerId
												,c.CustomerName
												,c.CustomerName AS Payer
												,rt.ReasonName
												,r.TotalMoney
												,u.UserId
												,u.UserName AS Cashier
												,pm.PaymentMethodCode
												,pm.PaymentMethodName
												,r.CreditAccount
												,r.DebitAccount
										FROM dbo.CreditVouchers r
										LEFT JOIN StoragesDB.dbo.Customers c ON r.CustomerId = c.CustomerId
										LEFT JOIN AccountsDb.dbo.Users u ON u.UserId = r.UserId
										JOIN StoragesDb.dbo.PaymentMethods pm ON pm.PaymentMethodId = r.PaymentMethodId
										JOIN dbo.Recordingtransactions rt ON rt.ReasonCode = r.ForReason
									WHERE 1 = 1
								', @sqlQuery_condition)

								EXEC (@sqlQuery)
	
								SELECT @TotalRecords = COUNT(1) FROM #tmp_records
	
								SELECT *
								FROM #tmp_records
								ORDER BY TransactionDate DESC
								OFFSET (@PageNumber - 1) * @PageSize ROWS FETCH NEXT @pageSize ROWS ONLY
							END
				GO
			");

			migrationBuilder.Sql(@"
					CREATE OR ALTER PROCEDURE dbo.sp_SearchOtherEntries
												@xmlString NVARCHAR(MAX)
												,@pageNumber INT = 1
												,@pageSize INT = 10
												,@TotalRecords INT OUTPUT
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

												INSERT INTO #web_column_mapping VALUES('FromDate', 'FORMAT(oe.TransactionDate, ''yyyy-MM-dd'')', '>=')
												INSERT INTO #web_column_mapping VALUES('ToDate', 'FORMAT(oe.TransactionDate, ''yyyy-MM-dd'')', '<=')

												SELECT @sqlQuery_condition = CONCAT(@sqlQuery_condition,+ ' AND '
																	+ col_map.DB_COLUMN_ALIAS
																	+ col_map.DB_COLUMN_OPERATION
																	+ '''' + xml_parsed.[Value] + ''''
																	+ (CHAR(10)) )
												FROM @SearchCriteriaTable xml_parsed
												JOIN #web_column_mapping col_map ON xml_parsed.[Key] = col_map.WEB_COLUMN

												-- Create a temporary table
												CREATE TABLE #tmp_records
												(
													BranchCode NVARCHAR(255),
													BranchName NVARCHAR(255),
													Address NVARCHAR(255),
													PayerName NVARCHAR(255),
													CustomerName NVARCHAR(255),
													PaymentDescription NVARCHAR(255),
													Reason NVARCHAR(255),
													EmployeeName NVARCHAR(255),
													EmployeeId INT,
													Amount INT,
													AccountId INT,
													DocumentNumber NVARCHAR(255),
													Note NVARCHAR(255),
													CreditAccount VARCHAR(128),
													DebitAccount VARCHAR(128)
												);

												-- Return result
												SET @sqlQuery = CONCAT('
													INSERT INTO #tmp_records
													SELECT b.BranchCode
															,b.BranchName
															,b.[Address]
															,c.CustomerName AS PayerName
															,c.CustomerName
															,oe.PaymentDescription
															,oe.Reason
															,CONCAT(u.FirstName, '' '', u.LastName) AS EmployeeName
															,u.UserId AS EmployeeId
															,oe.Amount
															,oe.AccountId
															,oe.DocumentNumber
															,oe.Note
															,oe.CreditAccount
															,oe.DebitAccount
													FROM OtherAccountEntries oe
													LEFT JOIN StoragesDb.dbo.Branches b ON oe.BrandId = b.BranchId
													LEFT JOIN StoragesDb.dbo.Customers c ON c.CustomerId = oe.CustomerId
													LEFT JOIN AccountsDB.dbo.Users u ON oe.UserId = u.UserId
													WHERE 1 = 1
												', @sqlQuery_condition)

												EXEC (@sqlQuery)
				
												SELECT @TotalRecords = COUNT(1) FROM #tmp_records
				
												SELECT *
												FROM #tmp_records
												ORDER BY DocumentNumber DESC
												OFFSET (@PageNumber - 1) * @PageSize ROWS FETCH NEXT @pageSize ROWS ONLY
											END
					GO
			");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
