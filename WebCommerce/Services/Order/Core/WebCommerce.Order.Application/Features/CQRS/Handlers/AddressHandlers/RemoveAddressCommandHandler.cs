using WebCommerce.Order.Application.Features.CQRS.Commands.AddressCommands;
using WebCommerce.Order.Application.Interfaces;
using WebCommerce.Order.Domain.Entities;

namespace WebCommerce.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class RemoveAddressCommandHandler
    {
        private readonly IRepository<Address> _repository;

        public RemoveAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveAddressCommand command)
        {
            var value = await _repository.GetByIdAsync(command.Id);
            await _repository.DeleteAsync(value);
        }
    }
}
