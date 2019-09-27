using MvcCoreApp.Services;
using System;

namespace MvcCoreApp.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IPersonService PersonService { get; }
        IJobService JobService { get; }
        IActivityService ActivityService { get; }

        void Save();
    }
}