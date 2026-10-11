using MediatR;
using TaskFlow.Model;

namespace TaskFlow.Application.Queries;

public record GetTaskQuery(
        Guid Id
) : IRequest<TaskDto>;

