using CapstoneProject_DTOs.DTOs;
using CapstoneProject_EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CapstoneProject.Controllers
{
    public class RoleController : Controller
    {
        public readonly RoleManager<AppRole> _roleManager;

        public RoleController(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View(_roleManager.Roles.ToList());
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(RoleAddDTO role)
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
                    return RedirectToAction("Index");
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
        public IActionResult Edit(int id)
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
        public async Task<IActionResult> Edit(RoleEditDTO roleEdit)
        {
            var role = _roleManager.Roles.FirstOrDefault(x => x.Id == roleEdit.ID);
            role.Name=roleEdit.Name;
            role.RoleDescription = roleEdit.Description;

            var result = await _roleManager.UpdateAsync(role);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            var role = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            var result = await _roleManager.DeleteAsync(role);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
