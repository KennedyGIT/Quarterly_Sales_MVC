using System.ComponentModel.DataAnnotations;

namespace QuarterlySalesApp.Models.DomainModels
{
    public class Employee : BaseModel
    {
        [Required(ErrorMessage = "Please enter a first name.")]
        [StringLength(200)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter a first name.")]
        [StringLength(200)]
        public string LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public DateTime DateOfBirth { get; set; }

        public DateTime DateOfHire { get; set; }

        public int? ManagerId { get; set; }

        public virtual Employee Manager { get; set; }

        public virtual ICollection<Employee> Subordinates { get; set; }

        public Employee()
        {
            Subordinates = new HashSet<Employee>();
        }
    }
}
