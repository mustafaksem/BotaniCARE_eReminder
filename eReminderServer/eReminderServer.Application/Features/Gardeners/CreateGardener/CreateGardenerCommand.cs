using MediatR;
using TS.Result;

namespace eReminderServer.Application.Features.Gardeners.CreateGardener
{
    public sealed record CreateGardenerCommand(
        string FirstName,
        string LastName,
        string Mail) : IRequest<Result<string>>;
}
