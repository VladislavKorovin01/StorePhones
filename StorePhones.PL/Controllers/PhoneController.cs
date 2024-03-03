using Microsoft.AspNetCore.Mvc;
using StorePhones.BLL.Services;
using StorePhones.PL.ViewModels;

namespace StorePhones.PL.Controllers
{
    public class PhoneController : Controller
    {
        private ManagmentPhones manager;
        public PhoneController(IConfiguration conf)
        {
            manager = new ManagmentPhones(conf.GetConnectionString("DefaultConnection"));
        }
        public async Task<IActionResult> Index()
        {
            return View(await manager.GetPhones());
        }

        public IActionResult AddPhone()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddPhone(PhoneModelView PhoneModel)
        {
            if (ModelState.IsValid){
                var res = "";
            }
            else
            {
                return BadRequest();
            }
            return RedirectToAction("Index");
        }
    }
}
