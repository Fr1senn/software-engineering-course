using Microsoft.AspNetCore.Mvc;
using SoftwareEngineering.Models.DTOs;

namespace SoftwareEngineering.Interfaces
{
    public interface IOrderRepository
    {
        public Task<IEnumerable<OrderDTO>> GetOrdersAsync();
        public Task DeleteOrderAsync(int orderId);
        public Task CreateOrderAsync(OrderDTO orderDTO);
    }
}
