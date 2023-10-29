using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagementSystem.AccountingApi.Migrations
{
    public partial class AddNewSearchStore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.Sql(@"
			CREATE OR ALTER PROC dbo.sp_SearchCreditVouchers
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
								PaymentMethodName NVARCHAR(128)
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
				CREATE OR ALTER PROCEDURE dbo.sp_SearchDebitVouchers
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

								INSERT INTO #web_column_mapping VALUES('FromDate', 'FORMAT(pv.TransactionDate, ''yyyy-MM-dd'')', '>=')
								INSERT INTO #web_column_mapping VALUES('ToDate', 'FORMAT(pv.TransactionDate, ''yyyy-MM-dd'')', '<=')

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
								CREATE TABLE #tmp_records
								(
									BranchCode NVARCHAR(255),
									BranchName NVARCHAR(255),
									Address NVARCHAR(255),
									EmployeeName NVARCHAR(255),
									EmployeeId INT,
									ReceiverName NVARCHAR(255),
									Description NVARCHAR(255),
									Reason NVARCHAR(255),
									TotalMoneyVND DECIMAL(18, 2),
									ExchangeRate DECIMAL(18, 2),
									NTMoney DECIMAL(18, 2),
									DocumentNumber NVARCHAR(255),
									TransactionDate DATETIME,
									PaymentMethodName NVARCHAR(255),
									PaymentMethodCode VARCHAR(255)
								);

								-- Return result
								SET @sqlQuery = CONCAT('
									INSERT INTO #tmp_records
									SELECT b.BranchCode
											,b.BranchName
											,b.[Address]
											,CONCAT(u.FirstName, '''', u.LastName) AS EmployeeName
											,u.UserId AS EmployeeId
											,pv.ReceiverName
											,pv.Description
											,rt.ReasonName AS Reason
											,pv.TotalMoneyVND
											,pv.ExchangeRate
											,pv.NTMoney
											,pv.DocumentNumber
											,pv.TransactionDate
											,pm.PaymentMethodName
											,pm.PaymentMethodCode
									FROM dbo.DebitVouchers pv
									LEFT JOIN AccountsDb.dbo.Users u ON pv.UserId = u.UserId
									LEFT JOIN AccountsDb.dbo.UserBranchs ub ON ub.UserId = u.UserId
									LEFT JOIN StoragesDb.dbo.Branches b ON ub.BranchId = b.BranchId
									LEFT JOIN dbo.Recordingtransactions rt ON rt.ReasonCode = pv.Reason
									JOIN StoragesDb.dbo.PaymentMethods pm ON pm.PaymentMethodId = pv.PaymentMethodId
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
CREATE OR ALTER PROCEDURE dbo.sp_SearchDocumentGroup
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

							INSERT INTO #web_column_mapping VALUES('FromDate', 'FORMAT(TransactionDate, ''yyyy-MM-dd'')', '>=')
							INSERT INTO #web_column_mapping VALUES('ToDate', 'FORMAT(TransactionDate, ''yyyy-MM-dd'')', '<=')
							INSERT INTO #web_column_mapping VALUES('GroupId', 'GroupId', '=')


							SELECT @sqlQuery_condition = CONCAT(@sqlQuery_condition,+ ' AND '
												+ col_map.DB_COLUMN_ALIAS
												+ col_map.DB_COLUMN_OPERATION
												+ '''' + xml_parsed.[Value] + ''''
												+ (CHAR(10)) )
							FROM @SearchCriteriaTable xml_parsed
							JOIN #web_column_mapping col_map ON xml_parsed.[Key] = col_map.WEB_COLUMN

							-- Handle SpecialAccount
							DROP TABLE IF EXISTS #totalRecords
							CREATE TABLE #totalRecords
							(
								DocumentNumber INT
								,DocumentType VARCHAR(50)
							)

							-- Create a temporary table
							DROP TABLE IF EXISTS #tmp_records
							CREATE TABLE #tmp_records (
								TransactionDate DATETIME,
								CreditAccount VARCHAR(200),
								DepositAccount VARCHAR(200),
								DoccumentType NVARCHAR(255),
								DoccumentNumber INT,
								BillId INT,
								CustomerId INT,
								CustomerName NVARCHAR(255),
								Amount INT
							);

							-- Return result
							SET @sqlQuery = REPLACE('
								DROP TABLE IF EXISTS #creditVouchers
								SELECT DocumentNumber
									   ,''BAOCO'' AS DocumentType
								INTO #creditVouchers
								FROM dbo.CreditVouchers
								WHERE 1 = 1
								{0}

								DROP TABLE IF EXISTS #debitVouchers
								SELECT DocumentNumber
										,''BAONO'' AS DocumentType
								INTO #debitVouchers
								FROM dbo.DebitVouchers
								WHERE 1 = 1
								{0}

								DROP TABLE IF EXISTS #inventoryVouchers
								SELECT DocummentNumber
										,''XUAT'' AS DocumentType
								INTO #inventoryVouchers
								FROM dbo.InventoryVouchers
								WHERE 1 = 1
								{0}

								DROP TABLE IF EXISTS #receiptVouchers
								SELECT DocumentNumber
										,''THU'' AS DocumentType
								INTO #receiptVouchers
								FROM dbo.ReceiptVouchers
								WHERE 1 = 1
								{0}

								DROP TABLE IF EXISTS #paymentVouchers
								SELECT DocumentNumber
										,''CHI'' AS DocumentType
								INTO #paymentVouchers
								FROM dbo.PaymentVouchers
								WHERE 1 = 1
								{0}

								DROP TABLE IF EXISTS #otherEntries
								SELECT DocumentNumber
										,''BUT TOAN KHAC'' AS DocumentType
								INTO #otherEntries
								FROM dbo.OtherAccountEntries
								WHERE 1 = 1 
								{0}

								INSERT INTO #totalRecords
								SELECT *
								FROM #creditVouchers
								UNION ALL
								SELECT *
								FROM #debitVouchers
								UNION ALL
								SELECT *
								FROM #inventoryVouchers
								UNION ALL
								SELECT *
								FROM #receiptVouchers
								UNION ALL
								SELECT *
								FROM #paymentVouchers
								UNION ALL
								SELECT *
								FROM #otherEntries

								INSERT INTO #tmp_records
								SELECT  l.TransactionDate
								,l.CreditAccount
								,l.DepositAccount
								,l.DoccumentType
								,l.DoccumentNumber
								,l.BillId
								,l.CustomerId
								,c.CustomerName
								,l.Amount
						FROM Legers l
						JOIN #totalRecords t ON t.DocumentNumber = l.DoccumentNumber
												AND l.DoccumentType = t.DocumentType
						JOIN AccountsDb.dbo.Users u ON l.UserId = u.UserId
						LEFT JOIN StoragesDb.dbo.Customers c on l.CustomerId = c.CustomerId
						LEFT JOIN StoragesDb.dbo.Storages s ON l.StorageId = s.StorageId

							', '{0}', @sqlQuery_condition)

							EXEC (@sqlQuery)
							SELECT @TotalRecords = COUNT(1) FROM #tmp_records
				
							SELECT *
									,CASE
										WHEN id.DocummentNumber IS NOT NULL THEN id.Note
										WHEN pv.DocumentNumber IS NOT NULL THEN pv.Description
										WHEN oa.DocumentNumber IS NOT NULL THEN oa.PaymentDescription
										WHEN dv.DocumentNumber IS NOT NULL THEN dv.Description
									ELSE ''
									END AS LegerDescription
							FROM #tmp_records t
							LEFT JOIN dbo.InventoryVouchers id ON t.DoccumentNumber = id.DocummentNumber
							LEFT JOIN dbo.PaymentVouchers pv ON pv.DocumentNumber = t.DoccumentNumber
							LEFT JOIN dbo.OtherAccountEntries oa ON t.DoccumentNumber = oa.DocumentNumber
							LEFT JOIN dbo.DebitVouchers dv ON dv.DocumentNumber = t.DoccumentNumber
							ORDER BY t.TransactionDate DESC
							OFFSET (@PageNumber - 1) * @PageSize ROWS FETCH NEXT @pageSize ROWS ONLY
						END
					GO
			");

			migrationBuilder.Sql(@"
	CREATE OR ALTER VIEW dbo.ShiftEndReportView_latest
                AS
                WITH cte
                AS
                (
	                SELECT MAX(ShiftEndId) AS ShiftEndId
	                FROM dbo.ShiftEndReports 
                )
                SELECT s.ShiftEndId
		                ,s.UserId
		                ,u.UserName
		                ,es.ShiftId
		                ,es.ShiftName
		                ,s.ShiftEndDate
		                ,s.CompanyMoneyTransferred
		                ,sh.Denomination
		                ,sh.Amount
		                ,sa.ProductId
                        ,p.ProductName
		                ,ui.UnitId
		                ,ui.UnitName
		                ,sa.ActualAmount
		                ,sa.SystemAmount
						,b.BranchId
						,b.BranchName
                FROM cte 
                JOIN dbo.ShiftEndReports s ON s.ShiftEndId = cte.ShiftEndId
                LEFT JOIN dbo.InventoryAuditDetails sa ON sa.ShiftEndId = s.ShiftEndId
                LEFT JOIN dbo.ShiftHandoverCashDetails sh ON sh.ShiftEndId = s.ShiftEndId
                LEFT JOIN AccountsDb.dbo.Users u ON u.UserId = s.UserId
                LEFT JOIN AccountsDb.dbo.EmployeeShifts es ON es.ShiftId = s.ShiftId
                LEFT JOIN StoragesDb.dbo.Products p ON p.ProductId = sa.ProductId
                LEFT JOIN StoragesDb.dbo.Unit ui ON sa.UnitId = ui.UnitId
				LEFT JOIN AccountsDb.dbo.UserBranchs ub ON ub.UserId = u.UserId
				LEFT JOIN StoragesDb.dbo.Branches b ON b.BranchId = ub.BranchId
				GO

				");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
