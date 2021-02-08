using System;
using ObeSystem.Models;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;

namespace ObeSystem.Interfaces
{
    public interface IModuleRepository
    {


        Task<Module> GetModuleByIdAsync(int id);

        Task<IEnumerable<Module>> GetModuleAsync();

        Module Add(Module lolist);

        Module Update(Module modulechanges);

        Module Delete(int id);
    }
}
