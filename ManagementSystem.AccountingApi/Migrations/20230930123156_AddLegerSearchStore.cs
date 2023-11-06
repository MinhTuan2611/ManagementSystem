using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagementSystem.AccountingApi.Migrations
{
    public partial class AddLegerSearchStore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
				CREATE OR ALTER  PROCEDURE [dbo].[sp_SearchLegers]
					@xmlString NVARCHAR(MAX)
					,@pageNumber INT = 1
					,@pageSize INT = 10
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

					-- Return result
					SET @sqlQuery = CONCAT('
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
					', @sqlQuery_condition, @orderBy, @pagingString)

					EXEC (@sqlQuery)
				END
            ");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS [dbo].[sp_SearchLegers]");
        }
    }
}
