using eReminderServer.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace eReminderServer.Application.Features.Reminders.CreateReminder;

public sealed record CreateReminderCommand(
    string StartDate,
    string EndDate,
    Guid GardenerId,
    Guid? PlantId,
    string Name,
    string Description): IRequest<Result<string>>;


