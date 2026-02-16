using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Services.Interfaces;
using Services.VewModels;
using System.Security.Claims;

namespace MedicineOnlieOrder.Controllers
{
    [Authorize]
    public class MedicineController : Controller
    {
        private readonly IMedicineService _medicineService;

        private string GetUserId()
        {
            return User?.FindFirstValue(ClaimTypes.NameIdentifier);
        }

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
    }
}
