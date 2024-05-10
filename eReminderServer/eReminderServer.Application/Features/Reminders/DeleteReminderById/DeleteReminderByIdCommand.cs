using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace eReminderServer.Application.Features.Reminders.DeleteReminderById;

public sealed record DeleteReminderByIdCommand(
    Guid Id) : IRequest<Result<string>>;
