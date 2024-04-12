using Microsoft.AspNetCore.Mvc;
using QuarterlySalesApp.Models.DataLayer.Repositories;
using QuarterlySalesApp.Models;
using QuarterlySalesApp.Models.DomainModels;

namespace QuarterlySalesApp.Controllers
{
    public class HomeController : Controller
    {
        private UnitOfWork unitOfWork { get; set; }

        public HomeController(QuarterlyEmployeeSalesDbContext context) => unitOfWork = new UnitOfWork(context);
        public ViewResult Index()
        {
            var random = unitOfWork.Repository<Sale>().Get(new QueryOptions<Sale>
            {
                OrderBy = b => Guid.NewGuid()
            });

            return View(random);
        }
    }
}
