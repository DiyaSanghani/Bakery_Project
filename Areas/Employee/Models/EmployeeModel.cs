namespace Bakery_Project.Areas.Employee.Models
{
    public class EmployeeModel
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public DateTime JoiningDate { get; set; }
        public bool IsActive {  get; set; }

    }
}
