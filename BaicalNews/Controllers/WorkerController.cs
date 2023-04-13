using BaikalNews.Domain.Models;
using BaikalNews.Domain.Enum;
using BaikalNews.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BaikalNews.Controllers
{
    public class WorkerController : Controller
    {
        private readonly IWorkerService _workerServices;

        public WorkerController(IWorkerService workerServices)
        {
            _workerServices = workerServices;
        }

        public IActionResult Workers()
        {
            return View();
        }

        public IActionResult GetWorkers()
        {
            var response = _workerServices.getWorkers();
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View(response.Data);
            }

            return View("Error", $"{response.Description}");
        }

        [HttpGet]
        public async Task<IActionResult> Save(int id)
        {
            //ListRole[] listRole = new ListRole[] { ListRole.Admin, ListRole.Moderator, ListRole.SuperAdmin };
            //SelectList selectList = new SelectList(listRole, ListRole.Moderator);
            SelectList selectList = new SelectList(new List<ListRole> { ListRole.Moderator, ListRole.Admin, ListRole.SuperAdmin}, ListRole.Moderator);
            ViewBag.selectList = selectList;

            if (id == 0)
                return View("Save");

            var response = await _workerServices.getWorker(id);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View("Save", response.Data);
            }

            return View("Save");
        }

        [HttpPost]
        public async Task<IActionResult> Save(Worker model)
        {
            if (ModelState.IsValid)
            {

                if (model.Id == 0)
                {
                    
                    await _workerServices.create(model);
                }
                else await _workerServices.update(model.Id, model);
            }
            else
            {
                return View("Save", model);
            }

            return RedirectToAction("GetWorkers");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var response = await _workerServices.delete(id);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return RedirectToAction("GetWorkers");
            }

            return View("Error", response.Description);
        }
    }
}
