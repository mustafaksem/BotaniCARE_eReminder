using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace eReminderServer.Application.Features.Plants.UpdatePlant;

public sealed record UpdatePlantCommand(
    Guid Id,
    string Name,
    string Description) : IRequest<Result<string>>;
