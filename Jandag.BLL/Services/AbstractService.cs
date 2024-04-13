using AutoMapper;
using Jandag.DLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jandag.BLL.Services
{
    public abstract class AbstractService
    {
        protected readonly IMapper maper;
        protected readonly IUniteOfWork work;

        protected AbstractService(IMapper map,IUniteOfWork wor)
        {
            this.maper = map;
            this.work = wor;
        }
    }
}
