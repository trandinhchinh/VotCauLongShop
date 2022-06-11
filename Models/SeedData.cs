using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopDienThoai.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ShopDienThoaiDbContext context =
           app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService <ShopDienThoaiDbContext> ();
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            if (!context.DienThoais.Any())
            {
                context.DienThoais.AddRange(
                new DienThoai
                {
                    Title = "GalaXy M52 5G",
                    Description = "Cùng đón đầu kỷ nguyên công nghệ 5G, ghi điểm bởi phong cách tinh tế, năng động, màn hình sắc nét, trải nghiệm chân thực",               
                    Genre = "SamSung",
                    Price = 8.98m
                },
                new DienThoai
                {
                    Title = "A52s 5G",
                    Description = "Chip 5G mới, màn 120Hz, RAM 8GB mạnh mẽ, Camera OIS tiên phong công nghệ, Chuẩn kháng nước IP67, pin lớn 4500mAh đủ cho cả ngày dài",               
                    Genre = "SamSung",
                    Price = 7.46m
                },
                new DienThoai
                {
                    Title = "Galaxy Z-Fold 2 5G",
                    Description = "Bứt phá ngoạn mục với thiết kế thời thượng, Trải nghiệm màn hình đỉnh cao, Flex Mode: Tính năng ưu việt",               
                    Genre = "SamSung",
                    Price = 20.41m
                },
                new DienThoai
                {
                    Title = "13 Pro Max",
                    Description = "Màn hình giải trí siêu mượt cùng tần số quét 120 Hz, Cụm camera được nâng cấp toàn diện, Hiệu năng đầy hứa hẹn với Apple A15 Bionic",               
                    Genre = "Iphone",
                    Price = 30.92m
                },
                new DienThoai
                {
                    Title = "Redmi note 11",
                    Description = "Thiết kế bo cong đậm chất Xiaomi, Hiệu năng mạnh mẽ với chip Snapdragon, Màn hình sắc nét, chiến game mượt mà",               
                    Genre = "Xiaomi",
                    Price = 6.76m
                }
                );
                context.SaveChanges();
            }
        }
    }
}
