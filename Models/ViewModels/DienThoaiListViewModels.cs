using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopDienThoai.Models.ViewModels
{
    public class DienThoaiListViewModels
    {
        public IEnumerable<DienThoai> DienThoais { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentGenre { get; set; }
    }
}
