using eReminderServer.Application.Features.Gardeners.GetAllGardeners;
using eReminderServer.Application.Features.Reminders.CreateReminder;
using eReminderServer.Application.Features.Reminders.DeleteReminderById;
using eReminderServer.Application.Features.Reminders.GetAllReminders;
using eReminderServer.Application.Features.Reminders.GetPlantByName;
using eReminderServer.Application.Features.Reminders.UpdateReminder;
using eReminderServer.WebAPI.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eReminderServer.WebAPI.Controllers
{
    public sealed class RemindersController : ApiController
    {
        public RemindersController(IMediator mediator) : base(mediator)
        {
        }
        [HttpPost]
        public async Task<IActionResult> GetAllGardenerById(GetAllRemindersQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode,response);
        }
        [HttpPost]
        public async Task<IActionResult> GetPlantByName(GetPlantByNameQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateReminderCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteById(DeleteReminderByIdCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateReminderCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
    }
}
