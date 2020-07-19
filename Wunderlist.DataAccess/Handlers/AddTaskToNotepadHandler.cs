using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using MediatR;
using System;
using Wunderlist.DataAccess.Commands;
using Wunderlist.DataAccess.Models;
using Wunderlist.DataStore;

namespace Wunderlist.DataAccess.Handlers
{
    public class AddTaskToNotepadHandler
        : IRequestHandler<AddTaskToNotepadCommand, TaskInfo>
    {
        private readonly WunderlistContext _db;

        public AddTaskToNotepadHandler(WunderlistContext db)
        {
            _db = db;
        }

        public async Task<TaskInfo> Handle(
            AddTaskToNotepadCommand command,
            CancellationToken cancellationToken)
        {
            // Find notepad by specified Id
            var notepad = _db.Notepads
                .FirstOrDefault(x => x.Id == command.NotepadId);
            if (notepad == null)
            {
                throw new Exception($"Cannot find Notepad with Id '{command.NotepadId}'");
            }

            // Create new task
            var task = new DataStore.Models.Task()
            {
                Title = command.TaskTitle
            };
            notepad.Tasks.Add(task);

            // Save all the changes
            var model = await _db.Tasks.AddAsync(task);
            await _db.SaveChangesAsync();
            return new TaskInfo()
            {
                Id = model.Entity.Id,
                Title = model.Entity.Title
            };
        }
    }
}
