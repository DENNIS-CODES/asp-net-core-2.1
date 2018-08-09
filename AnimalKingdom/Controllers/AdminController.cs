using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnimalKingdom.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AnimalKingdom.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        public AdminController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UserManagement()
        {
            var users = _userManager.Users;

            return View(users);
        }

        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(AddUserViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var user = new IdentityUser
            {
                UserName = model.UserName,
                Email = model.Email
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
                return RedirectToAction("UserManagement", _userManager.Users);


            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("",error.Description);
            }
            return View(model);
        }

        public async Task<IActionResult> EditUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
                return RedirectToAction("UserManagement", _userManager.Users);

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(string id, string userName, string email)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user != null)
            {
                user.UserName = userName;
                user.Email = email;

                var result = await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                    return RedirectToAction("UserManagement", _userManager.Users);

                ModelState.AddModelError("","User not updated, something went wrong.");

                return View(user);
            }

            return RedirectToAction("UserManagement", _userManager.Users);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user != null)
            {
                var result = await _userManager.DeleteAsync(user);

                if (result.Succeeded)
                    return RedirectToAction("UserManagement", _userManager.Users);
                ModelState.AddModelError("","Something went wrong while deleting this user");
            }
            else
            {
                ModelState.AddModelError("","This user can't be found");
            }

            return RedirectToAction("UserManagement", _userManager.Users);
        }
    }
}