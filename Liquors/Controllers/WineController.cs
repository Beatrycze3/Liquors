using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Liquors.Context;
using Liquors.Model;
using Liquors.Model.WineModel;
using Liquors.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.EntityFrameworkCore;
using Type = Liquors.Model.WineModel.Type;

namespace Liquors.Controllers
{
    [Authorize]
    public class WineController : Controller
    {
        public LiquorsContext Context { get; }

        public WineController(LiquorsContext context)
        {
            Context = context;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            var alcohols = Context.Alcohols.Where(x => x.Wine != null).Include(x=> x.Wine).ToList();
            var list = new List<WineModel>();

            foreach (var item in alcohols)
            {
                var ratingList = Context.UserRates.Include(x => x.AlcoholVintage)
                    .Where(x => x.AlcoholVintage.Alcohol == item).ToList();
                double rating = 0;

                if (ratingList.Count > 0)
                {
                    double sum = 0;

                    foreach (var rate in ratingList)
                    {
                        sum += rate.Rating;
                    }

                    rating = Convert.ToDouble(sum / ratingList.Count);
                }
                
                var wine = new WineModel()
                {
                    Id=item.Id,
                    Country = item.Wine.Country,
                    Name=item.Wine.Name,
                    Region = item.Wine.Region,
                    Type = item.Wine.Type,
                    Winery = item.Wine.Winery,
                    Rating = rating
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
        
        [HttpGet]
        public IActionResult Rate(int id)
        {
            var rateModel = new RateModel();
            //var alcohol = Context.AlcoholVintages.Include(x => x.Alcohol).Single(x => x.AlcoholId == id);
                //Context.AlcoholVintages.Include(x=>x.Alcohol).Single(x => x.AlcoholId == Id);
            rateModel.AlcoholId = Context.Alcohols.Include(x => x.Wine).Single(x => x.Id == id).Id;
            rateModel.Name= Context.Alcohols.Include(x => x.Wine).Single(x => x.Id == id).Wine.Name;
            return View(rateModel);
        }

        [HttpPost]
        public IActionResult Rate(RateModel rateModel)
        {
            if (ModelState.IsValid)
            {
                var alcoholVintage = Context.AlcoholVintages.Where(x => x.AlcoholId == rateModel.AlcoholId)
                       .SingleOrDefault(x => x.Vintage.Year == rateModel.Year);

                if (alcoholVintage == null)
                {
                    var alcvintage = new AlcoholVintage();
                    alcvintage.AlcoholId = rateModel.AlcoholId;
                    var checkVintage = Context.Vintages.SingleOrDefault(x => x.Year == rateModel.Year);

                    if (checkVintage == null)
                    {
                        var vintage = new Vintage()
                        {
                            Year = rateModel.Year
                        };
                        Context.Vintages.Add(vintage);
                        Context.SaveChanges();
                       
                    }
                    alcvintage.VintageId = Context.Vintages.SingleOrDefault(x => x.Year == rateModel.Year).Id;
                    Context.AlcoholVintages.Add(alcvintage);
                    Context.SaveChanges();
                }

               var user = Context.Users.Single(x => x.UserName==User.Identity.Name);
                 
                var userRate = new UserRate()
                {
                    User = user,
                    AlcoholVintage = Context.AlcoholVintages.Where(x => x.Alcohol.Wine.Name == rateModel.Name)
                        .Single(x => x.Vintage.Year == rateModel.Year),
                    Rating=rateModel.Rating,
                    Comment = rateModel.Comment
                };
                Context.UserRates.Add(userRate);
                Context.SaveChanges();
                return RedirectToAction("Index", "Wine");
            }

            return View(rateModel);
        }

    }
}
