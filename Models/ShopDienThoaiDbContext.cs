using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopDienThoai.Models
{
    public class ShopDienThoaiDbContext : DbContext
    {
        public ShopDienThoaiDbContext(DbContextOptions<ShopDienThoaiDbContext > options)
            : base(options) { }
        public DbSet<DienThoai> DienThoais { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
