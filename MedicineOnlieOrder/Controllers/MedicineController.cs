using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Services.Interfaces;

namespace MedicineOnlieOrder.Controllers
{
    [Authorize]
    public class MedicineController : Controller
    {
        private readonly IMedicineService _medicineService;

        public MedicineController(IMedicineService medicineService)
        {
            _medicineService = medicineService;
        }


    }
}
