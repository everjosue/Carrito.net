using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
//using Proyec1.Models;

namespace Proyec1.Controllers
{
    [Authorize(Roles ="Admin")]
    public class UserRolController : Controller
    {


        private readonly RoleManager<IdentityRole> _roleManager;   
        private readonly UserManager<IdentityUser> _userManager;

        public UserRolController(RoleManager<IdentityRole> roleManager,UserManager<IdentityUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            
        }

        public IActionResult Index()
        {
            return loadData();
        }

        public IActionResult loadData()
        {
            ViewBag.ListUsuarios = new SelectList(_userManager.Users.ToList(), "Id", "UserName");
            ViewBag.ListRoles = new SelectList(_roleManager.Roles.ToList(), "Id", "Name");
            return View("Index");
        }

        [HttpPost]

        /*public async Task<IActionResult> AddRol(string rolName)
        {
            if (rolName != null)
            {
                IdentityRole rol = new IdentityRole
                {
                    Name = rolName
                };
                var result = await _roleManager.CreateAsync(rol);
                if (result.Succeeded)
                {
                    return loadData();
                }
            }
            return View("Index");
        }*/

        public async Task<IActionResult> AddRol(string rolName)
        {

            IdentityRole _rol = new IdentityRole(rolName);

            var result = await _roleManager.CreateAsync(_rol);

            return loadData();

        }

        public async Task<IActionResult> AddUserRol(string UserId, string RoleId)
        {
            var _user = await _userManager.FindByIdAsync(UserId);
            var _role = await _roleManager.FindByIdAsync(RoleId);
            var result = await _userManager.AddToRoleAsync(_user, _role.Name);
            //if (result.Succeeded)
            //{
                //return loadData();
            //}
            return loadData();
            //_userManager.IsInRoleAsync(_user, _role.Name);
            //return View("Index");
        }
    }
}