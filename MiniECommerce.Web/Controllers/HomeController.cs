using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniECommerce.Model.Products;
using MiniECommerce.Web.Controllers.Base;

namespace MiniECommerce.Web.Controllers
{
    public class HomeController : CustomBaseController<HomeController>
    {
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var products = await unitOfWork.Products.Find(i => i.IsActive).ToListAsync(cancellationToken);

            var productsListModel = products.Select(i => new ProductListModel()
            {
                Description = i.Description,
                Name = i.Name,
                Id = i.Id,
                ImageUrl = i.ImageUrl,
                Price = i.Price,

            });

            return View(productsListModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}