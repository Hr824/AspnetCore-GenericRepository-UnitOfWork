using Microsoft.EntityFrameworkCore;
using MvcCoreApp.Data;
using MvcCoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreApp.Services
{
    public class PersonService : IPersonService
    {
        private readonly IGenericRepository<Person> _repository;

        public PersonService(IGenericRepository<Person> repository)
        {
            _repository = repository;
        }


        public List<Person> GetAll()
        {
            List<Person> list = _repository.GetAll()
                                           .Include(p => p.Job)
                                           .Include(p => p.PersonActivities)
                                           .ToList();
            return list;
        }


        public async Task<List<Person>> GetAllAsync()
        {
            return (await _repository.GetAllAsync()).ToList();
        }



        public async Task<List<Person>> GetAllWithIncludeAsync(string relatedEntities)
        {
            return (await _repository.GetAllWithIncludeAsync(relatedEntities)).ToList();
        }


        public Person GetById(Guid? id)
        {
            if (id == null)
                return null;

            Person person = _repository.GetBy(p => p.Id == id)
                                       .Include(p => p.Job)
                                       .Include(p => p.PersonActivities)
                                           .ThenInclude(pa => pa.Activity)
                                       .FirstOrDefault();

            return person;
        }



        public Person Create(Person person)
        {
            return _repository.Insert(person);
        }



        public Person Update(Person person)
        {
            return _repository.Update(person);
        }



        public void Delete(Person person)
        {
            _repository.Delete(person);
        }
    }
}