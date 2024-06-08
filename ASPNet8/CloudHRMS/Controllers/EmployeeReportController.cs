using CloudHRMS.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Reporting.NETCore;
using System.Text;

namespace CloudHRMS.Controllers
{
    public class EmployeeReportController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IEmployeeService _employeeService;
        private readonly IDepartmentService _departmentService;

        public EmployeeReportController(IWebHostEnvironment webHostEnvironment,IEmployeeService employeeService,IDepartmentService departmentService)
        {
            this._webHostEnvironment = webHostEnvironment;
            this._employeeService = employeeService;
            this._departmentService = departmentService;
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }
        public IActionResult ReportByEmployeeFromCodeToCode()
        {
            ViewBag.Departments = _departmentService.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult ReportByEmployeeFromCodeToCode(string fromCode,string toCode,string departmentId)
        {
            var employeeDetail = _employeeService.GetByFromCodeToCodeDepartmentId(fromCode, toCode, departmentId);
            /*Dictionary<string,string> parameters= new Dictionary<string,string>();
            parameters.Add("rpfromCode", fromCode);
            parameters.Add("rptoCode", toCode);
            parameters.Add("rpDepartmentName", _departmentService.GetByID(departmentId).Name);*/
            var rdlcPath = $"{_webHostEnvironment.WebRootPath}\\RdlcReportFile\\EmployeeDetailReport.rdlc";
            if (employeeDetail != null)
            {
                Stream reportDefinition=new FileStream(rdlcPath,FileMode.Open);
                IList<ReportParameter> parameters = new List<ReportParameter>();
                parameters.Add(new ReportParameter("rpfromCode", fromCode));
                parameters.Add(new ReportParameter("rptoCode", toCode));
                
                if("x".Equals(departmentId))
                {
                    parameters.Add(new ReportParameter("rpDepartmentName", "null"));
                }
                else
                {
                    parameters.Add(new ReportParameter("rpDepartmentName", _departmentService.GetByID(departmentId).Name));
                }

                LocalReport report = new LocalReport();
                report.LoadReportDefinition(reportDefinition);
                report.DataSources.Add(new ReportDataSource("EmployeeDetailDataSet", employeeDetail));
                /*report.SetParameters(new ReportParameter[3]
                {   new ReportParameter("rpfromCode", fromCode) ,
                    new ReportParameter("rptoCode", toCode) ,
                    new ReportParameter("rpDepartmentName", _departmentService.GetByID(departmentId).Name) });*/
                report.SetParameters(parameters);
                byte[] pdf = report.Render("PDF");
                return File(pdf, "application/pdf");
            }
            return View(employeeDetail);
        }
    }
}
