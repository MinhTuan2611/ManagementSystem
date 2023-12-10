using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagementSystem.AccountingApi.Migrations
{
    public partial class UpdatePaymentVoucher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BranchCode",
                table: "PaymentVouchers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BranchName",
                table: "PaymentVouchers",
                type: "nvarchar(max)",
                nullable: true);
            migrationBuilder.Sql(@"
                CREATE OR ALTER   PROCEDURE [dbo].[sp_SearchPaymentVouchers]
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

    				-- Create a temporary table
    				CREATE TABLE #tmp_records
    				(
    					BranchCode NVARCHAR(255),
    					BranchName NVARCHAR(255),
						BranchId INT,
    					Address NVARCHAR(255),
    					EmployeeName NVARCHAR(255),
    					EmployeeId INT,
    					ReceiverName NVARCHAR(255),
    					Description NVARCHAR(255),
    					Reason NVARCHAR(255),
    					TotalMoneyVND BIGINT,
    					ExchangeRate INT,
    					NTMoney BIGINT,
    					DocumentNumber INT,
    					TransactionDate DATETIME,
    					DebitAccount NVARCHAR(128),
    					CreditAccount NVARCHAR(128)
    				);

    				-- Return result
    				SET @sqlQuery = CONCAT('
    					INSERT INTO #tmp_records
                        SELECT IIF(COALESCE(pv.BranchCode, '''') <> '''', pv.BranchCode, b.BranchCode) AS BranchCode
								,IIF(COALESCE(pv.BranchName, '''') <> '''', pv.BranchName, b.BranchName) AS BranchName
								,b.BranchId
    		                    ,b.[Address]
    		                    ,CONCAT(u.FirstName, '' '', u.LastName) AS EmployeeName
    		                    ,u.UserId AS EmployeeId
    		                    ,pv.ReceiverName
    		                    ,pv.Description
    		                    ,pv.Reason
    		                    ,pv.TotalMoneyVND
    		                    ,pv.ExchangeRate
    		                    ,pv.NTMoney
                                ,pv.DocumentNumber
                                ,pv.TransactionDate
    							,pv.DebitAccount
    							,pv.CreditAccount
                        FROM PaymentVouchers pv
                        LEFT JOIN StoragesDb.dbo.Branches b ON pv.BranchId = b.BranchId
                        LEFT JOIN AccountsDb.dbo.Users u ON pv.UserId = u.UserId
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
                name: "BranchCode",
                table: "PaymentVouchers");

            migrationBuilder.DropColumn(
                name: "BranchName",
                table: "PaymentVouchers");
        }
    }
}
