using eReminderServer.Domain.Entities;
using eReminderServer.Domain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace eReminderServer.Application.Features.Reminders.UpdateReminder;

internal sealed class UpdateReminderCommandHandler(
    IReminderRepository reminderRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<UpdateReminderCommand, Result<string>>
{
    public async Task<Result<string>> Handle(UpdateReminderCommand request, CancellationToken cancellationToken)
    {
        Reminder? reminder = await reminderRepository.GetByExpressionWithTrackingAsync(p => p.Id == request.Id, cancellationToken);
        if (reminder == null)
        {
            return Result<string>.Failure("Reminder not found");
        }

        reminder.StartDate = Convert.ToDateTime(request.Startdate);
        reminder.EndDate = Convert.ToDateTime(request.EndDate);

        await unitOfWork.SaveChangesAsync(cancellationToken);
        return "Reminder update is successful";
    }
}
