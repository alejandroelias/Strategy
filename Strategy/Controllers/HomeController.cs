using Strategy.Services;
using System.Net;
using System.Web.Mvc;

namespace Strategy.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult GenerateReport(string format)
        {
            // Obtener datos para el reporte usando el patrón Unit of Work
            IEnumerable data;
            if (format == "pdf")
            {
                data = _unitOfWork.ViewModelDataPdfRepository.Get();
            }
            else if (format == "excel")
            {
                data = _unitOfWork.ViewModelDataExcelRepository.Get();
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Formato de reporte no soportado");
            }

            // Crear el generador de reportes con la estrategia apropiada

            IReportStrategy reportStrategy;
            if (format == "pdf")
            {
                reportStrategy = new PdfReportStrategy();
            }
            else if (format == "excel")
            {
                reportStrategy = new ExcelReportStrategy();
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Formato de reporte no soportado");
            }

            var reportGenerator = new ReportGenerator(reportStrategy);
            reportGenerator.GenerateReport(data);

            // Retornar el archivo generado al usuario
            // ...
        }
    }
}