using MediatR;
using Wunderlist.DataAccess.Models;

namespace Wunderlist.DataAccess.Commands
{
    public class CreateNotepadCommand
        : IRequest<NotepadInfo>
    {
        public string Title { get; set; }
    }
}
