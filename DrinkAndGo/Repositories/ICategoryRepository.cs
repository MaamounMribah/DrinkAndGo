using DrinkAndGo.Models;

namespace DrinkAndGo.Repositories
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Categories { get; }
    }
}
