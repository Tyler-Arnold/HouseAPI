﻿namespace House.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using House.HLL.Models;
    using System.Threading.Tasks;
    using House.HLL.Interfaces;
    using Serilog;
    using System;

    [ApiController]
    [Route("[controller]")]
    public class BindicatorController : ControllerBase
    {
        private readonly IBindicatorProvider _bindicatorProvider;

        public BindicatorController(IBindicatorProvider bindicatorProvider)
        {
            this._bindicatorProvider = bindicatorProvider;
        }

        [HttpGet()]
        public async Task<BinLookupDto> Get()
        {
            try
            {
                return await this._bindicatorProvider.Get();
            }
            catch(Exception e)
            {
                Log.Error("Error Getting Bin Information", e);
                throw;
            }
        }
    }
}
