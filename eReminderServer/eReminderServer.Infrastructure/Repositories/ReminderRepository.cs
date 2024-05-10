using eReminderServer.Domain.Entities;
using eReminderServer.Domain.Repositories;
using eReminderServer.Infrastructure.Context;
using GenericRepository;

namespace eReminderServer.Infrastructure.Repositories
{
    internal sealed class ReminderRepository : Repository<Reminder, ApplicationDbContext>, IReminderRepository
    {
        public ReminderRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
