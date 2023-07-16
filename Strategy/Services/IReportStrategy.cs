using System.Collections;
using System.IO;

namespace Strategy.Services
{
    public interface IReportStrategy
    {
        void GenerateReport(IEnumerable data);
    }

    public class PdfReportStrategy : IReportStrategy
    {
        public void GenerateReport(IEnumerable data)
        {
            // Implementación de la generación del reporte en formato PDF usando iTextSharp
            using (var memoryStream = new MemoryStream())
            {
                var document = new Document(PageSize.A4, 25, 25, 25, 25);
                var writer = PdfWriter.GetInstance(document, memoryStream);
                document.Open();

                // Asumiendo que los datos son una colección de ViewModelDataPdf
                foreach (ViewModelDataPdf item in data)
                {
                    // Agregar contenido al documento PDF
                }

                document.Close();
                // Guardar o retornar el MemoryStream generado
            }
        }
    }

    public class ExcelReportStrategy : IReportStrategy
    {
        public void GenerateReport(IEnumerable data)
        {
            // Implementación de la generación del reporte en formato Excel usando SpreadsheetLight
            using (var sl = new SLDocument())
            {
                // Asumiendo que los datos son una colección de ViewModelDataExcel
                int rowIndex = 1;
                foreach (ViewModelDataExcel item in data)
                {
                    // Agregar contenido al documento Excel
                    sl.SetCellValue(rowIndex, 1, item.Field1);
                    sl.SetCellValue(rowIndex, 2, item.Field2);
                    // ...
                    rowIndex++;
                }

                // Guardar o retornar el SLDocument generado
            }
        }
    }
}