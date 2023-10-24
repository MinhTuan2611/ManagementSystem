using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagementSystem.AccountingApi.Migrations
{
    public partial class AddViewGetData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "TotalMoneyBeforeTax",
                table: "InventoryVoucherDetails",
                type: "real",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "Quantity",
                table: "InventoryVoucherDetails",
                type: "real",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.Sql(@"
				CREATE OR ALTER PROCEDURE dbo.sp_SearchShiftEndReports
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

					INSERT INTO #web_column_mapping VALUES('FromDate', 'FORMAT(s.ShiftEndDate, ''yyyy-MM-dd'')', '>=')
					INSERT INTO #web_column_mapping VALUES('ToDate', 'FORMAT(s.ShiftEndDate, ''yyyy-MM-dd'')', '<=')

					SELECT @sqlQuery_condition = CONCAT(@sqlQuery_condition,+ ' AND '
										+ col_map.DB_COLUMN_ALIAS
										+ col_map.DB_COLUMN_OPERATION
										+ '''' + xml_parsed.[Value] + ''''
										+ (CHAR(10)) )
					FROM @SearchCriteriaTable xml_parsed
					JOIN #web_column_mapping col_map ON xml_parsed.[Key] = col_map.WEB_COLUMN

					-- Handle Pagination
					SET @pagingString = CONCAT(@pagingString,' 
														OFFSET ', CONVERT(NVARCHAR(30), @PageNumber - 1), '*', CONVERT(NVARCHAR(30),@pageSize), ' ROWS 
														FETCH NEXT ', CONVERT(NVARCHAR(30), @pageSize), ' ROWS ONLY ')
					-- Handle OrderBy
					SET @orderBy = 'ORDER BY s.ShiftEndDate DESC'

					-- Return result
					SET @sqlQuery = CONCAT('Q
						   SELECT s.ShiftEndId
								,s.UserId
								,u.UserName
								,es.ShiftId
								,es.ShiftName
								,s.ShiftEndDate
								,s.CompanyMoneyTransferred
								,sh.Denomination
								,sh.Amount
								,sa.ProductId
								   ,p.ProductName
								,ui.UnitId
								,ui.UnitName
								,sa.ActualAmount
								,sa.SystemAmount
						   FROM dbo.ShiftEndReports s
						   LEFT JOIN dbo.InventoryAuditDetails sa ON sa.ShiftEndId = s.ShiftEndId
						   LEFT JOIN dbo.ShiftHandoverCashDetails sh ON sh.ShiftEndId = s.ShiftEndId
						   LEFT JOIN AccountsDb.dbo.Users u ON u.UserId = s.UserId
						   LEFT JOIN AccountsDb.dbo.EmployeeShifts es ON es.ShiftId = s.ShiftId
						   LEFT JOIN StoragesDb.dbo.Products p ON p.ProductId = sa.ProductId
						   LEFT JOIN StoragesDb.dbo.Unit ui ON sa.UnitId = ui.UnitId
						   WHERE 1 = 1
					', @sqlQuery_condition, @orderBy, @pagingString)

					EXEC (@sqlQuery)
				END

            
				GO

            ");

            migrationBuilder.Sql(@"
                CREATE OR ALTER VIEW dbo.ShiftEndReportView_latest
                AS
                WITH cte
                AS
                (
	                SELECT MAX(ShiftEndId) AS ShiftEndId
	                FROM dbo.ShiftEndReports 
                )
                SELECT s.ShiftEndId
		                ,s.UserId
		                ,u.UserName
		                ,es.ShiftId
		                ,es.ShiftName
		                ,s.ShiftEndDate
		                ,s.CompanyMoneyTransferred
		                ,sh.Denomination
		                ,sh.Amount
		                ,sa.ProductId
                        ,p.ProductName
		                ,ui.UnitId
		                ,ui.UnitName
		                ,sa.ActualAmount
		                ,sa.SystemAmount
                FROM cte 
                JOIN dbo.ShiftEndReports s ON s.ShiftEndId = cte.ShiftEndId
                LEFT JOIN dbo.InventoryAuditDetails sa ON sa.ShiftEndId = s.ShiftEndId
                LEFT JOIN dbo.ShiftHandoverCashDetails sh ON sh.ShiftEndId = s.ShiftEndId
                LEFT JOIN AccountsDb.dbo.Users u ON u.UserId = s.UserId
                LEFT JOIN AccountsDb.dbo.EmployeeShifts es ON es.ShiftId = s.ShiftId
                LEFT JOIN StoragesDb.dbo.Products p ON p.ProductId = sa.ProductId
                LEFT JOIN StoragesDb.dbo.Unit ui ON sa.UnitId = ui.UnitId
            ");

			migrationBuilder.Sql(@"
					CREATE OR ALTER PROCEDURE dbo.sp_shift_handovers
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

						INSERT INTO #web_column_mapping VALUES('FromDate', 'FORMAT(sh.HandoverTime, ''yyyy-MM-dd'')', '>=')
						INSERT INTO #web_column_mapping VALUES('ToDate', 'FORMAT(sh.HandoverTime, ''yyyy-MM-dd'')', '<=')

						SELECT @sqlQuery_condition = CONCAT(@sqlQuery_condition,+ ' AND '
											+ col_map.DB_COLUMN_ALIAS
											+ col_map.DB_COLUMN_OPERATION
											+ '''' + xml_parsed.[Value] + ''''
											+ (CHAR(10)) )
						FROM @SearchCriteriaTable xml_parsed
						JOIN #web_column_mapping col_map ON xml_parsed.[Key] = col_map.WEB_COLUMN

						-- Handle Pagination
						SET @pagingString = CONCAT(@pagingString,' 
															OFFSET ', CONVERT(NVARCHAR(30), @PageNumber - 1), '*', CONVERT(NVARCHAR(30),@pageSize), ' ROWS 
															FETCH NEXT ', CONVERT(NVARCHAR(30), @pageSize), ' ROWS ONLY ')
						-- Handle OrderBy
						SET @orderBy = 'ORDER BY sh.HandoverTime DESC'

						-- Return result
						SET @sqlQuery = CONCAT('
							;WITH cte
							AS
							(
								SELECT sr.ShiftEndId
									,SUM(sd.Denomination * sd.Amount) AS TotalBill
								FROM dbo.ShiftEndReports sr
								JOIN dbo.ShiftHandoverCashDetails sD ON sd.ShiftEndId = sr.ShiftEndId
								JOIN dbo.ShiftHandovers sh ON sh.ShiftEndId = sr.ShiftEndId
								WHERE 1 = 1
								', @sqlQuery_condition,
								'GROUP BY sr.ShiftEndId
							)

							SELECT sh.HandoverId
									,es.ShiftId
									,es.ShiftName
									,sh.HandoverTime AS HandoverDate
									,t.TotalBill AS TotalAmount
									,s.TotalShiftInMoney AS CurShiftAmount
									,LAG(s.TotalShiftInMoney) OVER (ORDER BY sr.ShiftEndId) AS PreShiftAmount
							FROM cte t
							JOIN dbo.ShiftEndReports sr ON sr.ShiftEndId = t.ShiftEndId
							JOIN dbo.ShiftHandovers sh ON sh.ShiftEndId = sr.ShiftEndId
							JOIN AccountsDb.dbo.EmployeeShifts es ON es.ShiftId = sr.ShiftId
							JOIN dbo.ShiftReports s ON s.HandoverId = sh.HandoverId
						', @orderBy, @pagingString)

						EXEC (@sqlQuery)
					END
					GO");

			migrationBuilder.Sql(@"
				CREATE OR ALTER PROCEDURE dbo.sp_SearchLegers
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

					-- Create a temporary table
					DROP TABLE IF EXISTS #tmp_records
					CREATE TABLE #tmp_records (
						TransactionDate DATETIME,
						CreditAccount VARCHAR(200),
						DepositAccount VARCHAR(200),
						DoccumentType NVARCHAR(255),
						DoccumentNumber INT,
						BillId INT,
						CustomerId INT,
						CustomerName NVARCHAR(255),
						Amount INT
					);

					-- Return result
					SET @sqlQuery = CONCAT('
						INSERT INTO #tmp_records
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TotalMoneyBeforeTax",
                table: "InventoryVoucherDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "InventoryVoucherDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);
        }
    }
}
