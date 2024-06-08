using CloudHRMS.Models.ViewModels;

namespace CloudHRMS.Services
{
    public interface IDepartmentService
    {
        void Create(DepartmentViewModel departmentViewModel);
        IList<DepartmentViewModel> GetAll();

        DepartmentViewModel GetByID(string id);

        void Update(DepartmentViewModel departmentViewModel);

        void Delete(string Id);
    }
}
