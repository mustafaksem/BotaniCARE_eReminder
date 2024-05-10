using eReminderServer.Domain.Entities;
using eReminderServer.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace eReminderServer.Application.Features.Reminders.GetAllReminders;

internal sealed class GetAllRemindersQueryHandler(
    IReminderRepository reminderRepository) : IRequestHandler<GetAllRemindersQuery, Result<List<GetAllRemindersQueryResponse>>>
{
    public async Task<Result<List<GetAllRemindersQueryResponse>>> Handle(GetAllRemindersQuery request, CancellationToken cancellationToken)
    {
        List<Reminder> reminders = await reminderRepository.Where(p => p.GardenerId == request.GardenerId).Include(p=>p.Plant).ToListAsync(cancellationToken);

        List<GetAllRemindersQueryResponse> response = reminders.Select(s=> new GetAllRemindersQueryResponse(s.Id,s.StartDate,s.EndDate,s.Plant!.Name,s.Plant)).ToList();
        return response;
    }
}
