using MediatR;
using TS.Result;

namespace eReminderServer.Application.Features.Gardeners.DeleteGardenerById;

public sealed record DeleteGardenerByIdCommand(Guid Id) : IRequest<Result<string>>;
