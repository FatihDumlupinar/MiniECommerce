using Microsoft.AspNetCore.Mvc;
using MiniECommerce.Domain.Repositories;
using MiniECommerce.Model.Category;

namespace MiniECommerce.Web.ViewComponents
{
    public class CategoryListViewComponent : ViewComponent
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryListViewComponent(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IViewComponentResult Invoke()
        {
            var categories = _unitOfWork.Categories.Find(i => i.IsActive).ToList();

            return View(new CategoryListViewModel()
            {
                SelectedCategory = RouteData.Values["category"]?.ToString(),
                Categories = categories.Select(i => new CategoryListModel() { Id = i.Id, Name = i.Name }).ToList(),
            }); ;
        }
    }
}
