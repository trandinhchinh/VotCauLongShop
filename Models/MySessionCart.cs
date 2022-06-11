using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using ShopDienThoai.MyTagHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ShopDienThoai.Models
{
    public class MySessionCart : MyCart
    {
        public static MyCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
            .HttpContext.Session;
            MySessionCart mycart = session?.GetJson<MySessionCart>("MyCart")
            ?? new MySessionCart();
            mycart.Session = session;
            return mycart;
        }
        [JsonIgnore]
        public ISession Session { get; set; }
        public override void AddItem(DienThoai dienThoai, int quantity)
        {
            base.AddItem(dienThoai, quantity);
            Session.SetJson("MyCart", this);
        }
        public override void RemoveLine(DienThoai dienThoai)
        {
            base.RemoveLine(dienThoai);
            Session.SetJson("MyCart", this);
        }
        public override void Clear()
        {
            base.Clear();
            Session.Remove("MyCart");
        }
    }
}
