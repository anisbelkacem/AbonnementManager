using AbonnementManager.Models;
using AbonnementManager.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AbonnementManager.Controllers
{
    [Authorize]
    public class ClientController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ClientController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Client> objClientList = _unitOfWork.Client.GetAll().ToList();
            return View(objClientList);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Client obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Client.Add(obj);
                _unitOfWork.Save();
                //TempData["success"] = "Client created successfully";
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
            Client? clientFromDb = _unitOfWork.Client.Get(u => u.Id_Client == id);
            //Client? clientFromDb1 = _db.Categories.FirstOrDefault(u=>u.Id==id);
            //Client? clientFromDb2 = _db.Categories.Where(u=>u.Id==id).FirstOrDefault();

            if (clientFromDb == null)
            {
                return NotFound();
            }
            return View(clientFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Client obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Client.Update(obj);
                _unitOfWork.Save();
                //TempData["success"] = "Client updated successfully";
                return RedirectToAction("Index");
            }
            return View();

        }

        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Client> objClientList = _unitOfWork.Client.GetAll().ToList();
            return Json(new { data = objClientList });
        }


        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var clientToBeDeleted = _unitOfWork.Client.Get(u => u.Id_Client == id);
            if (clientToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }



            _unitOfWork.Client.Remove(clientToBeDeleted);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Delete Successful" });
        }

        #endregion
    }
}
