using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Services.Interfaces;
using Services.VewModels;
using System.Security.Claims;

namespace MedicineOnlieOrder.Controllers
{
    [Authorize]
    public class MedicineController : BaseController
    {
        private readonly IMedicineService _medicineService;

        public MedicineController(IMedicineService medicineService)
        {
            _medicineService = medicineService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var model = await _medicineService.GetIndex(GetUserId());

            if (model == null)
            {
                return View("CustomErrorView");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = await _medicineService.GetAddModelAsynk();

            if (model == null)
            {
                return View("CustomErrorView");
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(MedicineViewModel viewModel)
        {
            if (ModelState.IsValid == false)
            {
                var model = await _medicineService.GetAddModelAsynk();
                return View(model);
            }

            await _medicineService.AddMedicineAsync(viewModel, GetUserId());

            return RedirectToAction("Index");
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var medicine = await _medicineService.GetDetails(id);

            if (medicine == null)
            {
                return View("CustomErrorView");
            }

            return View(medicine);
        }

        [HttpGet]
        public async Task<IActionResult> Assign(int medcineId)
        {
            var model = await _medicineService.GetAddMedcineToPharmacyViewModelAsync(medcineId, GetUserId());

            if (model == null)
            {
                return View("CustomErrorView");
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Assign(AddMedicineToPharmacyViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _medicineService.AssignMedicineAsync(model);
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await _medicineService.GetMedicineDeleteViewModel(id, GetUserId());

            if (model == null)
            {
                return View("CustomErrorView");
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(MedicineDeleteViewModel model)
        {
            await _medicineService.Delete(model.Id, model.PublisherId, GetUserId());

            return RedirectToAction("Index");
        }
    }
}
