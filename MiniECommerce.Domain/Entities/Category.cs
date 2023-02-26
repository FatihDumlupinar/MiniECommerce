using MiniECommerce.Domain.Common;

namespace MiniECommerce.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string? Name { get; set; }

        public List<ProductCategory> ProductCategories { get; set; }
    }
}
