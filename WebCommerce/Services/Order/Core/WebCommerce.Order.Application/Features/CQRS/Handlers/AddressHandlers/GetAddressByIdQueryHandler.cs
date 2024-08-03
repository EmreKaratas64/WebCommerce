using WebCommerce.Order.Application.Features.CQRS.Queries.AddressQueries;
using WebCommerce.Order.Application.Features.CQRS.Results.AddressResults;
using WebCommerce.Order.Application.Interfaces;
using WebCommerce.Order.Domain.Entities;

namespace WebCommerce.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class GetAddressByIdQueryHandler
    {
        private readonly IRepository<Address> _repository;

        public GetAddressByIdQueryHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task<GetAddressByIdQueryResult> Handler(GetAddressByIdQuery getAddressByIdQuery)
        {
            var value = await _repository.GetByIdAsync(getAddressByIdQuery.Id);
            return new GetAddressByIdQueryResult
            {
                AddressId = value.AddressId,
                City = value.City,
                Detail = value.Detail1,
                District = value.District,
                UserId = value.UserId
            };
        }
    }
}
