using System.Text.Json.Serialization;
using API.Models;

namespace API.Models
{
    public class Order
    {
        public int OrderID { get; set; }  // Khóa chính
        public string OrderCode { get; set; } //
        public int CustomerID { get; set; }  // Khóa ngoại tham chiếu tới Customer
        public decimal TotalAmount { get; set; }  // Tổng số tiền
        public DateTime OrderDate { get; set; }  // Ngày đặt hàng
        public string? DeliveryMethod { get; set; }  // Phương thức giao hàng
        public string? PaymentMethod { get; set; }  // Phương thức thanh toán
        public string Address { get; set; } //
        public string Status { get; set; }  // Trạng thái của đơn hàng (ví dụ: "Pending", "Completed", "Canceled")


        // Liên kết với Customer và Product

        public User Customer { get; set; }  // Liên kết tới đối tượng Customer
        public List<OrderItem> OrderItems { get; set; }  // Danh sách các sản phẩm trong đơn hàng
    }
}

