using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ObeSystem.Interfaces;
using ObeSystem.Models;

namespace ObeSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModuleController : ControllerBase
    {

        private readonly IModuleRepository _moduleRepository;

        public ModuleController(IModuleRepository moduleRepository)
        {
            _moduleRepository = moduleRepository;
        }


        // GET: api/Module
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Module>>> GetModules()
        {
            var module = await _moduleRepository.GetModuleAsync();
            return Ok(module);

        }


        [HttpPost]
        public ActionResult<Module> CreatePostAsync(Module module)
        {
            Module newmodule = _moduleRepository.Add(module);
            return Ok(newmodule);
        }


        [HttpPut("{id?}")]
        public ActionResult<Module> UpdateModule(Module module)
        {
            Module modulechanges = _moduleRepository.Update(module);
            return Ok(modulechanges);
        }




        //GET: api/Module/5
        [HttpGet("{id?}")]
        public async Task<ActionResult<Module>> GetModule(int id)
        {
            return await _moduleRepository.GetModuleByIdAsync(id);
        }


        public ActionResult<Module> DeleteLo(int id)
        {
            Module deletedlist = _moduleRepository.Delete(id);
            return Ok(deletedlist);
        }



    }
}
