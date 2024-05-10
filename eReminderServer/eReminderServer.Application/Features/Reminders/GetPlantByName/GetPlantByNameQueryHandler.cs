using eReminderServer.Domain.Entities;
using eReminderServer.Domain.Repositories;
using MediatR;
using TS.Result;

namespace eReminderServer.Application.Features.Reminders.GetPlantByName;

internal sealed class GetPlantByNameQueryHandler(
        IPlantRepository plantRepository) : IRequestHandler<GetPlantByNameQuery, Result<Plant>>
{
    public async Task<Result<Plant>> Handle(GetPlantByNameQuery request, CancellationToken cancellationToken)
    {
        Plant? plant = await plantRepository.GetByExpressionAsync(p => p.Name == request.name, cancellationToken);
        return plant;
    }
}
