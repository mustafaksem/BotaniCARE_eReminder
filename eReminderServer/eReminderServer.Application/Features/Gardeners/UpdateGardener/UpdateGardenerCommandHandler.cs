using AutoMapper;
using eReminderServer.Domain.Entities;
using eReminderServer.Domain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace eReminderServer.Application.Features.Gardeners.UpdateGardener;

internal sealed class UpdateGardenerCommandHandler(
    IGardenerRepository gardenerRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IRequestHandler<UpdateGardenerCommand, Result<string>>
{
    public async Task<Result<string>> Handle(UpdateGardenerCommand request, CancellationToken cancellationToken)
    {
        Gardener? gardener = await gardenerRepository.GetByExpressionWithTrackingAsync(p => p.Id == request.Id, cancellationToken);
        if (gardener is null)
        {
            return Result<string>.Failure("Gardener not found.");
        }

        mapper.Map(request, gardener);
        gardenerRepository.Update(gardener);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "Gardener update is successful";
    }
}
