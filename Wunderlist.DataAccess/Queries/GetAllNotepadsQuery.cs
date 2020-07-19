using System.Collections.Generic;
using MediatR;
using Wunderlist.DataAccess.Models;

namespace Wunderlist.DataAccess.Queries
{
    public class GetAllNotepadsQuery
        : IRequest<List<NotepadInfo>>
    {
    }
}
