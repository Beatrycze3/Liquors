using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Liquors.Context;
using Liquors.Model;
using Liquors.Model.WineModel;
using Liquors.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.EntityFrameworkCore;
using Type = Liquors.Model.WineModel.Type;

namespace Liquors.Controllers
{
    public class WineController : Controller
    {
        public LiquorsContext Context { get; }

        public WineController(LiquorsContext context)
        {
            Context = context;
        }

        public IActionResult Index()
        {
            //var alcohols = Context.Alcohols.Where(x => x.Wine != null).Include(x => x.Wine).ToList();

            var alcohols = Context.Alcohols.Where(x => x.Wine != null).Include(x=> x.Wine).ToList();
            var list = new List<WineModel>();

            foreach (var item in alcohols)
            {
                var wine = new WineModel()
                {
                    Country = item.Wine.Country,
                    Name=item.Wine.Name,
                    Region = item.Wine.Region,
                    Type = item.Wine.Type,
                    Winery = item.Wine.Winery
                };

                list.Add(wine);
            }
            return View(list);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(new WineModel());
        }

        [HttpPost]
        public IActionResult Add(WineModel model)
        {
            if (ModelState.IsValid)
            {
                var wine = new Wine()
                {
                    Name = model.Name,
                    Type = model.Type,
                    Region = model.Region,
                    Winery = model.Winery,
                    Country = model.Country
                };
                var alcohol = new Alcohol()
                {
                    Wine = wine
                };

                Context.Alcohols.Add(alcohol);
                Context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

    }
}
