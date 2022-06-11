using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopDienThoai.Models
{
    public class EFShopDienThoaiRepository : IShopDienThoaiRepository
    {
        private ShopDienThoaiDbContext context;
        public EFShopDienThoaiRepository(ShopDienThoaiDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<DienThoai> DienThoais => context.DienThoais;
        public void CreateDienThoai(DienThoai b)
        {
            context.Add(b);
            context.SaveChanges();
        }
        public void DeleteDienThoai(DienThoai b)
        {
            context.Remove(b);
            context.SaveChanges();
        }
        public void SaveDienThoai(DienThoai b)
        {
            context.SaveChanges();
        }
    }
}
