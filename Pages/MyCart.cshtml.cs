using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopDienThoai.MyTagHelper;
using ShopDienThoai.Models;
using System.Linq;
namespace ShopDienThoai.Pages
{
    public class MyCartModel : PageModel
    {
        private IShopDienThoaiRepository repository;
        public MyCartModel(IShopDienThoaiRepository repo, MyCart myCartService)
        {
            repository = repo;
            myCart = myCartService;
        }
        public MyCart myCart { get; set; }
        public string ReturnUrl { get; set; }
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }
        public IActionResult OnPost(long dienthoaiId, string returnUrl)
        {
            DienThoai dienThoai = repository.DienThoais
            .FirstOrDefault(b => b.DienThoaiID == dienthoaiId);
            myCart.AddItem(dienThoai, 1);
            return RedirectToPage(new { returnUrl = returnUrl });
        }
        public IActionResult OnPostRemove(long dienthoaiId, string returnUrl)
        {
            myCart.RemoveLine(myCart.Lines.First(cl =>
            cl.DienThoai.DienThoaiID == dienthoaiId).DienThoai);
            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}