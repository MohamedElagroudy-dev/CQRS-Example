using CQRS_lib.CQRS.Queries;
using CQRS_lib.Data;
using CQRS_lib.Data.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS_lib.CQRS.Handlers
{
    internal class GetItemsListHandler : IRequestHandler<GetAllItemsQuery, List<Items>>
    {
        private readonly AppDbContext _db;

        public GetItemsListHandler(AppDbContext db)
        {
            _db = db;
        }

        public async Task<List<Items>> Handle(GetAllItemsQuery request, CancellationToken cancellationToken)
        {
            var items = await _db.Items.ToListAsync();
            return await Task.FromResult(items);
        }
    }
}
