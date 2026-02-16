using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Services.Interfaces;
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

        //Create option

        //Search option
    }
}
