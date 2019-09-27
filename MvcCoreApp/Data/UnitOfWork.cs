using MvcCoreApp.Services;

namespace MvcCoreApp.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _ctx;

        public IPersonService PersonService { get; }
        public IJobService JobService { get; }
        public IActivityService ActivityService { get; }

        public UnitOfWork(
            AppDbContext context,
            IPersonService personService,
            IJobService jobService,
            IActivityService activityService
            )
        {
            _ctx = context;
            PersonService = personService;
            JobService = jobService;
            ActivityService = activityService;
        }

        public void Save()
        {
            _ctx.SaveChanges();
        }

        public void Dispose()
        {
            _ctx.Dispose();
        }
    }
}