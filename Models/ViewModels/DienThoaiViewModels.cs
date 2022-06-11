using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShopDienThoai.Models.ViewModels
{
    public class DienThoaiViewModels
    {
        [Key]
        public long DienThoaiID { get; set; }
        [Display(Name = "Tên Điện Thoại")]
        public string Title { get; set; }
        [Display(Name = "Mô tả")]
        public string Description { get; set; }
        [Column(TypeName = "decimal(8, 2)")]
        [Display(Name = "Giá")]
        public decimal Price { get; set; }
        [Display(Name = "Hãng sản xuất")]
        public string Genre { get; set; }
        [Required(ErrorMessage = "hãy chọn một bức hình")]
        [Display(Name = "Hình ảnh điện thoại")]
        public IFormFile ImagePhone { get; set; }
       
    }
}
