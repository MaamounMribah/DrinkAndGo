using System.Collections;
using DrinkAndGo.Models;
using DrinkAndGo.Repositories;
using DrinkAndGo.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DrinkAndGo.Controllers
{
    public class DrinksController : Controller
    {
        private readonly IDrinkRepository _drinkRepository;
        private readonly ICategoryRepository _categoryRepository;

        public DrinksController(IDrinkRepository drinkRepository, ICategoryRepository categoryRepository)
        {
            _drinkRepository = drinkRepository;
            _categoryRepository = categoryRepository;
        }

        public ViewResult List(string category)
        {
            IEnumerable<Drink> drinks=Enumerable.Empty<Drink>();
            string currentCategory=string.Empty;

            if (string.IsNullOrEmpty(category))
            {
                drinks = _drinkRepository.Drinks.OrderBy(d => d.DrinkId);
                currentCategory=category;
            }
            else
            {
                if (category.Contains("A", StringComparison.OrdinalIgnoreCase) && !category.Contains("N", StringComparison.OrdinalIgnoreCase))
                {
                    drinks = _drinkRepository.Drinks
                        .Where(d => d.Category.CategoryName.Equals("Alcoholic")).OrderBy(d => d.Name);
                }
                else if (category.Contains("N", StringComparison.OrdinalIgnoreCase))
                {
                    drinks = _drinkRepository.Drinks
                        .Where(d => d.Category.CategoryName.Equals("Non-alcoholic")).OrderBy(d => d.Name);
                }
            }

            var drinkViewModel = new DrinksListViewModel();
            drinkViewModel.Drinks = drinks;
            drinkViewModel.CurrentCategory = currentCategory;
            return View(drinkViewModel);
        }

        public ViewResult Search(string searchString)
        {
            string _searchString = searchString;
            IEnumerable<Drink> drinks;
            string currentCategory = string.Empty;

            if (string.IsNullOrEmpty(_searchString))
            {
                drinks = _drinkRepository.Drinks.OrderBy(p => p.DrinkId);
            }
            else
            {
                drinks = _drinkRepository.Drinks.Where(p => p.Name.ToLower().Contains(_searchString.ToLower()));
            }

            return View("~/Views/Drinks/List.cshtml", new DrinksListViewModel { Drinks = drinks, CurrentCategory = "All drinks" });
        }

        public ViewResult Details(int drinkId)
        {
            var drink = _drinkRepository.Drinks.FirstOrDefault(d => d.DrinkId == drinkId);
            if (drink == null)
            {
                return View("~/Views/Error/Error.cshtml");
            }
            return View(drink);
        }
    }
}
