using GlobalManagment.Models;
using Jandag.BLL.Interface;
using Jandag.BLL.Models;
using Jandag.DLL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GlobalManagment.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserService ser;

        private readonly RoleManager<IdentityRole> rolemana;

        private readonly UserManager<User> usermanager;
        public UserController(IUserService se, RoleManager<IdentityRole> rolemana, UserManager<User> usermanager)
        {
            this.ser = se;
            this.rolemana = rolemana;
            this.usermanager = usermanager;
        }
        [AllowAnonymous]
        public async  Task<IActionResult> Index()
        {
            if(! await rolemana.RoleExistsAsync("Admin"))
            {
               await  rolemana.CreateAsync(new IdentityRole("Admin"));
            }
            if (User is not null&& User.Identity is not null&& User.Identity.Name is not null)
            {
                var user = await usermanager.FindByNameAsync(User.Identity.Name);
                await usermanager.AddToRoleAsync(user, "Admin");
            }
            return View();
        }

        [AllowAnonymous]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> SignIn(SignInModel mod)
        {
            try
            {
                var res = await ser.SignIn(mod);
                if (res)
                {
                    return RedirectToAction("Index","Home");
                }
                TempData["Shecdoma"] = "such a user no exist";
                return RedirectToAction("SignIn");
            }
            catch (Exception exp)
            {
                TempData["Shecdoma"] = exp.Message;
                return RedirectToAction("SignIn");
            }
        }

        [AllowAnonymous]
        public IActionResult Registration()
        {
            return  View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Registration(CustomerModel registration)
        {
            try
            {
                var res=await ser.Registration(registration);
                if(res)
                {
                    TempData["success"] = $"User Successfully refistered:{registration.Username}";
                    return RedirectToAction("Index");
                }
                TempData["ErrorMessage"] = "registration was not successfully";
                return RedirectToAction("Registration");
            }
            catch (Exception exp)
            {
                TempData["ErrorMessage"] = exp.Message;
                return RedirectToAction("Registration");
            }  
        }

        [Authorize]
        public async Task<IActionResult> LogOut()
        {
            try
            {

                if (User.Identity.IsAuthenticated)
                {
                    var res = await ser.SignOut();
                    if (res == true)
                    {
                        return RedirectToAction("Index","Home");
                    }

                    return RedirectToAction("Index");
                }
                throw new UnauthorizedAccessException("access denied");
            }
            catch (Exception exp)
            {
                TempData["ErrorMessage"] = exp.Message;
                return RedirectToAction("Index");
            }
        }
    }
}
