using Microsoft.AspNetCore.Mvc;
using QuarterlySalesApp.Models;
using QuarterlySalesApp.Models.DataLayer.Repositories;
using QuarterlySalesApp.Models.DomainModels;
using QuarterlySalesApp.Models.DTOs;
using QuarterlySalesApp.Models.ExtensionMethods;
using QuarterlySalesApp.Models.Grid;
using QuarterlySalesApp.Models.ViewModels;

namespace QuarterlySalesApp.Controllers
{
    public class SaleController : Controller
    {

        private UnitOfWork unitOfWork {  get; set; }

        public SaleController(QuarterlyEmployeeSalesDbContext context) => unitOfWork = new UnitOfWork(context);

        public RedirectToActionResult Index() => RedirectToAction("List");

        public ViewResult List(SalesGridDTO values)
        {
            decimal totalAmount = 0;


            //var builder = new SalesGridBuilder(HttpContext.Session, values, defaultSortfield: nameof(Sale.Quarter));

            var options = new SaleQueryOptions
            {
                Include = "Employee"
            };

            var vm = new SaleListViewModel
            {
                Sales = unitOfWork.Repository<Sale>().List(options),

                Employees = unitOfWork.Repository<Employee>().List(new QueryOptions<Employee> 
                {
                    OrderBy = e => e.FirstName
                }),
            };
            if (vm.Sales != null)
            {
                foreach (var sales in vm.Sales) { totalAmount += sales.Amount; }
            }

            vm.TotalAmount = totalAmount;

            return View(vm);
        }

        public RedirectToActionResult Filter(string[] filter, bool clear = false) 
        {
            var builder = new SalesGridBuilder(HttpContext.Session);

            if(clear) 
            {
                builder.ClearFilterSegments();
            }
            else 
            {
                var employee = unitOfWork.Repository<Employee>().Get(filter[0].ToInt());
                builder.LoadFilterSegments(filter, employee);
            }

            builder.SaveRouteSegments();
            return RedirectToAction("List", builder.CurrentRoute);
        }
    }
}
