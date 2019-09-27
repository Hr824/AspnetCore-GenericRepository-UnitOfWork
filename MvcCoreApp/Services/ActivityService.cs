using Microsoft.EntityFrameworkCore;
using MvcCoreApp.Data;
using MvcCoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreApp.Services
{
    public class ActivityService : IActivityService
    {
        private readonly IGenericRepository<Activity> _repository;

        public ActivityService(IGenericRepository<Activity> repository)
        {
            _repository = repository;
        }


        public List<Activity> GetAll()
        {
            List<Activity> list = _repository.GetAll()
                                             .Include(a => a.PersonActivities)
                                                .ThenInclude(pa => pa.Activity)
                                             .ToList();
            return list;
        }


        public async Task<List<Activity>> GetAllAsync()
        {
            return (await _repository.GetAllAsync()).ToList();
        }



        public async Task<List<Activity>> GetAllWithIncludeAsync(string relatedEntities)
        {
            return (await _repository.GetAllWithIncludeAsync(relatedEntities)).ToList();
        }


        public Activity GetById(Guid? id)
        {
            if (id == null)
                return null;

            Activity activity = _repository.GetBy(a => a.Id == id)
                                       .Include(p => p.PersonActivities)
                                           .ThenInclude(pa => pa.Activity)
                                       .FirstOrDefault();

            return activity;
        }



        public Activity Create(Activity activity)
        {
            return _repository.Insert(activity);
        }



        public Activity Update(Activity activity)
        {
            return _repository.Update(activity);
        }



        public void Delete(Activity activity)
        {
            _repository.Delete(activity);
        }
    }
}