using AbonnementManager.Models;
using AbonnementManager.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AbonnementManager.Controllers
{
    [Authorize]

    public class ApplicationController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ApplicationController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Application> objAppList = _unitOfWork.Application.GetAll().ToList();
            return View(objAppList);
        }
       
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Application obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Application.Add(obj);
                _unitOfWork.Save();
                //TempData["success"] = "Application created successfully";
                return RedirectToAction("Index");
            }
            return View();

        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Application? applicationFromDb = _unitOfWork.Application.Get(u => u.Id_App == id);
            //Application? applicationFromDb1 = _db.Categories.FirstOrDefault(u=>u.Id==id);
            //Application? applicationFromDb2 = _db.Categories.Where(u=>u.Id==id).FirstOrDefault();

            if (applicationFromDb == null)
            {
                return NotFound();
            }
            return View(applicationFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Application obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Application.Update(obj);
                _unitOfWork.Save();
                //TempData["success"] = "Application updated successfully";
                return RedirectToAction("Index");
            }
            return View();

        }
        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Application> objApplicationList = _unitOfWork.Application.GetAll().ToList();
            return Json(new { data = objApplicationList });
        }


        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var applicationToBeDeleted = _unitOfWork.Application.Get(u => u.Id_App == id);
            if (applicationToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }



            _unitOfWork.Application.Remove(applicationToBeDeleted);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Delete Successful" });
        }

        #endregion

    }

}
