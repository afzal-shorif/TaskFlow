using Microsoft.AspNetCore.Mvc;
using MediatR;
using TaskFlow.Model;
using TaskFlow.Application.Commands;
using TaskFlow.Application.Queries;

[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    private readonly IMediator _mediator;

    public TasksController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        var taskList = _mediator.Send(new GetTaskListQuery());
        return Ok(taskList);
    }

    [HttpGet("/{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var task = _mediator.Send(new GetTaskQuery(id));

        if (task == null)
        {
            return NotFound();
        }

        return Ok(task);
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateAsync(CreateTaskDot taskDto, CancellationToken cancellationToken)
    {
        var taskId = await _mediator.Send(new CreateTaskCommand(taskDto.Title, taskDto.Description));

        if (taskId == Guid.Empty)
        {
            return StatusCode(500, "Unable to create task");
        }

        return CreatedAtAction("Task", new { id = taskId });
    }
}
