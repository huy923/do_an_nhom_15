
namespace do_an_nhom_15.Models
{
    public class ViewModel
    {
        public List<Attendance>? AttendanceList { get; set; }
        public List<Cart>? CartList { get; set; }
        public List<Employee>? EmployeeList { get; set; }
        public List<Feedback>? FeedbackList { get; set; }
        public List<FeedbackReply>? FeedbackReplyList { get; set; }
        public List<Product>? ProductList { get; set; }
        public List<Role>? RoleList { get; set; }
        public List<Salary>? SalaryList { get; set; }
        public List<Sale>? SaleList { get; set; }
        public List<Shift>? ShiftList { get; set; }
        public List<OrderDetail>? OrderDetailList { get; set; }
        public List<Order>? OrderList { get; set; }
        public Product? SelectedProduct { get; set; }
        public Order Order { get; set; } = new();
    }
}
