using eReminderServer.Domain.Entities;

namespace eReminderServer.Application.Features.Reminders.GetAllReminders;

public sealed record GetAllRemindersQueryResponse(
    Guid id,
    DateTime StartDate,
    DateTime EndDate,
    string Title,
    Plant Plant);
