using System.Collections;

namespace Strategy.Services
{
    public class ReportGenerator
    {
        private IReportStrategy _reportStrategy;

        public ReportGenerator(IReportStrategy reportStrategy)
        {
            _reportStrategy = reportStrategy;
        }

        public void SetReportStrategy(IReportStrategy reportStrategy)
        {
            _reportStrategy = reportStrategy;
        }

        public void GenerateReport(IEnumerable data)
        {
            _reportStrategy.GenerateReport(data);
        }
    }
}