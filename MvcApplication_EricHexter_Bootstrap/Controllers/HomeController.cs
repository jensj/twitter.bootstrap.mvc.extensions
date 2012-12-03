using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication_EricHexter_Bootstrap.Models;

namespace MvcApplication_EricHexter_Bootstrap.Controllers
{
    public class HomeController : BootstrapBaseController
    {
        private static readonly List<HomeInputModel> Items = ModelIntializer.CreateHomeInputModels();

        public ActionResult List(int page = 1)
        {
            LoadCountriesIntoViewData();

            List<HomeInputModel> filteredItems = Items;
            
            var qName = Request.QueryString["Name"];
            var qCountry = Request.QueryString["Country"];

            if(!String.IsNullOrWhiteSpace(qName))  filteredItems = Items.Where(x => x.Name == qName).ToList();
            if(!String.IsNullOrWhiteSpace(qCountry))  filteredItems = Items.Where(x => x.Country == int.Parse(qCountry)).ToList();

            var take = PagedViewModel.DefaultPagesize;
            var skip = (page - 1)*take;

            var viewModel =
                new PagedViewModel(
                    filteredItems.Skip(skip).Take(take),
                    filteredItems.Count, page, "Users");
            return View("Index", viewModel);
        }

        [HttpPost]
        public ActionResult Create(HomeInputModel model)
        {
            if (ModelState.IsValid)
            {
                model.Id = Items.Count == 0 ? 1 : Items.Select(x => x.Id).Max() + 1;
                Items.Add(model);
                Success("Your information was saved!");
                return RedirectToAction("Index");
            }
            LoadCountriesIntoViewData();
            Error("there were some errors in your form.");
            return View(model);
        }

        public ActionResult Create()
        {
            LoadCountriesIntoViewData();

            return View(new HomeInputModel());
        }

        private void LoadCountriesIntoViewData()
        {
            var countryValues = new List<SelectListItem>
                {
                    new SelectListItem() {Text = "---", Value = ""},
                    new SelectListItem() {Text = "Sverige", Value = "46"},
                    new SelectListItem() {Text = "Norge", Value = "47"},
                    new SelectListItem() {Text = "Finland", Value = "48"}
                };

            ViewData["Country_values"] = countryValues;
        }

        public ActionResult Delete(int id)
        {
            Attention("Deleting this item cannot be undone.");
            return View(Items.Get(id));
        }

        [HttpPost]
        public ActionResult Delete(HomeInputModel model, int id)
        {
            Items.Remove(Items.Get((int)id));
            Information("Your widget was deleted");
            if (Items.Count == 0)
            {
                Attention("You have deleted all the models! Create a new one to continue the demo.");
            }
            return RedirectToAction("index");
        }

        public ActionResult Edit(int id)
        {
            var model = Items.Get(id);
            var items = new List<SelectListItem>
                {
                    new SelectListItem() {Text = "Sverige", Value = "46", Selected = model.Country == 46},
                    new SelectListItem() {Text = "Norge", Value = "47", Selected = model.Country == 47},
                    new SelectListItem() {Text = "Finland", Value = "48", Selected = model.Country == 48}
                };

            ViewData["Country_values"] = items;
            return View("Create", model);
        }
        [HttpPost]
        public ActionResult Edit(HomeInputModel model, int id)
        {
            if (ModelState.IsValid)
            {
                Items.Remove(Items.Get(id));
                model.Id = id;
                Items.Add(model);
                Success("The model was updated!");
                return RedirectToAction("index");
            }
            return View("Create", model);
        }

        public ActionResult Details(int id)
        {
            var model = Items.Get(id);
            return View(model);
        }

    }
}
