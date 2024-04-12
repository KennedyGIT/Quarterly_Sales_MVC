namespace QuarterlySalesApp.Models.DomainModels
{
    public class Sale : BaseModel
    {
        public int Quarter { get; set; }
        public int Year { get; set; }
        public decimal Amount { get; set; }
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
