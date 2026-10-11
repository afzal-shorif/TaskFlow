using MediatR;
using TaskFlow.Model;
using TaskFlow.Infrastructure;
using TaskFlow.Application.Queries;

namespace TaskFlow.Application.Handlers;

public class GetTaskListQueryHandler : IRequestHandler<GetTaskListQuery, IEnumerable<TaskDto>>
{
    private readonly AppDbContext _db;

    public GetTaskListQueryHandler(AppDbContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<TaskDto>> Handle(GetTaskListQuery request, CancellationToken cancellationToken)
    {
        var tasks = _db.Tasks.Select(t => new TaskDto
        {
            Id = t.Id,
            Title = t.Title,
            Description = t.Description
        }).ToList();

        return tasks;
    }
}
