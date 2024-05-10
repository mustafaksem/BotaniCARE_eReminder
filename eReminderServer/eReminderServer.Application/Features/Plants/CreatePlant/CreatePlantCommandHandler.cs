using AutoMapper;
using eReminderServer.Domain.Entities;
using eReminderServer.Domain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace eReminderServer.Application.Features.Plants.CreatePlant;

internal sealed class CreatePlantCommandHandler(
    IPlantRepository plantRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IRequestHandler<CreatePlantCommand, Result<string>>
{
    public async Task<Result<string>> Handle(CreatePlantCommand request, CancellationToken cancellationToken)
    {
        Plant plant = mapper.Map<Plant>(request);
        await plantRepository.AddAsync(plant, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "Plant create is successful";
    }
}
