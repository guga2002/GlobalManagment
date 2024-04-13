using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using GlobalManagment.Models;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Interfaces;
using Jandag.BLL.Interface;

namespace GlobalManagment.Controllers {

    [Route("api/[controller]")]
    public class SampleDataController : Controller {

        private readonly IAllInOneService _chanellRepository;

        public SampleDataController(IAllInOneService _chanellRepository)
        {
                this._chanellRepository=_chanellRepository;
        }
        [HttpGet]
        public async Task< object> Get(DataSourceLoadOptions loadOptions) {

            var res = await _chanellRepository.SeedData();
            return DataSourceLoader.Load(res, loadOptions);
        }

    }
}