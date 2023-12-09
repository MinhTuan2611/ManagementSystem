using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagementSystem.StoragesApi.Migrations
{
    public partial class UpdateCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomerUnsign",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.Sql(@"
                GO
                CREATE OR ALTER TRIGGER tr_customer_insert_searching_text ON dbo.Customers AFTER INSERT AS
                BEGIN
	                UPDATE p
	                SET CustomerUnsign = [dbo].[non_unicode_convert](p.CustomerName)
	                FROM Customers p
	                JOIN inserted ON p.CustomerId = inserted.CustomerId
                END
                GO

                CREATE OR ALTER TRIGGER tr_customer_update_searching_text ON dbo.Customers AFTER UPDATE AS
                BEGIN
	                UPDATE p
	                SET CustomerUnsign = [dbo].[non_unicode_convert](p.CustomerName)
                        , ModifyDate = GETDATE()
	                FROM Customers p
	                JOIN inserted ON p.CustomerId = inserted.CustomerId
                END
                GO
            ");

             migrationBuilder.Sql(@"
             CREATE OR ALTER  PROC [dbo].[sp_search_customer_by_term]
              (
                  @searchTerm NVARCHAR(MAX)
              )
              AS
              BEGIN

                  DECLARE @SearchName NVARCHAR(255) = ''
                  DECLARE @SearchPhoneNumber NVARCHAR(10) = ''
                  DECLARE @SearchNameUnsign NVARCHAR(255) = ''

                  SET @searchTerm = LTRIM(RTRIM(@searchTerm))

                  IF LEN(@searchTerm) > 0
                  BEGIN

                  -- Tách chuỗi thành tên và số điện thoại
                  SET @SearchName = LEFT(@searchTerm, ISNULL(NULLIF(CHARINDEX(' ', @searchTerm + ' '), 0) - 1, LEN(@searchTerm)))
                  SET @SearchPhoneNumber = RIGHT(@searchTerm, ISNULL(NULLIF(CHARINDEX(' ', REVERSE(@searchTerm) + ' '), 0) - 1, LEN(@searchTerm)))
                  END

                  SET @SearchPhoneNumber = IIF(ISNUMERIC(@SearchName) = 1 AND LEN(@SearchPhoneNumber) <= 0
			                    , @SearchName , IIF(ISNUMERIC(@SearchPhoneNumber) = 1, @SearchPhoneNumber, '' ))
                  SET @SearchNameUnsign = IIF(@SearchName = @SearchPhoneNumber, '' ,[dbo].[non_unicode_convert](@SearchName))

                  SELECT [CustomerId]
 		                    ,[CustomerCode]
 		                    ,[CustomerName]
 		                    ,[CustomerPoint]
 		                    ,[Address]
 		                    ,[BirthDay]
 		                    ,[Gender]
 		                    ,[PhoneNumber]
                  FROM customers
                  WHERE (
						@SearchNameUnsign = ''
						OR CHARINDEX(' ' + LOWER(@SearchNameUnsign) + ' ', ' ' + LOWER(CustomerUnsign) + ' ') > 0
						OR PATINDEX('% ' + LOWER(@SearchNameUnsign) + ' %', ' ' + LOWER(CustomerUnsign) + ' ') > 0
					  )
					  AND
					  (
						@SearchPhoneNumber = ''
						OR LTRIM(RTRIM(Phonenumber)) LIKE '%' + CONVERT(nvarchar(20), @SearchPhoneNumber)
					  )
              END
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerUnsign",
                table: "Customers");
        }
    }
}
