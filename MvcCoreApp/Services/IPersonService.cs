using MvcCoreApp.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MvcCoreApp.Services
{
    public interface IPersonService
    {
        List<Person> GetAll();
        Task<List<Person>> GetAllAsync();
        Task<List<Person>> GetAllWithIncludeAsync(string relatedEntities);

        Person GetById(Guid? id);
        Person Create(Person person);
        Person Update(Person person);
        void Delete(Person person);
    }
}
