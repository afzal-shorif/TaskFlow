using MediatR;
using TaskFlow.Model;
using TaskFlow.Application.Commands;
using TaskFlow.Infrastructure;
using TaskFlow.Domain.Entities;

namespace TaskFlow.Application.Handlers;

public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, Guid>
{
    private readonly AppDbContext _dbContext;

    public CreateTaskCommandHandler(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Guid> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    {
        var task = new TaskEntity
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            Description = request.Description,
            CreatedBy = Guid.Empty,
            // TODO: Inject current user and replace with the user id
            CreatedAt = DateTimeOffset.UtcNow,
        };

        await _dbContext.Tasks.AddAsync(task);
        await _dbContext.SaveChangesAsync();

        return task.Id;
    }
}
