using Core_Proje.Areas.Writer.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Core_Proje.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Route("Writer/[controller]/[action]")]
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        private readonly UserManager<WriterUser> _userManager;

        public RegisterController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new UserRegisterViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserRegisterViewModel userRegisterViewModel)
        {
            if (ModelState.IsValid)
            {
                WriterUser user = new WriterUser()
                {
                    Name = userRegisterViewModel.Name,
                    Surname = userRegisterViewModel.Surname,
                    UserName = userRegisterViewModel.UserName,
                    Email = userRegisterViewModel.EMail,
                    ImageUrl = userRegisterViewModel.ImageUrl
                };

                var result = await _userManager.CreateAsync(user, userRegisterViewModel.Password);

                if (result.Succeeded && userRegisterViewModel.Password == userRegisterViewModel.ConfirmPassword)
                {
                    return RedirectToAction("Index", "Login");
                }

                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }

            return View();
        }
    }
}
