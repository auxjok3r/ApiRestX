namespace ApiRestX.Dtos
{
    public class ProductDto
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public decimal Mrp { get; set; }
        public int Stock { get; set; }

    }
}
