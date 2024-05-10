using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace eReminderServer.Application.Features.Reminders.UpdateReminder;

public sealed record UpdateReminderCommand(
    Guid Id,
    string Startdate,
    string EndDate): IRequest<Result<string>>;
