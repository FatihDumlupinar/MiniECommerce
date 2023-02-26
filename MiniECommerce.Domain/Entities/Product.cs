using MiniECommerce.Domain.Common;

namespace MiniECommerce.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string? Name { get; set; }

        public string? ImageUrl { get; set; }

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public List<ProductCategory> ProductCategories { get; set; }
    }
}
