using eReminderServer.Domain.Entities;
using eReminderServer.Domain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace eReminderServer.Application.Features.Plants.DeletePlantById;

internal sealed class DeletePlantByIdCommandHandler(
    IPlantRepository plantRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<DeletePlantByIdCommand, Result<string>>
{
    public async Task<Result<string>> Handle(DeletePlantByIdCommand request, CancellationToken cancellationToken)
    {
        Plant? plant = await plantRepository.GetByExpressionAsync(p=> p.Id == request.Id, cancellationToken);
        if (plant == null)
        {
            return Result<string>.Failure("Plant not found");
        }
        plantRepository.Delete(plant);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "Plant delete is successful";
    }
}
