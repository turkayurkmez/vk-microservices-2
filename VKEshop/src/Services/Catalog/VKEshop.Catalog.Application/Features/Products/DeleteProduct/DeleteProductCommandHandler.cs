using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VKEshop.Catalog.Application.Contracts.Repository;

namespace VKEshop.Catalog.Application.Features.Products.DeleteProduct
{
    public record DeleteProductCommand(int Id): IRequest<Unit>;
    internal class DeleteProductCommandHandler(IProductRepository repository) : IRequestHandler<DeleteProductCommand, Unit>
    {
        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            await repository.Delete(request.Id);
            return Unit.Value;
        }
    }
}
