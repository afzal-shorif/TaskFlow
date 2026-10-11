using MediatR;
using TaskFlow.Application.Queries;
using TaskFlow.Model;
using TaskFlow.Infrastructure;

namespace TaskFlow.Application.Handlers;

public class GetTaskQueryHandler : IRequestHandler<GetTaskQuery, TaskDto>
{
    private readonly AppDbContext _db;

    public GetTaskQueryHandler(AppDbContext db)
    {
        _db = db;
    }

    public async Task<TaskDto> Handle(GetTaskQuery request, CancellationToken cancellationToken)
    {
        var task = _db.Tasks.Where(t => t.Id == request.Id).Select(t => new TaskDto
        {
            Id = t.Id,
            Title = t.Title
        }).First();

        return task;
    }
}
