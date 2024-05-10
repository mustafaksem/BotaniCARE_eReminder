using AutoMapper;
using eReminderServer.Domain.Entities;
using eReminderServer.Domain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace eReminderServer.Application.Features.Plants.UpdatePlant;

internal sealed class UpdatePlantCommandHandler(
    IPlantRepository plantRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IRequestHandler<UpdatePlantCommand, Result<string>>
{
    public async Task<Result<string>> Handle(UpdatePlantCommand request, CancellationToken cancellationToken)
    {
        Plant? plant =await plantRepository.GetByExpressionWithTrackingAsync(p=>p.Id== request.Id,cancellationToken);
        if (plant == null)
        {
            return Result<string>.Failure("Plant not found");
        }

        mapper.Map(request, plant);
        plantRepository.Update(plant);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "plant update is successful";
    }
}
