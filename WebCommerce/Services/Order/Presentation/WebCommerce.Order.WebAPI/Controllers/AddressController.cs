using Microsoft.AspNetCore.Mvc;
using WebCommerce.Order.Application.Features.CQRS.Commands.AddressCommands;
using WebCommerce.Order.Application.Features.CQRS.Handlers.AddressHandlers;
using WebCommerce.Order.Application.Features.CQRS.Queries.AddressQueries;

namespace WebCommerce.Order.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly CreateAddressCommandHandler _createAddressCommandHandler;
        private readonly GetAddressByIdQueryHandler _getAddressByIdQueryHandler;
        private readonly GetAddressQueryHandler _getAddressQueryHandler;
        private readonly RemoveAddressCommandHandler _removeAddressCommandHandler;
        private readonly UpdateAddressCommandHandler _updateAddressCommandHandler;

        public AddressController(CreateAddressCommandHandler createAddressCommandHandler, GetAddressByIdQueryHandler getAddressByIdQueryHandler, GetAddressQueryHandler getAddressQueryHandler, RemoveAddressCommandHandler removeAddressCommandHandler, UpdateAddressCommandHandler updateAddressCommandHandler)
        {
            _createAddressCommandHandler = createAddressCommandHandler;
            _getAddressByIdQueryHandler = getAddressByIdQueryHandler;
            _getAddressQueryHandler = getAddressQueryHandler;
            _removeAddressCommandHandler = removeAddressCommandHandler;
            _updateAddressCommandHandler = updateAddressCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> AddressList()
        {
            var values = await _getAddressQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAddressById(int id)
        {
            var value = await _getAddressByIdQueryHandler.Handle(new GetAddressByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAddress(CreateAddressCommand command)
        {
            await _createAddressCommandHandler.Handle(command);
            return Ok("Address is created");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAddress(RemoveAddressCommand command)
        {
            await _removeAddressCommandHandler.Handle(command);
            return Ok("Address is deleted");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAddress(UpdateAddressCommand command)
        {
            await _updateAddressCommandHandler.Handle(command);
            return Ok("Address is updated");
        }
    }
}
