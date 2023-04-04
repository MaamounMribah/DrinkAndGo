using DrinkAndGo.Models;
using Microsoft.EntityFrameworkCore;

namespace DrinkAndGo.Repositories
{
    public class DrinkRepository : IDrinkRepository
    {
        private readonly AppDbContext _appDbContext;
        public DrinkRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<Drink> Drinks => _appDbContext.Drinks.Include(d => d.Category);
        public IEnumerable<Drink> PreferredDrinks => _appDbContext.Drinks.Where(d=>d.IsPreferredDrink).Include(d=>d.Category);

        public Drink GetDrinkById(int drinkId)
        {
           var drink=_appDbContext.Drinks.FirstOrDefault(d=>d.DrinkId == drinkId);
           return drink;
        }
    }
}
