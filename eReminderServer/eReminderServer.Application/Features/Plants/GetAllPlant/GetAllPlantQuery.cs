using eReminderServer.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace eReminderServer.Application.Features.Plants.GetAllPlant;

public sealed record GetAllPlantQuery():IRequest<Result<List<Plant>>>;
