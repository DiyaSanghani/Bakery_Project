namespace Bakery_Project.Areas.User.Models
{
    public class UserModel
    {
        public int? UserID { get; set; }
        public string UserName { get; set; }
        public string UserRole { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Password { get; set; }
    }
    public class UserDropdownModel
    {
        public int? UserID { get; set;}
        public string UserName { get; set; }

    }
}
