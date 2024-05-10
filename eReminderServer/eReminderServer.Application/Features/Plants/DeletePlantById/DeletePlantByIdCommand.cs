using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace eReminderServer.Application.Features.Plants.DeletePlantById;

public sealed record DeletePlantByIdCommand(
    Guid Id):IRequest<Result<string>>;
