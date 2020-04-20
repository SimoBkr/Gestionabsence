using Microsoft.AspNetCore.Mvc;
using coreProject.Data;
using coreProject.Models;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace coreProject.Controllers
{
    public class rolesController:Controller
    {
        RoleManager<IdentityRole> _roleManager ;
        public rolesController( RoleManager<IdentityRole> roleManager)
        {
            this._roleManager = roleManager;
        }
        public IActionResult Index()
        {
            var roles = _roleManager.Roles.ToList();
            return View(roles);
        }
        public IActionResult Create()
        {
            return View(new IdentityRole());
        }
        [HttpPost]
        public async  Task<IActionResult> Create(IdentityRole role)
        {
            await _roleManager.CreateAsync(role);
            return RedirectToAction("Index");
        }
    }
}