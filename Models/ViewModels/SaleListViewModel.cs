using QuarterlySalesApp.Models.DomainModels;
using QuarterlySalesApp.Models.Grid;

namespace QuarterlySalesApp.Models.ViewModels
{
    public class SaleListViewModel
    {
        public IEnumerable<Sale> Sales { get; set; }

        public IEnumerable<Employee> Employees { get; set; }

        public RouteDictionary CurrentRoute { get; set; }

        public decimal TotalAmount { get; set; }
    }
}
