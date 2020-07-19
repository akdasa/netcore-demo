using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Wunderlist.Api.Responses;
using Wunderlist.Api.Requests;
using Wunderlist.DataAccess.Queries;
using Wunderlist.DataAccess.Commands;

namespace Wunderlist.Controllers.Api
{
    [Route("[controller]")]
    [ApiController()]
    public class NotepadsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public NotepadsController(
            IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<NotepadInfoResponse>))]
        public async Task<IActionResult> GetAllNotepads()
        {
            var result = await _mediator.Send(new GetAllNotepadsQuery());
            return Ok(result);
        }

        [HttpGet("{notepadId:int}/tasks")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<TaskInfoResponse>))]
        public async Task<IActionResult> GetAllTasks(int notepadId)
        {
            var result = await _mediator.Send(new GetAllTasksOfNotepadQuery()
            {
                NotepadId = notepadId
            });
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(200)]
        public void CreateNotepad(CreateNotepadRequest request)
        {
            _mediator.Send(new CreateNotepadCommand()
            {
                Title = request.Title
            });
        }

        [HttpPost("{notepadId:int}/tasks")]
        public void CreateTask(int notepadId, CreateTaskRequest request)
        {
            _mediator.Send(new AddTaskToNotepadCommand()
            {
                NotepadId = notepadId,
                TaskTitle = request.Title
            });
        }
    }
}
