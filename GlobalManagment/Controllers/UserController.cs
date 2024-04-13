using GlobalManagment.Models;
using Jandag.BLL.Interface;
using Jandag.BLL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GlobalManagment.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService ser;

        public UserController(IUserService se)
        {
            this.ser = se;
        }
        [Authorize]
        public IActionResult Index()
        {
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
                    return RedirectToAction("Index");
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
                        return RedirectToAction("SignIn");
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
