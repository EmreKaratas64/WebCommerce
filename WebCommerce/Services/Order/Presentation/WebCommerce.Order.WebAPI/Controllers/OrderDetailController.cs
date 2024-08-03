using Microsoft.AspNetCore.Mvc;
using WebCommerce.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using WebCommerce.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;
using WebCommerce.Order.Application.Features.CQRS.Queries.OrderDetailQueries;

namespace WebCommerce.Order.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly CreateOrderDetailCommandHandler _createOrderDetailCommandHandler;
        private readonly GetOrderDetailByIdQueryHandler _getOrderDetailByIdQueryHandler;
        private readonly GetOrderDetailQueryHandler _getOrderDetailQueryHandler;
        private readonly RemoveOrderDetailCommandHandler _removeOrderDetailCommandHandler;
        private readonly UpdateOrderDetailCommandHandler _updateOrderDetailCommandHandler;

        public OrderDetailController(CreateOrderDetailCommandHandler createOrderDetailCommandHandler, GetOrderDetailByIdQueryHandler getOrderDetailByIdQueryHandler, GetOrderDetailQueryHandler getOrderDetailQueryHandler, RemoveOrderDetailCommandHandler removeOrderDetailCommandHandler, UpdateOrderDetailCommandHandler updateOrderDetailCommandHandler)
        {
            _createOrderDetailCommandHandler = createOrderDetailCommandHandler;
            _getOrderDetailByIdQueryHandler = getOrderDetailByIdQueryHandler;
            _getOrderDetailQueryHandler = getOrderDetailQueryHandler;
            _removeOrderDetailCommandHandler = removeOrderDetailCommandHandler;
            _updateOrderDetailCommandHandler = updateOrderDetailCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> OrderDetailList()
        {
            var values = await _getOrderDetailQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderDetailById(int id)
        {
            var value = await _getOrderDetailByIdQueryHandler.Handle(new GetOrderDetailByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderDetail(CreateOrderDetailCommand command)
        {
            await _createOrderDetailCommandHandler.Handle(command);
            return Ok("OrderDetail is created");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteOrderDetail(RemoveOrderDetailCommand command)
        {
            await _removeOrderDetailCommandHandler.Handle(command);
            return Ok("OrderDetail is deleted");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrderDetail(UpdateOrderDetailCommand command)
        {
            await _updateOrderDetailCommandHandler.Handle(command);
            return Ok("OrderDetail is updated");
        }
    }
}
