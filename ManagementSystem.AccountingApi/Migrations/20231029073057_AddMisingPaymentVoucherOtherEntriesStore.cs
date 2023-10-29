using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagementSystem.AccountingApi.Migrations
{
    public partial class AddMisingPaymentVoucherOtherEntriesStore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.Sql(@"
			CREATE OR ALTER PROCEDURE dbo.sp_SearchPaymentVouchers
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
					Address NVARCHAR(255),
					EmployeeName NVARCHAR(255),
					EmployeeId INT,
					ReceiverName NVARCHAR(255),
					Description NVARCHAR(255),
					Reason NVARCHAR(255),
					TotalMoneyVND INT,
					ExchangeRate INT,
					NTMoney INT,
					DocumentNumber INT,
					TransactionDate DATETIME
				);

				-- Return result
				SET @sqlQuery = CONCAT('
					INSERT INTO #tmp_records
                    SELECT b.BranchCode
		                    ,b.BranchName
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
		GO

		");

		migrationBuilder.Sql(@"
			CREATE OR ALTER PROCEDURE dbo.sp_SearchOtherEntries
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

							INSERT INTO #web_column_mapping VALUES('FromDate', 'FORMAT(oe.TransactionDate, ''yyyy-MM-dd'')', '>=')
							INSERT INTO #web_column_mapping VALUES('ToDate', 'FORMAT(oe.TransactionDate, ''yyyy-MM-dd'')', '<=')

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
								Address NVARCHAR(255),
								PayerName NVARCHAR(255),
								CustomerName NVARCHAR(255),
								PaymentDescription NVARCHAR(255),
								Reason NVARCHAR(255),
								EmployeeName NVARCHAR(255),
								EmployeeId INT,
								Amount INT,
								AccountId INT,
								DocumentNumber NVARCHAR(255),
								Note NVARCHAR(255)
							);

							-- Return result
							SET @sqlQuery = CONCAT('
								INSERT INTO #tmp_records
								SELECT b.BranchCode
										,b.BranchName
										,b.[Address]
										,c.CustomerName AS PayerName
										,c.CustomerName
										,oe.PaymentDescription
										,oe.Reason
										,CONCAT(u.FirstName, '' '', u.LastName) AS EmployeeName
										,u.UserId AS EmployeeId
										,oe.Amount
										,oe.AccountId
										,oe.DocumentNumber
										,oe.Note
								FROM OtherAccountEntries oe
								LEFT JOIN StoragesDb.dbo.Branches b ON oe.BrandId = b.BranchId
								LEFT JOIN StoragesDb.dbo.Customers c ON c.CustomerId = oe.CustomerId
								LEFT JOIN AccountsDB.dbo.Users u ON oe.UserId = u.UserId
								WHERE 1 = 1
							', @sqlQuery_condition)

							EXEC (@sqlQuery)
				
							SELECT @TotalRecords = COUNT(1) FROM #tmp_records
				
							SELECT *
							FROM #tmp_records
							ORDER BY DocumentNumber DESC
							OFFSET (@PageNumber - 1) * @PageSize ROWS FETCH NEXT @pageSize ROWS ONLY
						END
			GO

		");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
