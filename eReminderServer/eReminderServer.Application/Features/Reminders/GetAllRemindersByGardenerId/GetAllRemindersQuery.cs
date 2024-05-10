using MediatR;
using TS.Result;

namespace eReminderServer.Application.Features.Reminders.GetAllReminders;

public sealed record GetAllRemindersQuery( Guid GardenerId): IRequest<Result<List<GetAllRemindersQueryResponse>>>;
