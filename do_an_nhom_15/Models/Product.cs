using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace do_an_nhom_15.Models
{
    public partial class Product
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Product name is required")]
        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive value")]
        public decimal Price { get; set; }

        [Range(0, 100, ErrorMessage = "Discount must be between 0 and 100")]
        public decimal? Discount { get; set; }

        [Required(ErrorMessage = "Stock quantity is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Stock must be a positive value")]
        public int Stock { get; set; }

        public string? ImageUrl { get; set; }

        [Range(0, 5, ErrorMessage = "Rating must be between 0 and 5")]
        public decimal? Rating { get; set; }

        public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

        public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

        public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}
