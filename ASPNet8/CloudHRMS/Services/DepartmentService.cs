using CloudHRMS.Models.DataModels;
using CloudHRMS.Models.ViewModels;
using CloudHRMS.Repositories;

namespace CloudHRMS.Services
{
    public class DepartmentService : IDepartmentService
    {

        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            this._departmentRepository = departmentRepository;
        }
        public void Create(DepartmentViewModel departmentViewModel)
        {
            try
            {
                var isDepartmentCodeAlreadyExits = _departmentRepository.GetAll().Where(w => w.Code == departmentViewModel.Code).Any();
                if (isDepartmentCodeAlreadyExits)
                {
                    throw new Exception("Code already existsint the System");
                }
                else
                {
                    var department = new DepartmentEntity()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Code = departmentViewModel.Code,
                        Name = departmentViewModel.Name,
                        ExtensionPhone = departmentViewModel.ExtensionPhone
                    };
                    _departmentRepository.Create(department);
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public void Delete(string Id)
        {
            _departmentRepository.Delete(Id);
        }

        public IList<DepartmentViewModel> GetAll()
        {
            return _departmentRepository.GetAll().Select(
                 s => new DepartmentViewModel
                 {
                     Id = s.Id,
                     Code = s.Code,
                     Name = s.Name,
                     ExtensionPhone = s.ExtensionPhone,
                     //TotalEmployeeCount = _departmentRepository.Employees.Where(e => e.DepartmentId == s.Id).Count()
                 }).ToList();
        }

        public DepartmentViewModel GetByID(string id)
        {
            var departmentEntity = _departmentRepository.GetById(id);
            return new DepartmentViewModel()
            {
                Id = departmentEntity.Id,
                Name = departmentEntity.Name,
                Code = departmentEntity.Code,
                ExtensionPhone = departmentEntity.ExtensionPhone

            };
        }

        public void Update(DepartmentViewModel departmentViewModel)
        {
            try
            {
                var department = new DepartmentEntity()
                {
                    Id = departmentViewModel.Id,
                    Code = departmentViewModel.Code,
                    Name = departmentViewModel.Name,
                    ExtensionPhone = departmentViewModel.ExtensionPhone,
                    ModifiedAt = DateTime.Now

                };
                _departmentRepository.Update(department);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
