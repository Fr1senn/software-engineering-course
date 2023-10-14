using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoftwareEngineering.Interfaces;
using SoftwareEngineering.Models.DTOs;
using SoftwareEngineering.Repositories;

namespace SoftwareEngineering.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrdersAsync()
        {
            return Ok(await _orderRepository.GetOrdersAsync());
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteOrderAsync([FromQuery] int orderId)
        {
            try
            {
                await _orderRepository.DeleteOrderAsync(orderId);
                return Ok();
            }
            catch (NullReferenceException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderAsync([FromBody] OrderDTO orderDTO)
        {
            try
            {
                await _orderRepository.CreateOrderAsync(orderDTO);
                return Ok();
            }
            catch(NullReferenceException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
