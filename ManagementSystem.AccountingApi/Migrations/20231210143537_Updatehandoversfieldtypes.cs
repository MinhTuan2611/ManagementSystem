using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagementSystem.AccountingApi.Migrations
{
    public partial class Updatehandoversfieldtypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "CompanyMoneyTransferred",
                table: "ShiftHandovers",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CashHandover",
                table: "ShiftHandovers",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
                GO
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CompanyMoneyTransferred",
                table: "ShiftHandovers",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CashHandover",
                table: "ShiftHandovers",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);
        }
    }
}
