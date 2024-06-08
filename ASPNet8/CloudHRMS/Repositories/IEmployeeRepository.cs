using CloudHRMS.Models.DataModels;

namespace CloudHRMS.Repositories
{
    public interface IEmployeeRepository
    {
        IList<DepartmentEntity> GetDepartments();

        IList<PositionEntity> GetPositions();
        void Create(EmployeeEntity employeeEntity);
        IList<EmployeeEntity> GetAll();
        EmployeeEntity GetById(string id);
        void Update(EmployeeEntity employeeEntity);

        void Delete(string id);
    }
}
