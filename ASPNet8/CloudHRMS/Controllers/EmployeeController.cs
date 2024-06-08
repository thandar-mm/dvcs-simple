using CloudHRMS.Models.ViewModels;
using CloudHRMS.Services;
using Microsoft.AspNetCore.Mvc;


namespace CloudHRMS.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            this._employeeService = employeeService;
        }

        public IActionResult Entry()
        {
            /*var departments = _applicationDbContext.Departments.Select(s => new DepartmentViewModel
            {
                Id = s.Id,
                Code = s.Code
            }).OrderBy(o=>o.Code).ToList();*/
            ViewBag.Departments = _employeeService.GetDepartments();
            /*var positions = _applicationDbContext.Positions.Select(s => new PositionViewModel
            {
                Id = s.Id,
                Code = s.Code
            }).OrderBy(o => o.Code).ToList();*/
            ViewBag.Positions = _employeeService.GetPositions();
            return View();
        }

        [HttpPost]
        public IActionResult Entry(EmployeeViewModel ui)
        {
            try
            {
                /*var IsValidCode=_applicationDbContext.Employees.Where(w => w.Code == ui.Code).Any();
                if(IsValidCode)
                {
                    ViewBag.info = "Already Exit";
                    return View();
                }
                var IsValidEmail = _applicationDbContext.Employees.Where(w => w.Email == ui.Email).Any();
                if (IsValidCode)
                {
                    ViewBag.info = "Email Already Exit";
                    return View();
                }
                var employee = new EmployeeEntity()
                {
                    Id = Guid.NewGuid().ToString(),
                    Code = ui.Code,
                    Name = ui.Name,
                    Email = ui.Email,
                    Phone = ui.Phone,
                    DOB = ui.DOB,
                    DOE = ui.DOE,
                    Address = ui.Address,
                    Gender = ui.Gender,
                    BasicSalary = ui.BasicSalary,
                    DepartmentId = ui.DepartmentId,
                    PositionId = ui.PositionId,

                };
                _applicationDbContext.Employees.Add(employee);
                _applicationDbContext.SaveChanges();*/
                _employeeService.Create(ui);
                TempData["info"] = "Successfully Save to the System";
            }
            catch (Exception e)
            {
                TempData["info"] = "Error occur when saving a record to the system ";
            }
            return RedirectToAction("List");
        }

        public IActionResult List()
        {
            //Data Exchange from Data Model to View Model
            /*IList<EmployeeViewModel> employees = (from e in _applicationDbContext.Employees
                                                  join d in _applicationDbContext.Departments
                                                  on e.DepartmentId equals d.Id
                                                  join p in _applicationDbContext.Positions
                                                  on e.PositionId equals p.Id select new EmployeeViewModel
            //IList<EmployeeViewModel> employees = _applicationDbContext.Employees.Select(s => new EmployeeViewModel
            {
                Id = e.Id,
                Name= e.Name,
                Email = e.Email,
                DOB= e.DOB,
                BasicSalary= e.BasicSalary,
                Address = e.Address,
                Gender = e.Gender,
                Phone = e.Phone,
                Code = e.Code,
                DOE = e.DOE,
                DepartmentInfo = d.Name,//_applicationDbContext.Departments.Where(d => d.Id == s.DepartmentId).FirstOrDefault().Name,
                PositionInfo = p.Name//_applicationDbContext.Positions.Where(p => p.Id == s.PositionId).FirstOrDefault().Name,
            }).ToList();*/

            return View(_employeeService.GetAll());
        }

        public IActionResult Delete(string id)
        {
            try
            {
                /*var employee = _applicationDbContext.Employees.Find(id);
                if (employee is not null)
                {
                    _applicationDbContext.Remove(employee);
                    _applicationDbContext.SaveChanges();
                }*/
                _employeeService.Delete(id);
                TempData["info"] = "Delete Successfully";
            }
            catch (Exception ex)
            {
                TempData["info"] = "Error Occur When Delete process was done";

            }
            return RedirectToAction("List");
        }

        public IActionResult Edit(string id)
        {
            /*var departments = _applicationDbContext.Departments.Select(s => new DepartmentViewModel
            {
                Id = s.Id,
                Code = s.Code
            }).OrderBy(o => o.Code).ToList();
            
            var positions = _applicationDbContext.Positions.Select(s => new PositionViewModel
            {
                Id = s.Id,
                Code = s.Code
            }).OrderBy(o => o.Code).ToList();*/

            /* EmployeeViewModel employee = _applicationDbContext.Employees.Where(x => x.Id == id).Select(s =>new EmployeeViewModel
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
                 DepartmentId = s.DepartmentId,
                 PositionId = s.PositionId,

             }).SingleOrDefault();*/
            ViewBag.Departments = _employeeService.GetDepartments();
            ViewBag.Positions = _employeeService.GetPositions();
            return View(_employeeService.GetByID(id));
        }
        public IActionResult Update(EmployeeViewModel ui)
        {
            try
            {

                /*var employee = new EmployeeEntity()
                {
                    Id = ui.Id,
                    Code = ui.Code,
                    Name = ui.Name,
                    Email = ui.Email,
                    Phone = ui.Phone,
                    DOB = ui.DOB,
                    DOE = ui.DOE,
                    Address = ui.Address,
                    Gender = ui.Gender,
                    BasicSalary = ui.BasicSalary,
                    ModifiedAt=DateTime.Now,
                    DepartmentId = ui.DepartmentId,
                    PositionId = ui.PositionId,

                };
                _applicationDbContext.Employees.Update(employee);
                _applicationDbContext.SaveChanges();*/

                _employeeService.Update(ui);
                TempData["info"] = "Successfully Update to the System";
            }
            catch (Exception e)
            {
                TempData["info"] = "Error occur when updating a record to the system ";
            }
            return RedirectToAction("List");

        }

    }
}
