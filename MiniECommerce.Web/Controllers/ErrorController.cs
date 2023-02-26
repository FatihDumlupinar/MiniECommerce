using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MiniECommerce.Web.Controllers.Base;
using MiniECommerce.Web.Models;

namespace MiniECommerce.Web.Controllers
{
    [AllowAnonymous]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : CustomBaseController<ErrorController>
    {
        #region ErrorDevelopment

        [Route("/error-development")]
        public IActionResult ErrorDevelopment()
        {
            var exceptionDetails = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            //Log kaydı
            Logger.LogError(exceptionDetails?.Error.Message, exceptionDetails);

            ErrorViewModel errorViewModel = new()
            {
                ExceptionMessage = exceptionDetails.Error.Message,
                ExceptionPath = exceptionDetails.Path,
                ExceptionStackTrace = exceptionDetails.Error.StackTrace

            };

            return View(errorViewModel);
        }

        #endregion

        #region Error

        [Route("/error")]
        public IActionResult Error()
        {
            var exceptionDetails = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            //Log kaydı
            Logger.LogError(exceptionDetails?.Error.Message, exceptionDetails);

            return View();
        }

        #endregion

        #region Unauthorized

        [Route("/unauthorized")]
        public IActionResult UnAuthorized()
        {
            return View();
        }

        #endregion
    }
}
