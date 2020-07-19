using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using MediatR;
using Wunderlist.DataAccess.Models;
using Wunderlist.DataAccess.Queries;
using Wunderlist.DataStore;

namespace Wunderlist.DataAccess.Handlers
{
    public class GetAllTasksOfNotepadQueryHandler
        : IRequestHandler<GetAllTasksOfNotepadQuery, List<TaskInfo>>
    {
        private readonly WunderlistContext _db;

        public GetAllTasksOfNotepadQueryHandler(WunderlistContext db)
        {
            _db = db;
        }

        public async Task<List<TaskInfo>> Handle(
            GetAllTasksOfNotepadQuery request,
            CancellationToken cancellationToken)
        {
            return _db.Notepads
                .SelectMany(
                    n => n.Tasks,
                    (n, t) => new { Notepad = n, Tasks = t })
                .Where(x => x.Notepad.Id == request.NotepadId)
                .Select(x => x.Tasks)
                .Select(x => new TaskInfo()
                {
                    Id = x.Id,
                    Title = x.Title
                })
                .ToList();
        }
    }
}
