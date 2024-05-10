using AutoMapper;
using eReminderServer.Application.Features.Gardeners.CreateGardener;
using eReminderServer.Application.Features.Gardeners.UpdateGardener;
using eReminderServer.Application.Features.Plants.CreatePlant;
using eReminderServer.Application.Features.Plants.UpdatePlant;
using eReminderServer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eReminderServer.Application.Mapping
{
    public sealed class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<CreateGardenerCommand, Gardener>();

            CreateMap<UpdateGardenerCommand,Gardener>();

            CreateMap<CreatePlantCommand,Plant>();
            CreateMap<UpdatePlantCommand,Plant>();
        }
    }
}
