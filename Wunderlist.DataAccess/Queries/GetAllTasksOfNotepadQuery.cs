using System.Collections.Generic;
using MediatR;
using Wunderlist.DataAccess.Models;

namespace Wunderlist.DataAccess.Queries
{
    public class GetAllTasksOfNotepadQuery
        : IRequest<List<TaskInfo>>
    {
        public int NotepadId { get; set; }
    }
}
