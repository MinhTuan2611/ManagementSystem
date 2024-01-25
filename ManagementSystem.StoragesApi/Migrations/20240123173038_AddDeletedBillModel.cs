using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagementSystem.StoragesApi.Migrations
{
    public partial class AddDeletedBillModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BillDeleted",
                columns: table => new
                {
                    BillId = table.Column<int>(type: "int", nullable: false),
                    totalAmount = table.Column<int>(type: "int", nullable: false),
                    totalPaid = table.Column<int>(type: "int", nullable: false),
                    totalChange = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    ShiftId = table.Column<int>(type: "int", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: true),
                    PaymentStatus = table.Column<int>(type: "int", nullable: false),
                    IsAutoComplete = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillDeleted", x => x.BillId);
                });

            migrationBuilder.CreateTable(
                name: "BillDetailDeleted",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    BillId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    UnitId = table.Column<int>(type: "int", nullable: false),
                    DiscountAmount = table.Column<int>(type: "int", nullable: false),
                    DiscountPercentage = table.Column<int>(type: "int", nullable: false),
                    DiscountByPercentage = table.Column<bool>(type: "bit", nullable: false),
                    Quantity = table.Column<float>(type: "real", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillDetailDeleted", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BillPaymentDeleted",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    BillId = table.Column<int>(type: "int", nullable: false),
                    PaymentMethodId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    PaymentStatus = table.Column<int>(type: "int", nullable: false),
                    PaymentTransactionRef = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillPaymentDeleted", x => x.Id);
                });

            migrationBuilder.Sql(@"
				CREATE OR ALTER PROC usp_delete_bill
				(
					@BillId INT,
					@UserId INT
				)
				AS
				BEGIN
					BEGIN TRY
						BEGIN TRAN

						INSERT INTO [dbo].[BillDetailDeleted]
							   ([Id]
							   ,[BillId]
							   ,[ProductId]
							   ,[UnitId]
							   ,[DiscountAmount]
							   ,[DiscountPercentage]
							   ,[DiscountByPercentage]
							   ,[Quantity]
							   ,[Amount]
							   ,[UserId])
						SELECT [Id]
							   ,[BillId]
							   ,[ProductId]
							   ,[UnitId]
							   ,[DiscountAmount]
							   ,[DiscountPercentage]
							   ,[DiscountByPercentage]
							   ,[Quantity]
							   ,[Amount]
							   ,@UserId
						 FROM dbo.BillDetails
						 WHERE BillId = @BillId

						 INSERT INTO [dbo].[BillPaymentDeleted]
							   ([Id]
							   ,[BillId]
							   ,[PaymentMethodId]
							   ,[Amount]
							   ,[PaymentStatus]
							   ,[PaymentTransactionRef]
							   ,[UserId])
						SELECT [Id]
							   ,[BillId]
							   ,[PaymentMethodId]
							   ,[Amount]
							   ,[PaymentStatus]
							   ,[PaymentTransactionRef]
							   ,@UserId
						FROM BillPayments
						WHERE BillId = @BillId

						INSERT INTO [dbo].[Bills]
							   ([totalAmount]
							   ,[totalPaid]
							   ,[totalChange]
							   ,[CustomerId]
							   ,[CreateDate]
							   ,[CreateBy]
							   ,[ModifyDate]
							   ,[ModifyBy]
							   ,[IsAutoComplete]
							   ,[PaymentStatus]
							   ,[ShiftId]
							   ,[BranchId])
						SELECT [totalAmount]
							   ,[totalPaid]
							   ,[totalChange]
							   ,[CustomerId]
							   ,[CreateDate]
							   ,[CreateBy]
							   ,[ModifyDate]
							   ,[ModifyBy]
							   ,[IsAutoComplete]
							   ,[PaymentStatus]
							   ,[ShiftId]
							   ,[BranchId]
						  FROM dbo.Bills
						  WHERE BillId = @BillId

						  DELETE BillDetails
						  WHERE BillId = @BillId

						  DELETE BillPayments
						  WHERE BillId = @BillId

						COMMIT
					END TRY
					BEGIN CATCH
						ROLLBACK
					END CATCH
				END");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BillDeleted");

            migrationBuilder.DropTable(
                name: "BillDetailDeleted");

            migrationBuilder.DropTable(
                name: "BillPaymentDeleted");
        }
    }
}
