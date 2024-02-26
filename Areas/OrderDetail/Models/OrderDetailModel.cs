namespace Bakery_Project.Areas.OrderDetail.Models
{
    public class OrderDetailModel
    {
        public int? OrderID { get; set; }
        public int CartID { get; set; }
        public string OrderItemName { get; set; }
        public int OrderQuantity { get; set; }
    }
}
