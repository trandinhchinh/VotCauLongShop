using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShopDienThoai.Models
{
    public class DienThoai
    {
        [Key]
        public long DienThoaiID { get; set; }
        [Required(ErrorMessage = "Please enter a title")]
        [Display(Name = "Tên Điện Thoại")]   
        public string Title { get; set; }
        [Required(ErrorMessage = "Please enter a description")]
        [Display(Name = "Mô tả")]
        public string Description { get; set; }
        [Required]
        [Range(0.01, double.MaxValue,
            ErrorMessage = "Please enter a positive price")]
        [Column(TypeName = "decimal(8, 2)")]
        [Display(Name = "Giá")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Please specify a genre")]
        [Display(Name = "Hãng sản xuất")]
        public string Genre { get; set; }
        public string ProfilePicture { get; set; }
    }
}
