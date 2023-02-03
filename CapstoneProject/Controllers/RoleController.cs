using CapstoneProject_DTOs.DTOs;
using CapstoneProject_EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapstoneProject.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public RoleController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public IActionResult Roles()
        {
            return View(_roleManager.Roles.ToList());
        }

        [HttpGet]
        public IActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(RoleAddDTO role)
        {
            if (ModelState.IsValid)
            {
                AppRole appRole = new AppRole()
                {
                    Name = role.Name,
                    RoleDescription = role.Description
                };
                var result = await _roleManager.CreateAsync(appRole);
                if (result.Succeeded)
                {
                    return RedirectToAction("Roles");
                }
                else //Identity'den gelen hatalar
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult EditRole(int id)
        {
            var role = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            RoleEditDTO roleEdit = new RoleEditDTO()
            {
                ID = role.Id,
                Name = role.Name,
                Description = role.RoleDescription
            };
            return View(roleEdit);
        }
        [HttpPost]
        public async Task<IActionResult> EditRole(RoleEditDTO roleEdit)
        {
            var role = _roleManager.Roles.FirstOrDefault(x => x.Id == roleEdit.ID);
            role.Name = roleEdit.Name;
            role.RoleDescription = roleEdit.Description;

            var result = await _roleManager.UpdateAsync(role);
            if (result.Succeeded)
            {
                return RedirectToAction("Roles");
            }
            return View();
        }

        public async Task<IActionResult> DeleteRole(int id)
        {
            var role = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            var result = await _roleManager.DeleteAsync(role);
            if (result.Succeeded)
            {
                return RedirectToAction("Roles");
            }
            return RedirectToAction("Roles");
        }

        [HttpGet]
        public async Task<IActionResult> AssignRole(int id)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Id == id);
            var roles = _roleManager.Roles.ToList();

            TempData["User"] = user.Name + " " + user.Surname;
            TempData["UserId"] = user.Id;

            var userRoles = await _userManager.GetRolesAsync(user); //kullanıcıya ait roller

            List<RoleAssignDTO> models = new List<RoleAssignDTO>();
            foreach (var item in roles)
            {
                RoleAssignDTO roleAssignViewModel = new RoleAssignDTO();
                roleAssignViewModel.Name = item.Name;
                roleAssignViewModel.RoleID = item.Id;
                roleAssignViewModel.Exits = userRoles.Contains(item.Name); //true false
                models.Add(roleAssignViewModel);
            }
            return View(models);
        }
        [HttpPost]
        public async Task<IActionResult> AssignRole(List<RoleAssignDTO> role)
        {
            var userId = (int)TempData["UserId"];
            var user = _userManager.Users.FirstOrDefault(x => x.Id == userId);

            foreach (var item in role)
            {
                if (item.Exits)
                {
                    await _userManager.AddToRoleAsync(user, item.Name);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, item.Name);
                }
            }
            return RedirectToAction("Index", "HumanResources");
        }
    }
}
