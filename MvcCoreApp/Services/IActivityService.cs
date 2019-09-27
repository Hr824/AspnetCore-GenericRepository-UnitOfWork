using MvcCoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreApp.Services
{
    public interface IActivityService
    {
        List<Activity> GetAll();
        Task<List<Activity>> GetAllAsync();
        Task<List<Activity>> GetAllWithIncludeAsync(string relatedEntities);

        Activity GetById(Guid? id);
        Activity Create(Activity activity);
        Activity Update(Activity activity);
        void Delete(Activity activity);
    }
}
