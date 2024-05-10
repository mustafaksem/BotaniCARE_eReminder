using AutoMapper;
using eReminderServer.Domain.Entities;
using eReminderServer.Domain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace eReminderServer.Application.Features.Gardeners.CreateGardener
{
    internal sealed class CreateGardenerCommandHandler(
    IGardenerRepository gardenerRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IRequestHandler<CreateGardenerCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(CreateGardenerCommand request, CancellationToken cancellationToken)
        {
            Gardener gardener = mapper.Map<Gardener>(request);

            await gardenerRepository.AddAsync(gardener, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return "Gardener create is successful";
        }
    }
}
