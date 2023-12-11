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
                CREATE OR ALTER PROCEDURE [dbo].[sp_search_customer_by_term]
                (
                    @searchTerm NVARCHAR(MAX)
                )
                AS
                BEGIN

                    DECLARE @SearchName NVARCHAR(255) = ''
                    DECLARE @SearchPhoneNumber NVARCHAR(10) = ''

                    SET @searchTerm = [dbo].[non_unicode_convert]( LTRIM(RTRIM(@searchTerm)))

                    IF LEN(@searchTerm) > 0
                    BEGIN

		                IF @searchTerm NOT LIKE '%[0-9]%'
		                BEGIN
			                SET @SearchName = @searchTerm
		                END
		                ELSE
		                BEGIN
			                -- Tách chuỗi thành tên và số điện thoại
			                SET @SearchName = 
							                CASE
								                WHEN PATINDEX('%[0-9]%', @searchTerm) > 0
								                THEN SUBSTRING(@searchTerm, 1, PATINDEX('%[0-9]%', @searchTerm) - 1)
								                ELSE @searchTerm
							                END
			                SET @SearchPhoneNumber =  CASE
										                WHEN PATINDEX('%[0-9]%', @searchTerm) > 0
										                THEN SUBSTRING(@searchTerm, PATINDEX('%[0-9]%', @searchTerm), LEN(@searchTerm))
										                ELSE NULL
									                END
		                END

                    END

	                SET @SearchName = LOWER(LTRIM(RTRIM(@SearchName)))

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
		                @SearchName = ''
		                OR CHARINDEX(' ' + @SearchName + ' ', ' ' + LOWER(CustomerUnsign) + ' ') > 0
		                OR PATINDEX('% ' + @SearchName + ' %', ' ' + LOWER(CustomerUnsign) + ' ') > 0
		                )
		                AND
		                (
		                @SearchPhoneNumber = ''
		                OR LTRIM(RTRIM(Phonenumber)) LIKE '%' + CONVERT(nvarchar(20), LTRIM(RTRIM(@SearchPhoneNumber)))
		                )
					  
                END

            ");
            migrationBuilder.Sql(@"
                                    CREATE OR ALTER   PROCEDURE [dbo].[sp_SearchBills]
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

    					                INSERT INTO #web_column_mapping VALUES('FromDate', 'FORMAT(b.CreateDate, ''yyyy-MM-dd'')', '>=')
    					                INSERT INTO #web_column_mapping VALUES('ToDate', 'FORMAT(b.CreateDate, ''yyyy-MM-dd'')', '<=')

    					                SELECT @sqlQuery_condition = CONCAT(@sqlQuery_condition,+ ' AND '
    										                + col_map.DB_COLUMN_ALIAS
    										                + col_map.DB_COLUMN_OPERATION
    										                + '''' + xml_parsed.[Value] + ''''
    										                + (CHAR(10)) )
    					                FROM @SearchCriteriaTable xml_parsed
    					                JOIN #web_column_mapping col_map ON xml_parsed.[Key] = col_map.WEB_COLUMN
    					                WHERE xml_parsed.[Key] NOT IN ('CustomerName', 'BillId')


    					                IF EXISTS (SELECT 1 FROM @SearchCriteriaTable WHERE [Key] = 'CustomerName')
    					                BEGIN
    						                SELECT @sqlQuery_condition = CONCAT (@sqlQuery_condition, ' AND ',
    							                'c.CustomerName LIKE N'''+'%' +xml_parsed.[Value]+ '%' + '''')
    						                FROM @SearchCriteriaTable xml_parsed
    						                WHERE xml_parsed.[Key] = 'CustomerName'
    					                END


    					                IF EXISTS (SELECT 1 FROM @SearchCriteriaTable WHERE [Key] = 'BillId')
    					                BEGIN
    						                SELECT @sqlQuery_condition = CONCAT (@sqlQuery_condition, ' AND ',
    							                'CONVERT(VARCHAR(12), b.BillId) LIKE '''+'%' +xml_parsed.[Value]+ '%' + '''')
    						                FROM @SearchCriteriaTable xml_parsed
    						                WHERE xml_parsed.[Key] = 'BillId'
    					                END

    					                -- Create a temporary table
    					                CREATE TABLE #tmp_records
    					                (
    						                BillId INT,
    						                totalAmount INT,
    						                totalPaid INT,
    						                totalChange INT,
    						                CustomerId INT,
    						                UserId INT,
    						                UserName NVARCHAR(255),
    						                ShiftId INT,
    						                ShiftName NVARCHAR(255),
    						                BranchId INT,
    						                BranchName NVARCHAR(255),
    						                CreateDate DATETIME,
    						                CustomerName NVARCHAR(255),
							                CustomerCode VARCHAR(255)
    					                )

    					                -- Return result
    					                SET @sqlQuery = CONCAT('
    								                INSERT INTO #tmp_records
    								                SELECT DISTINCT b.BillId
    									                ,b.totalAmount
    									                ,b.totalPaid
    									                ,b.totalChange
    									                ,b.CustomerId
    									                ,u.UserId
    									                ,u.UserName
    									                ,s.ShiftId
    									                ,s.ShiftName
    									                ,bc.BranchId
    									                ,bc.BranchName
    									                ,b.CreateDate
    									                , c.CustomerName
										                , c.CustomerCode
    							                FROM dbo.Bills b
    							                LEFT JOIN dbo.Customers c ON b.CustomerId = c.CustomerId
    							                LEFT JOIN AccountsDb.dbo.Users u ON b.CreateBy = u.UserId
    							                LEFT JOIN AccountsDb.dbo.EmployeeShifts s ON s.ShiftId = b.ShiftId
    							                LEFT JOIN AccountsDb.dbo.UserBranchs ub ON ub.UserId = u.UserId
    							                LEFT JOIN dbo.Branches bc ON ub.BranchId = bc.BranchId
    						                WHERE 1 = 1
    					                ', @sqlQuery_condition)

    					                EXEC (@sqlQuery)
    					                SELECT @TotalRecords = COUNT(1) FROM #tmp_records
    					
    					                SELECT *
    					                FROM #tmp_records
    					                ORDER BY CreateDate DESC
    					                OFFSET (@PageNumber - 1) * @PageSize ROWS FETCH NEXT @pageSize ROWS ONLY
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
