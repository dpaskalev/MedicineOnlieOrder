using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Services.Interfaces;

namespace MedicineOnlieOrder.Controllers
{
    [Authorize]
    public class CartController : BaseController
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = await _cartService.GetIndexAsync(GetUserId());

            if (model == null)
            {
                return View("CustomErrorView");
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(int id)
        {
            await _cartService.AddAsync(id, GetUserId());

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Remove(int medicineId)
        {
            await _cartService.RemoveAsync(medicineId, GetUserId());

            return RedirectToAction("Index");
        }


    }
}
