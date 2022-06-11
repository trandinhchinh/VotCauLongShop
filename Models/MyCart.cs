using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopDienThoai.Models
{
    public class MyCart
    {
        public List<CartLine> Lines { get; set; } = new List<CartLine>();
        public virtual void AddItem(DienThoai dienThoai, int quantity)
        {
            CartLine line = Lines
            .Where(b => b.DienThoai.DienThoaiID == dienThoai.DienThoaiID)
            .FirstOrDefault();
            if (line == null)
            {
                Lines.Add(new CartLine
                {
                    DienThoai = dienThoai,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }
        public virtual void RemoveLine(DienThoai dienThoai) =>
        Lines.RemoveAll(l => l.DienThoai.DienThoaiID == dienThoai.DienThoaiID);
        public decimal ComputeTotalValue() =>
        Lines.Sum(e => e.DienThoai.Price * e.Quantity);
        public virtual void Clear() => Lines.Clear();
    }
    public class CartLine
    {
        public int CartLineID { get; set; }
        public DienThoai DienThoai { get; set; }
        public int Quantity { get; set; }
    }
}

