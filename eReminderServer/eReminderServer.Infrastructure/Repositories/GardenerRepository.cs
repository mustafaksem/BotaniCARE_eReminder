using eReminderServer.Domain.Entities;
using eReminderServer.Domain.Repositories;
using eReminderServer.Infrastructure.Context;
using GenericRepository;

namespace eReminderServer.Infrastructure.Repositories
{
    internal sealed class GardenerRepository : Repository<Gardener, ApplicationDbContext>, IGardenerRepository
    {
        public GardenerRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
