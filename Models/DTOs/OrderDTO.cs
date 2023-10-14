namespace SoftwareEngineering.Models.DTOs
{
    public class OrderDTO
    {
        public int? Id { get; set; }

        public DateOnly OrderDate { get; set; }

        public DateOnly? RefundDate { get; set; }

        public Book Book { get; set; }

        public Reader Reader { get; set; }
    }
}
