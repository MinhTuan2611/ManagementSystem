using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagementSystem.AccountingApi.Migrations
{
    public partial class Updateshiftend : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "ShiftEndReports",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.Sql(@"

                CREATE OR ALTER   PROCEDURE [dbo].[sp_generate_shift_handover]
    				(
    					@ShiftEndId INT
    					,@storateId INT
    					,@brandId INT
    				)
    				AS
    				BEGIN
						DECLARE @totalRevenue BIGINT
						,@totalBills INT
						,@totalPayment BIGINT
						,@shiftInReceiveMoney BIGINT
						,@reportingUser INT
						,@CompanyMoneyTransferred BIGINT
						,@handoverId INT = 0
						,@shiftId INT
						,@TotalRealAmountInShift BIGINT
						,@totalCash BIGINT
						,@totalRealReminingAmount BIGINT
						,@totalDiffAmount BIGINT

    					SELECT  @reportingUser = se.UserId
    							,@CompanyMoneyTransferred = se.CompanyMoneyTransferred
    							,@shiftId = se.ShiftId
    					FROM dbo.ShiftEndReports se
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
    								FROM StoragesProdDb.dbo.Bills b
    								JOIN StoragesProdDb.dbo.BillPayments bp ON bp.BillId = b.BillId
    								JOIN StoragesProdDb.dbo.PaymentMethods p ON p.PaymentMethodId = bp.PaymentMethodId
    								WHERE FORMAT(b.CreateDate, 'yyyy-MM-dd') =  FORMAT(GETDATE(), 'yyyy-MM-dd')
    								AND b.ShiftId = @shiftId
									AND b.BranchId = @brandId
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
    					FROM StoragesProdDb.dbo.Bills b
    					JOIN StoragesProdDb.dbo.BillPayments bp ON bp.BillId = b.BillId
    					WHERE FORMAT(b.CreateDate, 'yyyy-MM-dd') =  FORMAT(GETDATE(), 'yyyy-MM-dd')
    					AND b.ShiftId = @shiftId
						AND b.BranchId = @brandId

    					-- Calculate Total payment

    					SELECT @totalPayment = COALESCE(SUM(p.TotalMoneyVND), 0)
    					FROM dbo.PaymentVouchers p
    					WHERE FORMAT(p.TransactionDate, 'yyyy-MM-dd') =  FORMAT(GETDATE(), 'yyyy-MM-dd')
    					AND p.ShiftId = @shiftId
						AND p.BranchId = @brandId

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

    						IF NOT EXISTS (SELECT 1 FROM dbo.ShiftHandovers WHERE ShiftEndId = @ShiftEndId)
    						BEGIN
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
    								,r.ReasonName + ' Cho Ket Ca'
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
    								,r.ReasonName + ' Cho Ket Ca'
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
    								,r.ReasonName + ' Cho Ket Ca'
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
    								@totalCash + COALESCE(@shiftInReceiveMoney, 0) - @totalPayment,            -- RemindMoneyForNextShift - int
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

            ");

            migrationBuilder.Sql(@"
                CREATE OR ALTER   PROCEDURE [dbo].[sp_SearchReceipts]
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
					    DebitAccount NVARCHAR(128),
					    CreditAccount NVARCHAR(128)
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
								    ,concat(u.FirstName, '' '', u.LastName) AS Cashier
								    ,lg.DepositAccount AS DebitAccount
								    ,lg.CreditAccount AS CreditAccount
						    FROM ReceiptVouchers r
						    LEFT JOIN StoragesProdDB.dbo.Customers c ON r.CustomerId = c.CustomerId
						    JOIN AccountsDb.dbo.Users u ON u.UserId = r.UserId
						    LEFT JOIN dbo.Legers lg ON lg.DoccumentType = N''THU'' and lg.DoccumentNumber = r.DocumentNumber
					    WHERE 1 = 1
				    ', @sqlQuery_condition)

				    EXEC (@sqlQuery)
				
				    SELECT @TotalRecords = COUNT(1) FROM #tmp_records
				
				    SELECT *
				    FROM #tmp_records
				    ORDER BY TransactionDate DESC
				    OFFSET (@PageNumber - 1) * @PageSize ROWS FETCH NEXT @pageSize ROWS ONLY
			    END
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "ShiftEndReports");
        }
    }
}
