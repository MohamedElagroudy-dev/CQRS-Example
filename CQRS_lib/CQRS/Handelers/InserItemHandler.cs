using CQRS_lib.CQRS.Commands;
using CQRS_lib.Data;
using CQRS_lib.Data.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS_lib.CQRS.Handlers
{
    internal class InsertItemHandler : IRequestHandler<InsertItemsCommand, Items>
    {
        private readonly AppDbContext context;

        public InsertItemHandler(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<Items> Handle(InsertItemsCommand request, CancellationToken cancellationToken)
        {
            await context.Items.AddAsync(request.Item);
            await context.SaveChangesAsync();

            return await Task.FromResult(request.Item);
        }
    }
}
