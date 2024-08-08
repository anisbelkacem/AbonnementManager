using AbonnementManager.Models;
using AbonnementManager.Repository.IRepository;
using ApplicationManager.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AbonnementManager.Controllers
{
    [Authorize]
    public class AbonnementController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public AbonnementController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Abonnement> objAppList = _unitOfWork.Abonnement.GetAll(includeProperties: "Client,Application").ToList();
            return View(objAppList);
        }
		[HttpGet]
		public IActionResult Upsert(int? id)
        {
            AbonVM abonVM = new()
            {
                ClientList = _unitOfWork.Client.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id_Client.ToString()
                }),
                ApplicationList = _unitOfWork.Application.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id_App.ToString()
                }),
                Abonnement = new Abonnement()
            };
            if (id == null || id == 0)
            {
                //create
                return View(abonVM);
            }
            else
            {
                //update
                abonVM.Abonnement = _unitOfWork.Abonnement.Get(u => u.Id_Abon == id);
                return View(abonVM);
            }
            
        }
        [HttpPost]
        public IActionResult Upsert(AbonVM abonVM)
        {
            if (ModelState.IsValid)
            {
                
                var currentDate = DateOnly.FromDateTime(DateTime.Today);
                var existingAbonnement = _unitOfWork.Abonnement.GetAll()
                    .Where(a => a.IdClient == abonVM.Abonnement.IdClient &&
                               a.IdApp == abonVM.Abonnement.IdApp &&
                               a.DateFin >= currentDate)
                    .FirstOrDefault();
                if (existingAbonnement != null)
                {
                    ModelState.AddModelError("", "Abonnement already exists");
                    abonVM.ClientList = _unitOfWork.Client.GetAll().Select(u => new SelectListItem
                    {
                        Text = u.Name,
                        Value = u.Id_Client.ToString()
                    });
                    abonVM.ApplicationList = _unitOfWork.Application.GetAll().Select(u => new SelectListItem
                    {
                        Text = u.Name,
                        Value = u.Id_App.ToString()
                    });
                    return View(abonVM);
                }

                if (abonVM.Abonnement.Id_Abon == 0)
                {
                    _unitOfWork.Abonnement.Add(abonVM.Abonnement);
                }
                else
                {
                    _unitOfWork.Abonnement.Update(abonVM.Abonnement);
                }

                _unitOfWork.Save();
                //TempData["success"] = "Product created successfully";
                return RedirectToAction("Index");
            }
            else
            {
                abonVM.ClientList = _unitOfWork.Client.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id_Client.ToString()
                });
                abonVM.ApplicationList = _unitOfWork.Application.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id_App.ToString()
                });

                return View(abonVM);
            }
        }
        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Abonnement> objProductList = _unitOfWork.Abonnement.GetAll(includeProperties: "Client,Application").ToList();
            return Json(new { data = objProductList });
        }


        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var productToBeDeleted = _unitOfWork.Abonnement.Get(u => u.Id_Abon == id);
            if (productToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            

            _unitOfWork.Abonnement.Remove(productToBeDeleted);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Delete Successful" });
        }

        #endregion
    
    }
}
