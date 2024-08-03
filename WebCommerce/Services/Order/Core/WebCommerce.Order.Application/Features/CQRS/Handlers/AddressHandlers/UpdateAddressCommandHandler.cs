using WebCommerce.Order.Application.Features.CQRS.Commands.AddressCommands;
using WebCommerce.Order.Application.Interfaces;
using WebCommerce.Order.Domain.Entities;

namespace WebCommerce.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class UpdateAddressCommandHandler
    {
        private readonly IRepository<Address> _repository;


        public UpdateAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateAddressCommand command)
        {
            var values = await _repository.GetByIdAsync(command.AddressId);
            values.Detail1 = command.Detail;
            values.District = command.District;
            values.City = command.City;
            values.UserId = command.UserId;
            await _repository.UpdateAsync(values);
        }
    }
}
