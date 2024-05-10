using eReminderServer.Domain.Entities;
using eReminderServer.Domain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace eReminderServer.Application.Features.Reminders.DeleteReminderById;

internal sealed class DeleteReminderByIdCommandHandler(
    IReminderRepository reminderRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<DeleteReminderByIdCommand, Result<string>>
{
    public async Task<Result<string>> Handle(DeleteReminderByIdCommand request, CancellationToken cancellationToken)
    {
        Reminder? reminder =await reminderRepository.GetByExpressionAsync(p=> p.Id==request.Id,cancellationToken);

        if (reminder == null)
        {
            return Result<string>.Failure("Reminder not found");
        }
        if (reminder.IsCompleted)
        {
            return Result<string>.Failure($"Reminder is completed.");
        }
        reminderRepository.Delete(reminder);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return "Reminder delete is successful";
    }
}
