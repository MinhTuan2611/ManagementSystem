using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagementSystem.StoragesApi.Migrations
{
    public partial class AddStoreSearchCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreditAccount",
                table: "Requests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreditAmount",
                table: "Requests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DebitAccount",
                table: "Requests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DebitAmount",
                table: "Requests",
                type: "int",
                nullable: true);

            migrationBuilder.Sql(@"
                CREATE OR ALTER PROC sp_search_customer_by_term
                (
	                @searchTerm NVARCHAR(MAX)
                )
                AS
                BEGIN
	                DROP TABLE IF EXISTS #tempSearchs
	                SELECT *
			                ,CASE
				                WHEN PhoneNumber = '1234567890' THEN CustomerName
				                WHEN COALESCE(PhoneNumber, '') = '' THEN CustomerName
				                ELSE CONCAT(CustomerName, ' - ', SUBSTRING(PhoneNumber,LEN(PhoneNumber) - 3, 3))
			                END AS SearchString
	                INTO #tempSearchs
	                FROM customers

	                SELECT top 10 [CustomerId]
		                  ,[CustomerCode]
		                  ,[CustomerName]
		                  ,[CustomerPoint]
		                  ,[Address]
		                  ,[BirthDay]
		                  ,[Gender]
		                  ,[PhoneNumber]
		                  ,SearchString
	                FROM #tempSearchs
	                WHERE  SearchString Like N'%'+@searchTerm+'%'
                END
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreditAccount",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "CreditAmount",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "DebitAccount",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "DebitAmount",
                table: "Requests");
        }
    }
}
