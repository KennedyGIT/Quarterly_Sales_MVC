using QuarterlySalesApp.Models.DomainModels;
using QuarterlySalesApp.Models.DTOs;
using QuarterlySalesApp.Models.ExtensionMethods;

namespace QuarterlySalesApp.Models.Grid
{
    public class SalesGridBuilder : GridBuilder
    {
        public SalesGridBuilder(ISession sess): base(sess) { }

        public SalesGridBuilder(ISession sess, SalesGridDTO values, string defaultSortfield) : base(sess, values, defaultSortfield) 
        {
            bool isInitial = values.Employee.IndexOf(FilterPrefix.Employee) == -1;
            routes.EmployeeFilter = (isInitial) ? FilterPrefix.Employee + values.Employee : values.Employee;
        }

        public void LoadFilterSegments(string[] filter, Employee employee)
        {
            if (employee == null)
            {
                routes.EmployeeFilter = FilterPrefix.Employee + filter[0];
            }
            else
            {
                routes.EmployeeFilter = FilterPrefix.Employee + filter[0]
                    + "-" + employee.FullName.Slug();
            }
        }

        public void ClearFilterSegments() => routes.ClearFilters();

        string def = SalesGridDTO.DefaultFilter;
        public bool IsFilterByEmployee => routes.EmployeeFilter != def;

        public bool IsSortByEmployee =>
            routes.SortField.EqualsNoCase(nameof(Employee));
    }
}
