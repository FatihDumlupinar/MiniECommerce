using Microsoft.AspNetCore.Mvc;
using MiniECommerce.Model.Products;
using MiniECommerce.Web.Controllers.Base;

namespace MiniECommerce.Web.Controllers
{
    public class ShopController : CustomBaseController<ShopController>
    {
        public IActionResult List(string category)
        {

            var products = unitOfWork.Products.Find(i=>i.IsActive);


            return View(new ProductListModel()
            {
                Products = _productService.GetProductsByCategory(category, page, pageSize),
                PagingInfo = new PagingInfo()
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = _productService.GetCountByCategory(category),
                    CurrentCategory = category
                }
            });
        }
    }
}
