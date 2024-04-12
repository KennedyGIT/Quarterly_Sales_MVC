using QuarterlySalesApp.Models.DomainModels;
using QuarterlySalesApp.Models.ExtensionMethods;
using QuarterlySalesApp.Models.Grid;

namespace QuarterlySalesApp.Models
{
    public class SaleQueryOptions : QueryOptions<Sale>
    {
        public void SortFilter(SalesGridBuilder builder)
        {
            if (builder.IsFilterByEmployee)
            {
                int id = builder.CurrentRoute.EmployeeFilter.ToInt();
                if (id > 0)
                    Where = s => s.EmployeeId == id;
            }

            if (builder.IsSortByEmployee)
            {
                OrderBy = s => s.Employee.FirstName;
            }
            else
            {
                OrderBy = s => s.Amount;
            }
        }




    }
}
