using CloudHRMS.Models.ViewModels;
using CloudHRMS.ReportHelper.DataSet;

namespace CloudHRMS.Services
{
    public interface IEmployeeService
    {
        IList<DepartmentViewModel> GetDepartments();

        IList<PositionViewModel> GetPositions();
        void Create(EmployeeViewModel employeeViewModel);
        IList<EmployeeViewModel> GetAll();

        EmployeeViewModel GetByID(string id);

        void Update(EmployeeViewModel employeeViewModel);

        void Delete(string Id);

        IList<EmployeeDetail> GetByFromCodeToCodeDepartmentId(string fromCode, string toCode, string DepartmentId);
    }
}
