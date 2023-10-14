using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoftwareEngineering.Interfaces;
using SoftwareEngineering.Models;
using SoftwareEngineering.Models.DTOs;
using System.Net;

namespace SoftwareEngineering.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly LibraryContext _libraryContext;

        public OrderRepository(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }

        public async Task CreateOrderAsync(OrderDTO orderDTO)
        {
            if (orderDTO is null)
                throw new NullReferenceException("Invalid data");

            Book? book = await _libraryContext.Books.FirstOrDefaultAsync(b => b.Title == orderDTO.Book.Title);

            if (book is null)
                throw new NullReferenceException("Book not found");

            Reader? reader = await _libraryContext.Readers.FirstOrDefaultAsync(r => r.FullName == orderDTO.Reader.FullName);

            if (reader is null)
                throw new NullReferenceException("Reader not found");

            Order order = new Order
            {
                OrderDate = DateOnly.FromDateTime(DateTime.Now),
                RefundDate = orderDTO.RefundDate,
                Book = book,
                Reader = reader,
            };

            _libraryContext.Orders.Add(order);
            await _libraryContext.SaveChangesAsync();
        }

        public async Task DeleteOrderAsync(int orderId)
        {
            Order? order = await _libraryContext.Orders.FindAsync(orderId);
            if (order is null)
                throw new NullReferenceException("Order not found");
            _libraryContext.Orders.Remove(order);
            await _libraryContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<OrderDTO>> GetOrdersAsync()
        {
            List<OrderDTO> orders = await _libraryContext.Orders
                .Include(o => o.Book)
                .Include(o => o.Reader)
                .Select(o => new OrderDTO
                {
                    Id = o.Id,
                    OrderDate = o.OrderDate,
                    RefundDate = o.RefundDate,
                    Book = o.Book,
                    Reader = o.Reader
                })
                .AsNoTracking()
                .ToListAsync();
            return orders;
        }
    }
}
