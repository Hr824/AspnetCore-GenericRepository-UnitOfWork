using Microsoft.AspNetCore.Mvc;
using MvcCoreApp.Data;

namespace MvcCoreApp.Controllers
{
    public class BaseController : Controller
    {
        protected readonly IUnitOfWork _unitOfWork;

        public BaseController(IUnitOfWork uow)
        {
            _unitOfWork = uow;
        }
    }
}