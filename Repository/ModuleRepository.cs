using Microsoft.EntityFrameworkCore;
using ObeSystem.Interfaces;
using ObeSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObeSystem.Repository
{
    public class ModuleRepository : IModuleRepository
    {
       
        private readonly AppDbContext _context;

        public ModuleRepository(AppDbContext  context)
        {
            _context = context;   
        }

        

        public Module Add(Module module)
        {
            //module.ModuleId = _context.Modules.Max(x => x.ModuleId) + 1;

            _context.Modules.Add(module);
            _context.SaveChanges();
            return module;
        }

       

        public async Task<IEnumerable<Models.Module>> GetModuleAsync()
        {
            return await _context.Modules.ToListAsync();
        }

        public async Task<Models.Module> GetModuleByIdAsync(int id)
        {
            return await _context.Modules.FindAsync(id);
        }

        public Models.Module Update(Module modulechanges)
        {
            Module module = _context.Modules.FirstOrDefault(e => e.Id == modulechanges.Id);
            if(module != null)
            {
                module.Id = modulechanges.Id;
                module.Name = modulechanges.Name;
                module.Code = modulechanges.Code;
                module.Credits = modulechanges.Credits;
                module.Gpa = modulechanges.Gpa;
                module.Type = modulechanges.Type;
                module.Batch = modulechanges.Batch;
                module.Semester = modulechanges.Semester;
                module.Lolists = modulechanges.Lolists;
            }

            var newmodule = _context.Modules.Attach(modulechanges);

            newmodule.State = EntityState.Modified;
            _context.SaveChanges();

            return modulechanges;
        }


        public Models.Module Delete(int id)
        {
            Module module = _context.Modules.FirstOrDefault(e => e.Id == id);
            if(module != null)
            {
                _context.Modules.Remove(module);
                _context.SaveChanges();
            }

            return (module);
        }
    }
}
