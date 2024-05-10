using eReminderServer.Domain.Entities;
using MediatR;
using TS.Result;

namespace eReminderServer.Application.Features.Gardeners.GetAllGardeners
{
    public sealed record GetAllGardenersQuery() : IRequest<Result<List<Gardener>>>;
}
