using CloudHRMS.DAO;
using CloudHRMS.Models.DataModels;
using CloudHRMS.Models.ViewModels;
using CloudHRMS.ReportHelper.DataSet;
using CloudHRMS.Repositories;
using CloudHRMS.Repostories;

namespace CloudHRMS.Services
{
    public class EmployeeService : IEmployeeService
    {

        private readonly IEmployeeRepository _employeeRepository;
        private readonly IPositionRepository _positionRepository;
        private readonly IDepartmentRepository _departmentRepository;

        public EmployeeService(IEmployeeRepository employeeRepository,IPositionRepository positionRepository,IDepartmentRepository departmentRepository)
        {
            this._employeeRepository = employeeRepository;
            this._positionRepository = positionRepository;
            this._departmentRepository = departmentRepository;
        }
        public void Create(EmployeeViewModel employeeViewModel)
        {

            var IsValidCode = _employeeRepository.GetAll().Where(w => w.Code == employeeViewModel.Code).Any();
            if (IsValidCode)
            {
                throw new Exception("Employee Code already existsint the System");

            }
            var IsValidEmail = _employeeRepository.GetAll().Where(w => w.Email == employeeViewModel.Email).Any();
            if (IsValidEmail)
            {
                throw new Exception("Employee Email already existsint the System");
            }
            var employee = new EmployeeEntity()
            {
                Id = Guid.NewGuid().ToString(),
                Code = employeeViewModel.Code,
                Name = employeeViewModel.Name,
                Email = employeeViewModel.Email,
                Phone = employeeViewModel.Phone,
                DOB = employeeViewModel.DOB,
                DOE = employeeViewModel.DOE,
                Address = employeeViewModel.Address,
                Gender = employeeViewModel.Gender,
                BasicSalary = employeeViewModel.BasicSalary,
                DepartmentId = employeeViewModel.DepartmentId,
                PositionId = employeeViewModel.PositionId,

            };
            _employeeRepository.Create(employee);
        }

        public void Delete(string Id)
        {
            _employeeRepository.Delete(Id);
        }

        public IList<EmployeeViewModel> GetAll()
        {

            /*return _employeeRepository.GetAll().Select(s => new EmployeeViewModel
            {
                Id = s.Id,
                Name = s.Name,
                Email = s.Email,
                DOB = s.DOB,
                BasicSalary = s.BasicSalary,
                Address = s.Address,
                Gender = s.Gender,
                Phone = s.Phone,
                Code = s.Code,
                DOE = s.DOE,
                DepartmentInfo = _employeeRepository.GetDepartments().Where(d => d.Id == s.DepartmentId).FirstOrDefault().Name,
                PositionInfo = _employeeRepository.GetPositions().Where(p => p.Id == s.PositionId).FirstOrDefault().Name


            }).ToList();*/
            return (from e in _employeeRepository.GetAll()
                                                  join d in _departmentRepository.GetAll()
                                                  on e.DepartmentId equals d.Id
                                                  join p in _positionRepository.GetAll()
                                                  on e.PositionId equals p.Id
                                                  select new EmployeeViewModel
                                                  {
                                                      Id = e.Id,
                                                      Name = e.Name,
                                                      Email = e.Email,
                                                      DOB = e.DOB,
                                                      BasicSalary = e.BasicSalary,
                                                      Address = e.Address,
                                                      Gender = e.Gender,
                                                      Phone = e.Phone,
                                                      Code = e.Code,
                                                      DOE = e.DOE,
                                                      DepartmentInfo = d.Name,//_applicationDbContext.Departments.Where(d => d.Id == s.DepartmentId).FirstOrDefault().Name,
                                                      PositionInfo = p.Name//_applicationDbContext.Positions.Where(p => p.Id == s.PositionId).FirstOrDefault().Name,
                                                  }).ToList(); 
        }

        public IList<EmployeeDetail> GetByFromCodeToCodeDepartmentId(string fromCode, string toCode, string departmentId)
        {
            return (from e in _employeeRepository.GetAll()
                    join d in _departmentRepository.GetAll()
                    on e.DepartmentId equals d.Id
                    join p in _positionRepository.GetAll()
                    on e.PositionId equals p.Id
                    where (e.Code.CompareTo(fromCode)>=0 && e.Code.CompareTo(toCode)<=0)||(e.DepartmentId==departmentId)
                    select new EmployeeDetail
                    {
                       
                        Name = e.Name,
                        Email = e.Email,
                        DOB = e.DOB,
                        BasicSalary = e.BasicSalary,
                        Address = e.Address,
                        Gender = e.Gender,
                        Phone = e.Phone,
                        Code = e.Code,
                        DOE = e.DOE,
                        DepartmentInfo = d.Name,//_applicationDbContext.Departments.Where(d => d.Id == s.DepartmentId).FirstOrDefault().Name,
                        PositionInfo = p.Name//_applicationDbContext.Positions.Where(p => p.Id == s.PositionId).FirstOrDefault().Name,
                    }).ToList();
        }

        public EmployeeViewModel GetByID(string id)
        {
            var employeeEntity = _employeeRepository.GetById(id);
            var d = _departmentRepository.GetById(employeeEntity.DepartmentId);
            var p = _positionRepository.GetById(employeeEntity.PositionId);
            return new EmployeeViewModel()
            {
                Id = employeeEntity.Id,
                Name = employeeEntity.Name,
                Email = employeeEntity.Email,
                DOB = employeeEntity.DOB,
                BasicSalary = employeeEntity.BasicSalary,
                Address = employeeEntity.Address,
                Gender = employeeEntity.Gender,
                Phone = employeeEntity.Phone,
                Code = employeeEntity.Code,
                DOE = employeeEntity.DOE,
                DepartmentId = employeeEntity.DepartmentId,
                PositionId = employeeEntity.PositionId

            };
        }

        public IList<DepartmentViewModel> GetDepartments()
        {
            return _employeeRepository.GetDepartments().Select(
                s => new DepartmentViewModel
                {
                    Id = s.Id,
                    Code = s.Code
                }).OrderBy(o => o.Code).ToList();
        }

        public IList<PositionViewModel> GetPositions()
        {
            return _employeeRepository.GetPositions().Select(s => new PositionViewModel
            {
                Id = s.Id,
                Code = s.Code
            }).OrderBy(o => o.Code).ToList();
        }

        public void Update(EmployeeViewModel employeeViewModel)
        {
            try
            {
                var employee = new EmployeeEntity()
                {
                    Id = employeeViewModel.Id,
                    Code = employeeViewModel.Code,
                    Name = employeeViewModel.Name,
                    Email = employeeViewModel.Email,
                    Phone = employeeViewModel.Phone,
                    DOB = employeeViewModel.DOB,
                    DOE = employeeViewModel.DOE,
                    Address = employeeViewModel.Address,
                    Gender = employeeViewModel.Gender,
                    BasicSalary = employeeViewModel.BasicSalary,
                    ModifiedAt = DateTime.Now,
                    DepartmentId = employeeViewModel.DepartmentId,
                    PositionId = employeeViewModel.PositionId,

                };
                _employeeRepository.Update(employee);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /*IList<DepartmentViewModel> GetDepartments()
        {
            return _employeeRepository.GetDepartments().Select(
                s => new DepartmentViewModel
                {
                    Id = s.Id,
                    Code = s.Code
                }).OrderBy(o => o.Code).ToList();
        }

        IList<PositionViewModel> GetPositions()
        {
            return  _employeeRepository.GetPositions().Select(s => new PositionViewModel
            {
                Id = s.Id,
                Code = s.Code
            }).OrderBy(o => o.Code).ToList();
        }*/
    }
}
