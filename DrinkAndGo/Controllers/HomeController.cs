using System.Diagnostics;
using DrinkAndGo.Models;
using DrinkAndGo.Repositories;
using DrinkAndGo.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DrinkAndGo.Controllers
{
    public class HomeController : Controller
    {
        private readonly  IDrinkRepository _drinkRepository;
        public HomeController(IDrinkRepository drinkRepository)
        {
            _drinkRepository = drinkRepository;
        }

        public ViewResult Index()
        {
            var HomeViewModel = new HomeViewModel
            {
                PreferredDrinks = _drinkRepository.PreferredDrinks
            };
            return View(HomeViewModel);
        }
    }
}