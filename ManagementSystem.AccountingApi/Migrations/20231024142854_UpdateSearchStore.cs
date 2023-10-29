using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagementSystem.AccountingApi.Migrations
{
    public partial class UpdateSearchStore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
			CREATE OR ALTER PROCEDURE dbo.sp_shift_handovers
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

				CREATE TABLE #tmp_records
				(
					ShiftEndId INT,
					TotalBill DECIMAL(18, 2)
				);

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

				INSERT INTO #web_column_mapping VALUES('FromDate', 'FORMAT(sh.HandoverTime, ''yyyy-MM-dd'')', '>=')
				INSERT INTO #web_column_mapping VALUES('ToDate', 'FORMAT(sh.HandoverTime, ''yyyy-MM-dd'')', '<=')

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
				SET @orderBy = 'ORDER BY sh.HandoverTime DESC'

				-- Return result
				SET @sqlQuery = CONCAT('
						INSERT INTO #tmp_records (ShiftEndId, TotalBill)
						SELECT sr.ShiftEndId
							,SUM(sd.Denomination * sd.Amount) AS TotalBill
						FROM dbo.ShiftEndReports sr
						LEFT JOIN dbo.ShiftHandoverCashDetails sD ON sd.ShiftEndId = sr.ShiftEndId
						LEFT JOIN dbo.ShiftHandovers sh ON sh.ShiftEndId = sr.ShiftEndId
						WHERE 1 = 1
						', @sqlQuery_condition,
						'GROUP BY sr.ShiftEndId

					'
				)

				EXEC(@sqlQuery)
				SELECT @TotalRecords = COUNT(1) FROM #tmp_records
				-- return result
				SET @sqlQuery = CONCAT('SELECT sh.HandoverId
							,es.ShiftId
							,es.ShiftName
							,sh.HandoverTime AS HandoverDate
							,t.TotalBill AS TotalAmount
							,s.TotalShiftInMoney AS CurShiftAmount
							,LAG(s.TotalShiftInMoney) OVER (ORDER BY sr.ShiftEndId) AS PreShiftAmount
					FROM #tmp_records t
					JOIN dbo.ShiftEndReports sr ON sr.ShiftEndId = t.ShiftEndId
					LEFT JOIN dbo.ShiftHandovers sh ON sh.ShiftEndId = sr.ShiftEndId
					LEFT JOIN AccountsDb.dbo.EmployeeShifts es ON es.ShiftId = sr.ShiftId
					LEFT JOIN dbo.ShiftReports s ON s.HandoverId = sh.HandoverId
				', @orderBy, @pagingString)

				EXEC(@sqlQuery)
			END
           
			GO
		");

            migrationBuilder.Sql(@"
				CREATE OR ALTER PROCEDURE dbo.sp_SearchShiftEndReports
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

					INSERT INTO #web_column_mapping VALUES('FromDate', 'FORMAT(s.ShiftEndDate, ''yyyy-MM-dd'')', '>=')
					INSERT INTO #web_column_mapping VALUES('ToDate', 'FORMAT(s.ShiftEndDate, ''yyyy-MM-dd'')', '<=')

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
					SET @orderBy = 'ORDER BY s.ShiftEndDate DESC'

					-- Create a temporary table
					CREATE TABLE #tmp_records (
						ShiftEndId INT,
						UserId INT,
						UserName NVARCHAR(255),
						ShiftId INT,
						ShiftName NVARCHAR(255),
						ShiftEndDate DATETIME,
						CompanyMoneyTransferred INT,
						Denomination INT,
						Amount INT,
						ProductId INT,
						ProductName NVARCHAR(255),
						UnitId INT,
						UnitName NVARCHAR(255),
						ActualAmount INT,
						SystemAmount INT,
						BranchId INT,
						BranchName NVARCHAR(255)
					);

					-- Return result
					SET @sqlQuery = CONCAT('
						   INSERT INTO #tmp_records
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
								,COALESCE(sa.ActualAmount, 0) AS ActualAmount
								,COALESCE(sa.SystemAmount, 0) AS SystemAmount
								,b.BranchId
								,b.BranchName
						   FROM dbo.ShiftEndReports s
						   LEFT JOIN dbo.InventoryAuditDetails sa ON sa.ShiftEndId = s.ShiftEndId
						   LEFT JOIN dbo.ShiftHandoverCashDetails sh ON sh.ShiftEndId = s.ShiftEndId
						   LEFT JOIN AccountsDb.dbo.Users u ON u.UserId = s.UserId
						   LEFT JOIN AccountsDb.dbo.EmployeeShifts es ON es.ShiftId = s.ShiftId
						   LEFT JOIN StoragesDb.dbo.Products p ON p.ProductId = sa.ProductId
						   LEFT JOIN StoragesDb.dbo.Unit ui ON sa.UnitId = ui.UnitId
						   LEFT JOIN AccountsDb.dbo.UserBranchs ub ON ub.UserId = u.UserId
						   LEFT JOIN StoragesDb.dbo.Branches b ON b.BranchId = ub.BranchId
						   WHERE 1 = 1
					', @sqlQuery_condition)

					EXEC (@sqlQuery)

					SELECT @TotalRecords = COUNT(DISTINCT ShiftEndId) FROM #tmp_records

					DROP TABLE IF EXISTS #tmp_return_ids
					SELECT ShiftEndId
					INTO #tmp_return_ids
					FROM #tmp_records
					GROUP BY ShiftEndId
					ORDER BY 1 DESC
					OFFSET (@PageNumber - 1) * @PageSize ROWS FETCH NEXT @pageSize ROWS ONLY

					SELECT DISTINCT t1.*
					FROM #tmp_records t1
					JOIN #tmp_return_ids t2 ON t2.ShiftEndId = t1.ShiftEndId
				END        
			GO
			");

            migrationBuilder.Sql(@"CREATE OR ALTER PROCEDURE dbo.sp_SearchInventoryVoucher
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
								', @sqlQuery_condition)

								EXEC (@sqlQuery)
								SELECT @TotalRecords = COUNT(1) FROM #tmp_records
				
								SELECT *
								FROM #tmp_records
								ORDER BY TransactionDate DESC
								OFFSET (@PageNumber - 1) * @PageSize ROWS FETCH NEXT @pageSize ROWS ONLY
							END      
			GO");

            migrationBuilder.Sql(@"CREATE OR ALTER PROCEDURE dbo.sp_SearchReceipts
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
					Cashier NVARCHAR(255)
				);

				-- Return result
				SET @sqlQuery = CONCAT('
						INSERT INTO #tmp_records
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
				', @sqlQuery_condition)

				EXEC (@sqlQuery)
				
				SELECT @TotalRecords = COUNT(1) FROM #tmp_records
				
				SELECT *
				FROM #tmp_records
				ORDER BY TransactionDate DESC
				OFFSET (@PageNumber - 1) * @PageSize ROWS FETCH NEXT @pageSize ROWS ONLY
			END
		GO");

            migrationBuilder.Sql(@"
		CREATE OR ALTER PROCEDURE dbo.sp_SearchLegers
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

							INSERT INTO #web_column_mapping VALUES('FromDate', 'FORMAT(l.TransactionDate, ''yyyy-MM-dd'')', '>=')
							INSERT INTO #web_column_mapping VALUES('ToDate', 'FORMAT(l.TransactionDate, ''yyyy-MM-dd'')', '<=')
							INSERT INTO #web_column_mapping VALUES('BillId', 'l.BillId', '=')
							INSERT INTO #web_column_mapping VALUES('CustomerName', 'c.CustomerName', '=')
							INSERT INTO #web_column_mapping VALUES('CustomerCode', 'c.CustomerCode', '=')
							INSERT INTO #web_column_mapping VALUES('CustomerId', 'c.CustomerId', '=')
							INSERT INTO #web_column_mapping VALUES('Employee', 'u.UserName', '=')
							INSERT INTO #web_column_mapping VALUES('DocumentType', 'l.DoccumentType', '=')
							INSERT INTO #web_column_mapping VALUES('DoccumentNumber', 'l.DoccumentNumber', '=')

							SELECT @sqlQuery_condition = CONCAT(@sqlQuery_condition,+ ' AND '
												+ col_map.DB_COLUMN_ALIAS
												+ col_map.DB_COLUMN_OPERATION
												+ '''' + xml_parsed.[Value] + ''''
												+ (CHAR(10)) )
							FROM @SearchCriteriaTable xml_parsed
							JOIN #web_column_mapping col_map ON xml_parsed.[Key] = col_map.WEB_COLUMN

							-- Handle SpecialAccount
							SELECT @sqlQuery_condition = CONCAT(@sqlQuery_condition,+ ' AND '
												+ '(l.CreditAccount IN (' + CONVERT(VARCHAR(MAX), xml_parsed.[Value]) + ')'+ (CHAR(10)) )
							FROM @SearchCriteriaTable xml_parsed
							WHERE xml_parsed.[Key] = 'CreditAccount'

							SELECT @sqlQuery_condition = CONCAT(@sqlQuery_condition,+ ' AND '	
												+ 'l.DepositAccount IN (' + CONVERT(VARCHAR(MAX), xml_parsed.[Value]) + '))' + (CHAR(10)) )
							FROM @SearchCriteriaTable xml_parsed
							WHERE xml_parsed.[Key] = 'DebitAccount'

							-- Handle Pagination
							SET @pagingString = CONCAT(@pagingString,' 
																OFFSET ', CONVERT(NVARCHAR(30), @PageNumber - 1), '*', CONVERT(NVARCHAR(30),@pageSize), ' ROWS 
																FETCH NEXT ', CONVERT(NVARCHAR(30), @pageSize), ' ROWS ONLY ')
							-- Handle OrderBy
							SET @orderBy = 'ORDER BY l.TransactionDate DESC'

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
							SET @sqlQuery = CONCAT('
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
								JOIN AccountsDb.dbo.Users u ON l.UserId = u.UserId
								LEFT JOIN StoragesDb.dbo.Customers c on l.CustomerId = c.CustomerId
								LEFT JOIN StoragesDb.dbo.Storages s ON l.StorageId = s.StorageId
								WHERE 1 = 1
							', @sqlQuery_condition)

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
						END
		GO

		");

		migrationBuilder.Sql(@"
		CREATE OR ALTER PROCEDURE dbo.sp_generate_shift_handover
		(
			@ShiftEndId INT
			,@storateId INT
			,@brandId INT
		)
		AS
		BEGIN

			DECLARE @shiftStart INT
					,@shiftEnd INT
					,@totalRevenue INT
					,@totalBills INT
					,@totalPayment INT
					,@shiftInReceiveMoney INT
					,@reportingUser INT
					,@CompanyMoneyTransferred INT
					,@handoverId INT = 0
					,@shiftId INT
					,@TotalRealAmountInShift INT
					,@totalCash INT
					,@totalRealReminingAmount INT
					,@totalDiffAmount INT

			SELECT @shiftStart = s.StartHour
					,@shiftEnd = s.EndHour
					,@reportingUser = se.UserId
					,@CompanyMoneyTransferred = se.CompanyMoneyTransferred
					,@shiftId = se.ShiftId
			FROM dbo.ShiftEndReports se
			JOIN AccountsDb.dbo.EmployeeShifts s ON s.ShiftId = se.ShiftId
			WHERE ShiftEndId = @ShiftEndId

				-- Tinh tien dau ca
			;WITH cte
			AS
			(
				SELECT TOP 1 CashHandover
				FROM dbo.ShiftHandovers
				ORDER BY HandoverId DESC
			)

			SELECT @shiftInReceiveMoney = CashHandover
			FROM cte

			-- Tinh tong tien theo tung loai thanh toan
						-- Calculate total amout for each payment methods

					DROP TABLE IF EXISTS #totalAmountByMethods
					;WITH cte
					AS
					(
						SELECT p.PaymentMethodCode
							,SUM(bp.Amount) AS TotalAmount
						FROM StoragesDb.dbo.Bills b
						JOIN StoragesDb.dbo.BillPayments bp ON bp.BillId = b.BillId
						JOIN StoragesDb.dbo.PaymentMethods p ON p.PaymentMethodId = bp.PaymentMethodId
						JOIN AccountsDb.dbo.EmployeeShifts s ON s.ShiftId = b.ShiftId
						JOIN dbo.ShiftEndReports ser ON ser.ShiftId = b.ShiftId
													 AND ser.ShiftEndId = @ShiftEndId
						WHERE FORMAT(b.CreateDate, 'yyyy-MM-dd') =  FORMAT(GETDATE(), 'yyyy-MM-dd')
						GROUP BY p.PaymentMethodCode
					)

					SELECT *
					INTO #totalAmountByMethods
					FROM
					(
						SELECT PaymentMethodCode
								,TotalAmount
						FROM cte
					) AS t
					PIVOT
					(
						SUM(TotalAmount)
						FOR PaymentMethodCode IN (
							[MOMO], [CASH], [CARD], [BANKING])
					) AS pivot_table

			-- Calculate total shift in cash money

			-- Calculate Total Revenue
			SELECT @totalRevenue = COALESCE(SUM(bp.Amount), 0)
					,@totalBills = COALESCE(COUNT(DISTINCT b.BillId), 0)
			FROM StoragesDb.dbo.Bills b
			JOIN StoragesDb.dbo.BillPayments bp ON bp.BillId = b.BillId
			WHERE FORMAT(b.CreateDate, 'yyyy-MM-dd') =  FORMAT(GETDATE(), 'yyyy-MM-dd')
			AND DATEPART(HOUR, b.CreateDate) >= @shiftStart
			AND DATEPART(HOUR, b.CreateDate) <= @shiftEnd

			-- Calculate Total payment

			SELECT @totalPayment = COALESCE(SUM(p.TotalMoneyVND), 0)
			FROM dbo.PaymentVouchers p
			WHERE FORMAT(p.TransactionDate, 'yyyy-MM-dd') =  FORMAT(GETDATE(), 'yyyy-MM-dd')
			AND DATEPART(HOUR, p.TransactionDate) >= @shiftStart
			AND DATEPART(HOUR, p.TransactionDate) <= @shiftEnd

			-- Tinh tien thu duoc thuc te trong ca
			SELECT @totalCash = COALESCE(SUM(Denomination * Amount), 0)
			FROM dbo.ShiftHandoverCashDetails
			WHERE ShiftEndId = @ShiftEndId

			SET @TotalRealAmountInShift = COALESCE(@totalCash, 0) - COALESCE(@CompanyMoneyTransferred, 0) + COALESCE(@totalPayment, 0)

			-- Tinh tien thuc te con lai
			SET @totalRealReminingAmount = COALESCE(@TotalRealAmountInShift, 0) - COALESCE(@totalPayment, 0)

			-- Tinh Tien thua thieu

			SELECT @totalDiffAmount = COALESCE(@TotalRealAmountInShift, 0) - (COALESCE(CASH, 0) + COALESCE(@shiftInReceiveMoney, 0))
			FROM #totalAmountByMethods

			BEGIN TRY
				BEGIN TRANSACTION
		
				-- Tao 3 phieu chi
				DECLARE @OutputTbl TABLE (ID INT)

				-- Phieu ket chuyen
				INSERT INTO dbo.PaymentVouchers
				(
					BranchId,
					DebitAccount,
					CreditAccount,
					Reason,
					Description,
					TransactionDate,
					UpdatedDate,
					ShiftId,
					ExchangeRate,
					NTMoney,
					ReceiverName,
					TotalMoneyVND,
					UserId
				)
				SELECT @brandId
						,td.AccountCode
						,tc.AccountCode
						,r.ReasonCode
						,r.ReasonName
						,GETDATE()
						,GETDATE()
						,@shiftId
						,0
						,0
						,''
						,@TotalRealAmountInShift
						,@reportingUser
				FROM dbo.Recordingtransactions r
				LEFT JOIN dbo.TypesOfAccounts tc ON r.CreditAccountId = tc.AccountId
				LEFT JOIN dbo.TypesOfAccounts td ON r.DebitAccountId = td.AccountId
				WHERE r.ReasonCode = 'KETCHUYEN'

				INSERT INTO @OutputTbl VALUES(@@IDENTITY)

				-- Phieu but toan 2
				INSERT INTO dbo.PaymentVouchers
				(
					BranchId,
					DebitAccount,
					CreditAccount,
					Reason,
					Description,
					TransactionDate,
					UpdatedDate,
					ShiftId,
					ExchangeRate,
					NTMoney,
					ReceiverName,
					TotalMoneyVND,
					UserId
				)
				SELECT @brandId
						,td.AccountCode
						,tc.AccountCode
						,r.ReasonCode
						,r.ReasonName
						,GETDATE()
						,GETDATE()
						,@shiftId
						,0
						,0
						,''
						,@totalRealReminingAmount
						,@reportingUser
				FROM dbo.Recordingtransactions r
				LEFT JOIN dbo.TypesOfAccounts tc ON r.CreditAccountId = tc.AccountId
				LEFT JOIN dbo.TypesOfAccounts td ON r.DebitAccountId = td.AccountId
				WHERE r.ReasonCode = 'TIEN'
				INSERT INTO @OutputTbl VALUES(@@IDENTITY)

				--	Tao phieu thua thieu
				DECLARE @reportFilter VARCHAR(128) = 'THIEU'
				IF @totalDiffAmount > 0
				BEGIN
					SET @reportFilter = 'THUA'
				END

				INSERT INTO dbo.PaymentVouchers
				(
					BranchId,
					DebitAccount,
					CreditAccount,
					Reason,
					Description,
					TransactionDate,
					UpdatedDate,
					ShiftId,
					ExchangeRate,
					NTMoney,
					ReceiverName,
					TotalMoneyVND,
					UserId
				)
				SELECT @brandId
						,td.AccountCode
						,tc.AccountCode
						,r.ReasonCode
						,r.ReasonName
						,GETDATE()
						,GETDATE()
						,@shiftId
						,0
						,0
						,''
						,@totalDiffAmount
						,@reportingUser
				FROM dbo.Recordingtransactions r
				LEFT JOIN dbo.TypesOfAccounts tc ON r.CreditAccountId = tc.AccountId
				LEFT JOIN dbo.TypesOfAccounts td ON r.DebitAccountId = td.AccountId
				WHERE r.ReasonCode = @reportFilter
				INSERT INTO @OutputTbl VALUES(@@IDENTITY)

				SELECT *
				FROM @OutputTbl

				-- Tao But toan
				INSERT INTO dbo.Legers
				(
					TransactionDate,
					CreditAccount,
					DepositAccount,
					DoccumentType,
					DoccumentNumber,
					BillId,
					CustomerId,
					Amount,
					UserId,
					StorageId
				)
				SELECT SYSDATETIME()
						,P.CreditAccount
						,p.DebitAccount
						,'CHI'
						,a.ID
						,NULL
						,NULL
						,COALESCE(p.TotalMoneyVND, 0)
						,p.UserId
						,@storateId
				FROM @OutputTbl a
				JOIN dbo.PaymentVouchers p ON a.ID = p.DocumentNumber

				IF NOT EXISTS (SELECT 1 FROM dbo.ShiftHandovers WHERE ShiftEndId = @ShiftEndId)
				BEGIN
				INSERT INTO dbo.ShiftHandovers
				(
					StorageId,
					CashHandover,
					SenderUserId1,
					SenderUserI2,
					ReceiverUserId,
					TotalShiftMoney,
					CompanyMoneyTransferred,
					Note,
					Status,
					ShiftEndId,
					HandoverTime
				)
				VALUES
				(   @storateId,
					COALESCE(@TotalRealAmountInShift, 0),         -- CashHandover - int
					@reportingUser,         -- SenderUserId1 - int
					NULL,         -- SenderUserI2 - int
					NULL,         -- ReceiverUserId - int
					COALESCE(@TotalRealAmountInShift, 0),  -- TotalShiftMoney - int
					@CompanyMoneyTransferred,
					NULL,         -- Note - nvarchar(max)
					NULL,         -- Status - nvarchar(max)
					@ShiftEndId,            -- ShiftEndId - int
					SYSDATETIME() -- HandoverTime - datetime2(7)
					)

					SET @handoverId = @@IDENTITY
				END

				IF @handoverId > 0
				BEGIN

					INSERT INTO dbo.ShiftReports
					(
						ShiftId,
						UserCreatedId,
						HandoverId,
						TotalBill,
						TotalShiftInMoney,
						TotalRevenue,
						TotalCashAmount,
						TotalVoucherAmount,
						TotalInternalConsumption,
						TotalMOMOAmount,
						TotalExpenses,
						OtherExpense,
						ActualMoneyForNextShift,
						RemindMoneyForNextShift,
						ExcessMoney,
						LackOfMoney,
						ReportDate,
						TotalCardAmount
					)
					SELECT @shiftId,         -- ShiftId - int
						@reportingUser,         -- UserCreatedId - int
						@handoverId,         -- HandoverId - int
						@totalBills,            -- TotalBill - int
						COALESCE(@shiftInReceiveMoney, 0),            -- TotalShiftInMoney - int
						@totalRevenue,            -- TotalRevenue - int
						COALESCE(CASH, 0),            -- TotalCashAmount - int
						0,            -- TotalVoucherAmount - int
						0,            -- TotalInternalConsumption - int
						COALESCE(MOMO, 0),            -- TotalMOMOAmount - int
						COALESCE(@totalPayment, 0),            -- TotalExpenses - int
						@totalPayment,            -- OtherExpense - int
						COALESCE(@TotalRealAmountInShift, 0),            -- ActualMoneyForNextShift - int
						@totalCash + @shiftInReceiveMoney - @totalPayment,            -- RemindMoneyForNextShift - int
						@totalDiffAmount,            -- ExcessMoney - int
						@totalDiffAmount,            -- LackOfMoney - int
						SYSDATETIME(), -- ReportDate - datetime2(7)
						COALESCE(CARD, 0) + COALESCE(BANKING, 0)
					FROM #totalAmountByMethods

				END

				COMMIT
			END TRY
			BEGIN CATCH
				IF @@TRANCOUNT > 0
				BEGIN
					ROLLBACK
			
				END

				DECLARE @ErrorMessage VARCHAR(MAX) = ERROR_MESSAGE();
				THROW 51000, @ErrorMessage, 1;
			END CATCH
		END
		GO
		");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
