using CloudHRMS.Models.ViewModels;
using CloudHRMS.Services;
using Microsoft.AspNetCore.Mvc;

namespace CloudHRMS.Controllers
{
    public class PositionController : Controller
    {
        private readonly IPositionService _positionService;

        //private readonly ApplicationDbContext _applicationDbContext;

        public PositionController(IPositionService positionService)
        {
            this._positionService = positionService;
        }

        public IActionResult List()
        {
            /*IList<PositionViewModel> positions = _applicationDbContext.Positions.Select(
                s => new PositionViewModel
                {
                    Id = s.Id,
                    Code = s.Code,
                    Name = s.Name,
                    Level = s.Level,
                }).ToList();*/
            return View(_positionService.GetAll());
        }

        public IActionResult Edit(string id)
        {
            if (id != null)
            {
                return View(_positionService.GetByID(id));
            }
            else
            {
                return RedirectToAction("List");
            }
        }

        public IActionResult Update(PositionViewModel ui)
        {
            try
            {

                /*var position = new PositionEntity()
                {
                    Id = ui.Id,
                    Code = ui.Code,
                    Name = ui.Name,
                    Level = ui.Level,
                    ModifiedAt = DateTime.Now

                };
                _applicationDbContext.Positions.Update(position);
                _applicationDbContext.SaveChanges();*/
                _positionService.Update(ui);
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
            {
                /*var position = _applicationDbContext.Positions.Find(id);
                if (position != null)
                {
                    _applicationDbContext.Positions.Remove(position);
                    _applicationDbContext.SaveChanges();
                }*/
                _positionService.Delete(id);
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
        public IActionResult Entry(PositionViewModel ui)
        {
            try
            {
                /*var position = new PositionEntity()
                {
                    Id = Guid.NewGuid().ToString(),
                    Code = ui.Code,
                    Name = ui.Name,
                    Level = ui.Level,
                };
                _applicationDbContext.Positions.Add(position);
                _applicationDbContext.SaveChanges();*/
                _positionService.Create(ui);
                ViewBag.Info = "Successfully into Position";
            }
            catch (Exception)
            {
                ViewBag.Info = "Error occur When saving into Position";
            }
            return View();
        }



    }


}
