using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagementSystem.StoragesApi.Migrations
{
    public partial class UpdateSearchingWithUnSign : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductUnSignSearching",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
            migrationBuilder.Sql(@"
                CREATE OR ALTER FUNCTION [dbo].[non_unicode_convert](@inputVar NVARCHAR(MAX) )
                RETURNS NVARCHAR(MAX)
                AS
                BEGIN    
                    IF (@inputVar IS NULL OR @inputVar = '')  RETURN ''
   
                    DECLARE @RT NVARCHAR(MAX)
                    DECLARE @SIGN_CHARS NCHAR(256)
                    DECLARE @UNSIGN_CHARS NCHAR (256)
 
                    SET @SIGN_CHARS = N'ăâđêôơưàảãạáằẳẵặắầẩẫậấèẻẽẹéềểễệếìỉĩịíòỏõọóồổỗộốờởỡợớùủũụúừửữựứỳỷỹỵýĂÂĐÊÔƠƯÀẢÃẠÁẰẲẴẶẮẦẨẪẬẤÈẺẼẸÉỀỂỄỆẾÌỈĨỊÍÒỎÕỌÓỒỔỖỘỐỜỞỠỢỚÙỦŨỤÚỪỬỮỰỨỲỶỸỴÝ' + NCHAR(272) + NCHAR(208)
                    SET @UNSIGN_CHARS = N'aadeoouaaaaaaaaaaaaaaaeeeeeeeeeeiiiiiooooooooooooooouuuuuuuuuuyyyyyAADEOOUAAAAAAAAAAAAAAAEEEEEEEEEEIIIIIOOOOOOOOOOOOOOOUUUUUUUUUUYYYYYDD'
 
                    DECLARE @COUNTER int
                    DECLARE @COUNTER1 int
   
                    SET @COUNTER = 1
                    WHILE (@COUNTER <= LEN(@inputVar))
                    BEGIN  
                        SET @COUNTER1 = 1
                        WHILE (@COUNTER1 <= LEN(@SIGN_CHARS) + 1)
                        BEGIN
                            IF UNICODE(SUBSTRING(@SIGN_CHARS, @COUNTER1,1)) = UNICODE(SUBSTRING(@inputVar,@COUNTER ,1))
                            BEGIN          
                                IF @COUNTER = 1
                                    SET @inputVar = SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@inputVar, @COUNTER+1,LEN(@inputVar)-1)      
                                ELSE
                                    SET @inputVar = SUBSTRING(@inputVar, 1, @COUNTER-1) +SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@inputVar, @COUNTER+1,LEN(@inputVar)- @COUNTER)
                                BREAK
                            END
                            SET @COUNTER1 = @COUNTER1 +1
                        END
                        SET @COUNTER = @COUNTER +1
                    END
                    -- SET @inputVar = replace(@inputVar,' ','-')
                    RETURN @inputVar
                END");

            migrationBuilder.Sql(@"
                GO
                CREATE OR ALTER TRIGGER tr_product_insert_searching_text ON dbo.Products AFTER INSERT AS
                BEGIN
	                UPDATE p
	                SET ProductUnSignSearching = CONCAT(p.BarCode, '-', [dbo].[non_unicode_convert](p.ProductName))
	                FROM Products p
	                JOIN inserted ON p.ProductId = inserted.ProductId
                END
                GO

                CREATE OR ALTER TRIGGER tr_product_update_searching_text ON dbo.Products AFTER UPDATE AS
                BEGIN
	                UPDATE p
	                SET ProductUnSignSearching = CONCAT(p.BarCode, '-', [dbo].[non_unicode_convert](p.ProductName))
                        , ModifyDate = GETDATE()
	                FROM Products p
	                JOIN inserted ON p.ProductId = inserted.ProductId
                END
                GO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductUnSignSearching",
                table: "Products");
        }
    }
}
