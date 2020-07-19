using MediatR;
using Wunderlist.DataAccess.Models;

namespace Wunderlist.DataAccess.Commands
{
    public class AddTaskToNotepadCommand
        : IRequest<TaskInfo>
    {
        public int NotepadId { get; set; }
        public string TaskTitle { get; set; }
    }
}
