using Microsoft.EntityFrameworkCore;
using System.Linq;
namespace ShopDienThoai.Models
{
    public class EFOrderRepository : IOrderRepository
    {
        private ShopDienThoaiDbContext context;
        public EFOrderRepository(ShopDienThoaiDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Order> Orders => context.Orders
        .Include(o => o.Lines)
        .ThenInclude(l => l.DienThoai);
        public void SaveOrder(Order order)
        {
            context.AttachRange(order.Lines.Select(l => l.DienThoai));
            if (order.OrderID == 0)
            {
                context.Orders.Add(order);
            }
            context.SaveChanges();
        }
    }
}