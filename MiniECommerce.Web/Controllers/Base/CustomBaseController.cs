using Microsoft.AspNetCore.Mvc;
using MiniECommerce.Domain.Repositories;

namespace MiniECommerce.Web.Controllers.Base
{
    /// <summary>
    /// Bütün Controller larda ortak olan özellikleri barındıran Base Controller
    /// </summary>
    /// <typeparam name="T">Statik olmayan, new'lenebilen sınıf olmak zorunda</typeparam>
    public class CustomBaseController<T> : Controller
    {
        private ILogger<T> _logger;

        private IUnitOfWork _unitOfWork;

        protected IUnitOfWork unitOfWork => _unitOfWork ??= HttpContext.RequestServices.GetService<IUnitOfWork>();

        protected ILogger<T> Logger => _logger ??= HttpContext.RequestServices.GetService<ILogger<T>>();
    }
}
