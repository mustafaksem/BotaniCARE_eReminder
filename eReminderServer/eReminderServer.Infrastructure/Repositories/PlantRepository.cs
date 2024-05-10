using eReminderServer.Domain.Entities;
using eReminderServer.Domain.Repositories;
using eReminderServer.Infrastructure.Context;
using GenericRepository;

namespace eReminderServer.Infrastructure.Repositories
{
    internal sealed class PlantRepository : Repository<Plant, ApplicationDbContext>, IPlantRepository
    {
        public PlantRepository(ApplicationDbContext context) : base(context)
        {
        }
    }    
}
