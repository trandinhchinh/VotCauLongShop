using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopDienThoai.Models
{
    public interface IShopDienThoaiRepository
    {
        IQueryable<DienThoai> DienThoais { get; }
        void SaveDienThoai(DienThoai b);
        void CreateDienThoai(DienThoai b);
        void DeleteDienThoai(DienThoai b);
    }
}
