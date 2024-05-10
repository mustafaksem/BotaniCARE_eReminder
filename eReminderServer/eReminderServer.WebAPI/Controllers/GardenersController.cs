using eReminderServer.Application.Features.Gardeners.CreateGardener;
using eReminderServer.Application.Features.Gardeners.DeleteGardenerById;
using eReminderServer.Application.Features.Gardeners.GetAllGardeners;
using eReminderServer.Application.Features.Gardeners.UpdateGardener;
using eReminderServer.WebAPI.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eReminderServer.WebAPI.Controllers
{
    public class GardenersController : ApiController
    {
        public GardenersController(IMediator mediator) : base(mediator)
        {
        }
        [HttpPost]
        public async Task<IActionResult> GetAll(GetAllGardenersQuery request,CancellationToken cancellationToken)
        {
            var response =await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateGardenerCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteById(DeleteGardenerByIdCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateGardenerCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
    }
}
