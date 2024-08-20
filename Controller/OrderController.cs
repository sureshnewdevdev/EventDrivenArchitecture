using EventDrivenArchitecture.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventDrivenArchitecture.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _orderService;

        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        [Route("create")]
        public IActionResult CreateOrder([FromBody] OrderCreateRequest request)
        {
            _orderService.CreateOrder(Guid.NewGuid(), request.ProductName, request.Quantity);
            return Ok("Order created and event published.");
        }
    }

    public class OrderCreateRequest
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
    }

}
