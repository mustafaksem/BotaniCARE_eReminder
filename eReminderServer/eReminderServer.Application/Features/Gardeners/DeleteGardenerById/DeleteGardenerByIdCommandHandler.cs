using eReminderServer.Domain.Entities;
using eReminderServer.Domain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace eReminderServer.Application.Features.Gardeners.DeleteGardenerById
{
    internal sealed class DeleteGardenerByIdCommandHandler(
        IGardenerRepository gardenerRepository,
        IUnitOfWork unitOfWork) : IRequestHandler<DeleteGardenerByIdCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(DeleteGardenerByIdCommand request, CancellationToken cancellationToken)
        {
            Gardener? gardener = await gardenerRepository.GetByExpressionAsync(p => p.Id == request.Id, cancellationToken);
            if (gardener is null)
            {
                return Result<string>.Failure("Gardener is not found");
            }
            gardenerRepository.Delete(gardener);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return "Gardener delete is successful";
        }
    }
}
