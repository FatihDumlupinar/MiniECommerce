namespace MiniECommerce.Model.Products
{
    public class ProductListModel
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = "";
        public string ImageUrl { get; set; } = "";
        public string Description { get; set; } = "";
        public decimal Price { get; set; } = 0;
    }
}
