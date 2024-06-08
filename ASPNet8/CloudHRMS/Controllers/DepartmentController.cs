using CloudHRMS.Models.ViewModels;
using CloudHRMS.Services;
using Microsoft.AspNetCore.Mvc;

namespace CloudHRMS.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            this._departmentService = departmentService;
        }

        public IActionResult List()
        {
            /*IList<DepartmentViewModel> departments = _applicationDbContext.Departments.Select(
                s => new DepartmentViewModel
                {
                    Id = s.Id,
                    Code = s.Code,
                    Name = s.Name,
                    ExtensionPhone = s.ExtensionPhone,
                    TotalEmployeeCount=_applicationDbContext.Employees.Where(e=>e.DepartmentId == s.Id).Count()
                }).ToList();*/
            return View(_departmentService.GetAll());
        }

        public IActionResult Edit(string id)
        {
            if (id != null)
            {
                /*DepartmentViewModel department = _applicationDbContext.Departments.Where(x => x.Id == id).Select(s => new DepartmentViewModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    Code = s.Code,
                    ExtensionPhone = s.ExtensionPhone

                }).SingleOrDefault();*/
                return View(_departmentService.GetByID(id));
            }
            else
            {
                return RedirectToAction("List");
            }
        }

        public IActionResult Update(DepartmentViewModel ui)
        {
            try
            {

                /*var department = new DepartmentEntity()
                {
                    Id = ui.Id,
                    Code = ui.Code,
                    Name = ui.Name,
                    ExtensionPhone = ui.ExtensionPhone,
                    ModifiedAt = DateTime.Now

                };
                _applicationDbContext.Departments.Update(department);
                _applicationDbContext.SaveChanges();*/
                _departmentService.Update(ui);
                TempData["info"] = "Successfully Update to the System";
            }
            catch (Exception e)
            {
                TempData["info"] = "Error occur when updating a record to the system ";
            }
            return RedirectToAction("List");

        }

        public IActionResult Delete(string id)
        {
            try
            {/*
                var department = _applicationDbContext.Departments.Find(id);
                if (department != null)
                {
                    _applicationDbContext.Departments.Remove(department);
                    _applicationDbContext.SaveChanges();
                }*/
                _departmentService.Delete(id);
                TempData["info"] = "Delete Successfullly";
            }
            catch (Exception e)
            {
                TempData["info"] = "Error Occur When Deleting";
            }

            return RedirectToAction("List");
        }

        public IActionResult Entry() => View();

        [HttpPost]
        public IActionResult Entry(DepartmentViewModel ui)
        {
            try
            {
                /*var department = new DepartmentEntity()
                {
                    Id = Guid.NewGuid().ToString(),
                    Code = ui.Code,
                    Name = ui.Name,
                    ExtensionPhone = ui.ExtensionPhone
                };
                _applicationDbContext.Departments.Add(department);
                _applicationDbContext.SaveChanges();*/
                _departmentService.Create(ui);
                ViewBag.Info = "Successfully into Department";
            }
            catch (Exception e)
            {
                ViewBag.Info = "Error occur When saving into Department";
            }
            return View();
        }



    }


}
