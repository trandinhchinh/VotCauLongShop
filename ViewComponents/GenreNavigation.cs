using Microsoft.AspNetCore.Mvc;
using ShopDienThoai.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopDienThoai.ViewComponents
{
    public class GenreNavigation : ViewComponent
    {
        private IShopDienThoaiRepository repository;
        public GenreNavigation(IShopDienThoaiRepository repo)
        {
            repository = repo;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedGenre = RouteData?.Values["genre"];
            return View(repository.DienThoais
            .Select(x => x.Genre)
            .Distinct()
            .OrderBy(x => x));
        }
    }
}
