namespace SoftwareEngineering.Models.DTOs
{
    public class BookDTO
    {
        public int? Id { get; set; }
        public string Title { get; set; } = null!;
        public DateOnly PublicationDate { get; set; }
        public IEnumerable<Order>? Orders { get; set; }
        public IEnumerable<Author>? Authors { get; set; }
    }
}
