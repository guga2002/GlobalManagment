﻿using GlobalManagment.Models;
using Jandag.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jandag.BLL.Interface
{
    public interface IUserService
    {
        Task<bool> SignIn(SignInModel sign);
        Task<bool> Registration(CustomerModel mod);
        Task<bool> SignOut();
    }
}
