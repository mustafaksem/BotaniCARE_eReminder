using eReminderServer.Domain.Entities;
using eReminderServer.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace eReminderServer.Application.Features.Gardeners.GetAllGardeners
{
    internal sealed class GetAllGardenerQueryHandler(
        IGardenerRepository gardenerRepository) : IRequestHandler<GetAllGardenersQuery, Result<List<Gardener>>>
    {
        public async Task<Result<List<Gardener>>> Handle(GetAllGardenersQuery request, CancellationToken cancellationToken)
        {
            List<Gardener> gardeners = await gardenerRepository.GetAll().OrderBy(p => p.FirstName).ToListAsync(cancellationToken); return gardeners;
        }
    }
}
