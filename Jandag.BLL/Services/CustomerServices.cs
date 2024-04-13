using AutoMapper;
using GlobalManagment.Models;
using Jandag.BLL.Interface;
using Jandag.BLL.Models;
using Jandag.BLL.Validation.Regexs;
using Jandag.DLL.Entities;
using Jandag.DLL.Interfaces;
using Jandag.DLL.Repositories.UserRelated;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jandag.BLL.Services
{
    public class CustomerServices:AbstractService,IUserService
    {
        private readonly SignInManagerForUser signin;
        private readonly UserManager userManager;
        public CustomerServices(SignInManagerForUser signin,UserManager manag,IUniteOfWork wor,IMapper map):base(map,wor)
        {
            this.signin = signin;
            this.userManager = manag;
        }

        public async Task<bool> SignIn(SignInModel sign)
        {
            try
            {
                RG.valdateUsername(sign.Username);
                RG.Validatepassword(sign.Password);
                var res = await signin.PasswordSignInAsync(sign.Username, sign.Password, true, false);
                if (res.Succeeded)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> Registration(CustomerModel mod)
        {
            try
            {
                RG.valdateUsername(mod.Username);
                RG.Validatepassword(mod.Password);
                RG.validateNameSurname(mod.Name);
                RG.validateNameSurname(mod.Surname);
                RG.validateEmail(mod.Email);
                RG.validatePersonal(mod.PersonalNumber);
                RG.ValidateBirth(mod.Birthday);
                RG.validatePersonal(mod.PersonalNumber);

                var cust = new User()
                {
                    Email = mod.Email,
                    Surname = mod.Surname,
                    Name = mod.Name,
                    UserName = mod.Username,
                    PersonalNumber = mod.PersonalNumber,
                    PhoneNumber = mod.PhoneNumber,
                    Birthdate = mod.Birthday
                };

                var res=await userManager.CreateAsync(cust, mod.Password);
                if(res.Succeeded) { return true; }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> SignOut()
        {
            try
            {
                await signin.SignOutAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
