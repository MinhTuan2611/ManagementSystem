using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagementSystem.AccountingApi.Migrations
{
    public partial class updateShiftReport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "TotalOtherAmount",
                table: "ShiftReports",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
            migrationBuilder.Sql(@"
				CREATE OR ALTER   PROCEDURE [dbo].[sp_shift_handovers]
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

					CREATE TABLE #tmp_records
					(
						ShiftEndId INT,
						TotalBill DECIMAL(18, 2)
					);

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
							INSERT INTO #tmp_records (ShiftEndId, TotalBill)
							SELECT sr.ShiftEndId
								,SUM(sd.Denomination * sd.Amount) AS TotalBill
							FROM dbo.ShiftEndReports sr
							LEFT JOIN dbo.ShiftHandoverCashDetails sD ON sd.ShiftEndId = sr.ShiftEndId
							JOIN dbo.ShiftHandovers sh ON sh.ShiftEndId = sr.ShiftEndId
							WHERE 1 = 1
							', @sqlQuery_condition,
							'GROUP BY sr.ShiftEndId

						'
					)

					EXEC(@sqlQuery)
					SELECT @TotalRecords = COUNT(1) FROM #tmp_records
					-- return result
					SET @sqlQuery = CONCAT('SELECT sh.HandoverId
								,t.ShiftEndId
								,es.ShiftId
								,es.ShiftName
								,sh.HandoverTime AS HandoverDate
								,t.TotalBill AS TotalAmount
								,COALESCE(s.TotalShiftInMoney, 0) AS CurShiftAmount
								,COALESCE(LAG(s.TotalShiftInMoney) OVER (ORDER BY sr.ShiftEndId), 0) AS PreShiftAmount
								,sr.BranchId
								,b.BranchCode
								,b.BranchName
						FROM #tmp_records t
						JOIN dbo.ShiftEndReports sr ON sr.ShiftEndId = t.ShiftEndId
						LEFT JOIN dbo.ShiftHandovers sh ON sh.ShiftEndId = sr.ShiftEndId
						LEFT JOIN AccountsDb.dbo.EmployeeShifts es ON es.ShiftId = sr.ShiftId
						LEFT JOIN dbo.ShiftReports s ON s.HandoverId = sh.HandoverId
						LEFT JOIN StoragesProdDb..Branches b ON sr.BranchId = b.BranchId
					', @orderBy, @pagingString)

					EXEC(@sqlQuery)
				END
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalOtherAmount",
                table: "ShiftReports");
        }
    }
}
