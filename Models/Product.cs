namespace API.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string Gender { get; set; }
        public decimal Price { get; set; }
        public string ProductImageUrl { get; set; }
    }
}
