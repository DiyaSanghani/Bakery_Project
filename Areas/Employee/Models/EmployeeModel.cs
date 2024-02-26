namespace Bakery_Project.Areas.Employee.Models
{
    public class EmployeeModel
    {
        public int? EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public DateTime JoiningDate { get; set; }
        public bool IsActive {  get; set; }

    }
}
