using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ShopDienThoai.Models;

namespace ShopDienThoai.Models
{
    public class Order
    {
        [BindNever]
        public int OrderID { get; set; }
        [BindNever]
        public ICollection<CartLine> Lines { get; set; }
        [Required(ErrorMessage = "Xin Hãy điền Tên")]
        [Display(Name = "Tên Khách Hàng")]
        public string Name { get; set; }
        [Display(Name = "Địa chỉ")]
        [Required(ErrorMessage = "Xin hãy điền địa chỉ")]
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        [Display(Name = "Thành Phố")]
        [Required(ErrorMessage = "xin hãy điền tên thành phố")]
        public string City { get; set; }
        [Required(ErrorMessage = "Xin hãy điền tên quận, huyện")]
        [Display(Name = "Quận, Huyện")]
        public string State { get; set; }
        [Display(Name = "Mã Bưu Chính")]
        public string Zip { get; set; }
        [Required(ErrorMessage = "Xin hãy điền tên quốc gia")]
        public string Country { get; set; }
        [BindNever]
        public bool Shipped { get; set; }
    }
}