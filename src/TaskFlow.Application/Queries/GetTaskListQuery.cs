using MediatR;
using TaskFlow.Model;

namespace TaskFlow.Application.Queries;

public class GetTaskListQuery : IRequest<IEnumerable<TaskDto>>
{

}
