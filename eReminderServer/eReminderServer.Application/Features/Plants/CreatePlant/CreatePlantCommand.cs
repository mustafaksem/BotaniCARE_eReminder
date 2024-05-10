using AutoMapper;
using eReminderServer.Domain.Entities;
using eReminderServer.Domain.Repositories;
using GenericRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace eReminderServer.Application.Features.Plants.CreatePlant;

public sealed record CreatePlantCommand(
    string name,
    string description) : IRequest<Result<string>>;

