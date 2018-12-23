using NetChan.Entities;

namespace NetChan.App.Threads
{
    public class ThreadService
    {
        private readonly NetchanDbContext dbContext;

        public ThreadService(NetchanDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}