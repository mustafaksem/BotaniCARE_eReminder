﻿using eReminderServer.Application.Features.Auth.Login;
using eReminderServer.WebAPI.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eReminderServer.WebAPI.Controllers
{
   
    public sealed class AuthController :ApiController
    {
        public AuthController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginCommand request,CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request,cancellationToken);
            return StatusCode(response.StatusCode,response);
        }
    }
}