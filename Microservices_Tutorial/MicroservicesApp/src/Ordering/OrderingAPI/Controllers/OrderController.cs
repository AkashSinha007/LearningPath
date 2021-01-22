using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrderingApplication.Commands;
using OrderingApplication.Queries;
using OrderingApplication.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace OrderingAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class OrderController:ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<OrderResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<OrderResponse>>> GetOrdersByUserName(string userName)
        {
            var query = new GetOrderByUserNameQuery(userName);
            var orders = await _mediator.Send(query);
            return Ok(orders);
        }

        //Added for testing purpose
        [HttpPost]
        [ProducesResponseType(typeof(OrderResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CheckoutOrder([FromBody] CheckoutOrderCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
