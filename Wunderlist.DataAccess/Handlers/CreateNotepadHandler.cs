using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Wunderlist.DataAccess.Commands;
using Wunderlist.DataAccess.Models;
using Wunderlist.DataStore;
using Wunderlist.DataStore.Models;

namespace Wunderlist.DataAccess.Handlers
{
    public class CreateNotepadHandler
        : IRequestHandler<CreateNotepadCommand, NotepadInfo>
    {
        private readonly WunderlistContext _db;

        public CreateNotepadHandler(WunderlistContext db)
        {
            _db = db;
        }

        public async Task<NotepadInfo> Handle(
            CreateNotepadCommand command,
            CancellationToken cancellationToken)
        {
            var notepad = new Notepad
            {
                Title = command.Title
            };

            var result = _db.Notepads.Add(notepad);
            await _db.SaveChangesAsync();
            return new NotepadInfo()
            {
                Id = result.Entity.Id,
                Title = result.Entity.Title
            };
        }
    }
}
