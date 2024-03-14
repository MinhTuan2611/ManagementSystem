using Spire.Xls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Common.Helpers
{
    public class ExcelImportHelper
    {
        public static void ConvertXlsToXlsx(string sourcePath, string destinationPath)
        {
            // Load the .xls file
            Workbook workbook = new Workbook();
            workbook.LoadFromFile(sourcePath, ExcelVersion.Version97to2003);

            // Save the workbook as .xlsx
            workbook.SaveToFile(destinationPath, ExcelVersion.Version2013);
        }
    }
}
