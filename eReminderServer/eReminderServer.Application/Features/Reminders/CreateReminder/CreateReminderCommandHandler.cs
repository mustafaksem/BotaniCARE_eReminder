using eReminderServer.Domain.Entities;
using eReminderServer.Domain.Repositories;
using GenericRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using TS.Result;

namespace eReminderServer.Application.Features.Reminders.CreateReminder;

internal sealed class CreateReminderCommandHandler (
    IReminderRepository reminderRepository,
    IUnitOfWork unitOfWork,
    IPlantRepository plantRepository) : IRequestHandler<CreateReminderCommand, Result<string>>
{
    public async Task<Result<string>> Handle(CreateReminderCommand request, CancellationToken cancellationToken)
    {
        Plant plant = new();
        if (request.PlantId is null)
        {
            plant = new()
            {
                Name = request.Name,
                Description = request.Description
            };
            await plantRepository.AddAsync(plant,cancellationToken);
        }
        Reminder reminder = new()
        {
            GardenerId = request.GardenerId,
            PlantId = request.PlantId ?? plant.Id,
            StartDate = Convert.ToDateTime(request.StartDate),
            EndDate = Convert.ToDateTime(request.EndDate),
            IsCompleted = false
        };
        await reminderRepository.AddAsync(reminder,cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "Reminder is successful";
    }
}
