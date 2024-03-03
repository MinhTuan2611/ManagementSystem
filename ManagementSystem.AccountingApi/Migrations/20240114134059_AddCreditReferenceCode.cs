using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagementSystem.AccountingApi.Migrations
{
    public partial class AddCreditReferenceCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PaymentMenthodReasonRefs",
                columns: table => new
                {
                    MethodCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ReasonCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMenthodReasonRefs", x => new { x.MethodCode, x.ReasonCode });
                });
            migrationBuilder.Sql(@"
                IF NOT EXISTS (SELECT TOP 1 * FROM PaymentMenthodReasonRefs)
                BEGIN
	                INSERT INTO PaymentMenthodReasonRefs(MethodCode,ReasonCode)
	                VALUES ('CARD', 'TCK'), ('BANKING', 'TIEUDUNG'), ('MOMO', 'MOMO'), ('ZALO', 'BC017'), ('POINT', 'DOIDIEM')
			                ,('OTHER', 'TIEUDUNG'), ('VNPAY', 'BCDT02'), ('SAMSUNG', 'TIEUDUNG'), ('DISCOUNT', 'TMH')
			                ,('CONGNO', 'CONGNO'),('FUNDIIN', 'TIEUDUNG')
                END
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaymentMenthodReasonRefs");
        }
    }
}
