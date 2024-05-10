using eReminderServer.Domain.Entities;
using eReminderServer.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace eReminderServer.Application.Features.Plants.GetAllPlant;

internal sealed class GetAllPlantQueryHandler(
    IPlantRepository plantRepository) : IRequestHandler<GetAllPlantQuery, Result<List<Plant>>>
{
    public async Task<Result<List<Plant>>> Handle(GetAllPlantQuery request, CancellationToken cancellationToken)
    {
        List<Plant> plants=await plantRepository.GetAll().OrderBy(p=> p.Name).ToListAsync(cancellationToken); 
        
        return plants;
    }
}
