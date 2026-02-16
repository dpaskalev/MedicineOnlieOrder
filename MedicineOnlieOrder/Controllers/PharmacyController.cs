using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Services.Interfaces;

namespace MedicineOnlieOrder.Controllers
{
    public class PharmacyController : BaseController
    {
        private readonly IPharmacyService _pharmacyService;

        public PharmacyController(IPharmacyService pharmacyService)
        {
            _pharmacyService = pharmacyService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var modelsCollection = await _pharmacyService.GetPharmaciesAsynk(GetUserId());

            if (modelsCollection == null)
            {
                return View("CustomErrorView");
            }

            return View(modelsCollection);
        }
    }
}
