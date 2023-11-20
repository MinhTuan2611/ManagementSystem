using OfficeOpenXml;

namespace ManagementSystem.AccountingApi.Repositories.GenericRepository
{
    public class ExcelExporter
    {
        public void ExportToExcel<T>(IEnumerable<T> data, string[] headers, string filePath)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Sheet1");

                // Set headers
                for (int i = 0; i < headers.Length; i++)
                {
                    worksheet.Cells[1, i + 1].Value = headers[i];
                }

                // Add data
                int row = 2;
                foreach (var item in data)
                {
                    var properties = typeof(T).GetProperties();
                    for (int i = 0; i < properties.Length; i++)
                    {
                        object value = properties[i].GetValue(item);

                        // Check if the property is of type DateTime and format it
                        if (value is DateTime dateTimeValue)
                        {
                            worksheet.Cells[row, i + 1].Value = dateTimeValue.ToString("dd/MM/yyyy");
                        }
                        else
                        {
                            worksheet.Cells[row, i + 1].Value = value;
                        }
                    }
                    row++;
                }

                // Save the Excel package to a stream
                using (var stream = new MemoryStream())
                {
                    package.SaveAs(stream);

                    // Set the position to the beginning of the stream
                    stream.Position = 0;

                    // Save the stream to a file
                    File.WriteAllBytes(filePath, stream.ToArray());

                    Console.WriteLine($"Excel file exported at: {filePath}");
                }
            }
        }
    }
}
