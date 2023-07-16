using Core_Proje.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Proje.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<WriterRole> _roleManager;
        private readonly UserManager<WriterUser> _userManager;

        public RoleController(RoleManager<WriterRole> roleManager, UserManager<WriterUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            ViewBag.V1 = "Roller";
            ViewBag.V2 = "Rol Listesi";
            ViewBag.V3 = "";
            ViewBag.V2URL = "/Role/Index/";

            var values = _roleManager.Roles.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateRole()
        {
            ViewBag.V1 = "Yeni Rol Ekleme";
            ViewBag.V2 = "Rol Listesi";
            ViewBag.V3 = "Yeni Rol Ekleme";
            ViewBag.V2URL = "/Role/Index/";

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel createRoleViewModel)
        {
            WriterRole role = new WriterRole()
            {
                Name = createRoleViewModel.RoleName
            };

            var result = await _roleManager.CreateAsync(role);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }

            else
            {
                return View();
            }
        }

        public async Task<IActionResult> DeleteRole(int id)
        {
            var values = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            await _roleManager.DeleteAsync(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateRole(int id)
        {
            ViewBag.V1 = "Rol Güncelleme";
            ViewBag.V2 = "Rol Listesi";
            ViewBag.V3 = "Rol Güncelleme";
            ViewBag.V2URL = "/Role/Index/";

            var value = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            UpdateRoleViewModel updateRoleViewModel = new UpdateRoleViewModel
            {
                RoleID = value.Id,
                RoleName = value.Name,
            };

            return View(updateRoleViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRole(UpdateRoleViewModel updateRoleViewModel)
        {
            var value = _roleManager.Roles.FirstOrDefault(x => x.Id == updateRoleViewModel.RoleID);
            value.Name = updateRoleViewModel.RoleName;
            await _roleManager.UpdateAsync(value);
            return RedirectToAction("Index");
        }

        public IActionResult UserList()
        {
            ViewBag.V1 = "Kişiler";
            ViewBag.V2 = "Kişi Listesi";
            ViewBag.V3 = "";
            ViewBag.V2URL = "/UserList/Index/";

            var values = _userManager.Users.ToList();
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> AssignRole(int id)
        {
            ViewBag.V1 = "Rol Atama";
            ViewBag.V2 = "Kişi Listesi";
            ViewBag.V3 = "Rol Atama";
            ViewBag.V2URL = "/Role/UserList/";

            var user = _userManager.Users.FirstOrDefault(x => x.Id == id);
            TempData["UserId"] = user.Id;
            var roles = _roleManager.Roles.ToList();
            var userRoles = await _userManager.GetRolesAsync(user);
            List<RoleAssignViewModel> roleAssignViewModels = new List<RoleAssignViewModel>();
            foreach (var item in roles)
            {
                RoleAssignViewModel model = new RoleAssignViewModel();
                model.RoleID = item.Id;
                model.RoleName = item.Name;
                model.RoleExist = userRoles.Contains(item.Name);
                roleAssignViewModels.Add(model);
            }
            return View(roleAssignViewModels);
        }

        [HttpPost]
        public async Task<IActionResult> AssignRole(List<RoleAssignViewModel> model)
        {
            var userID = (int)TempData["UserId"];
            var user = _userManager.Users.FirstOrDefault(x => x.Id == userID);
            foreach (var item in model)
            {
                if (item.RoleExist)
                {
                    await _userManager.AddToRoleAsync(user, item.RoleName);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, item.RoleName);
                }
            }
            return RedirectToAction("UserList", "Role");
        }
    }
}