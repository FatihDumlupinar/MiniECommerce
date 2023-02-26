namespace MiniECommerce.Model.Category
{
    public class CategoryListViewModel
    {
        public string SelectedCategory { get; set; } = "";
        public List<CategoryListModel> Categories { get; set; } = new();
    }
}
