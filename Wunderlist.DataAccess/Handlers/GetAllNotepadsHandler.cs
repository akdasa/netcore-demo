using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using System.Linq;
using Wunderlist.DataAccess.Models;
using Wunderlist.DataAccess.Queries;
using Wunderlist.DataStore;

namespace Wunderlist.DataAccess.Handlers
{
    public class GetAllNotepadsHandler
        : IRequestHandler<GetAllNotepadsQuery, List<NotepadInfo>>
    {
        private readonly WunderlistContext _db;

        public GetAllNotepadsHandler(WunderlistContext db)
        {
            _db = db;
        }

        public async Task<List<NotepadInfo>> Handle(
            GetAllNotepadsQuery request,
            CancellationToken cancellationToken)
        {
            return _db.Notepads.Select(x => new NotepadInfo()
            {
                Id = x.Id,
                Title = x.Title
            }).ToList();
        }
    }
}
