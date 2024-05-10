using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace eReminderServer.Application.Features.Gardeners.UpdateGardener;

public sealed record UpdateGardenerCommand(
   Guid Id,
   string FirstName,
   string LastName,
   string Mail) : IRequest<Result<string>>;
