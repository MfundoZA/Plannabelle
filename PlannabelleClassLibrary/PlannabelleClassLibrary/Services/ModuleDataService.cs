using PlannabelleClassLibrary.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using PlannabelleClassLibrary.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace PlannabelleClassLibrary.Services
{
    /*
     * API Service Calls and Async ViewModel Loading - FULL STACK WPF (.NET CORE) MVVM #4 – SingletonSean.
     * 2019. YouTube video. [Online]. Available at:
     * https://youtu.be/0SCKUine6tY?t=72
     */
    public class ModuleDataService
    {
        public PlannabelleDbContext dbContext { get; set; }

        public ModuleDataService(PlannabelleDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // Retrives all modules
        public List<Module> getAll()
        {
            var modules = (from m in dbContext.Module
                           select m).ToList();

            return modules;
        }

        // a specified enrollment using an id
        public Module Get(int id)
        {
            Module module = dbContext.Module
                .FirstOrDefault(m => m.Id == id);

            return module;
        }

        public Module Insert(Module module)
        {
            EntityEntry<Module> newModule =  dbContext.Module.Add(module);
            dbContext.SaveChanges();

            return newModule.Entity;
        }

        public Module Update(int id, Module module)
        {
            module.Id = id;

            dbContext.Set<Module>().Update(module);
            dbContext.SaveChanges();

            return module;
        }

        public bool Delete(int id)
        {
            Module module = dbContext.Set<Module>().FirstOrDefault(m => m.Id == id);
            dbContext.Set<Module>().Remove(module);
            dbContext.SaveChanges();

            return true;
        }
    }
}
