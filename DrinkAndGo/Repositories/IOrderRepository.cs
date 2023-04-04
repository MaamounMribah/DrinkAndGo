using DrinkAndGo.Models;

namespace DrinkAndGo.Repositories
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
    }
}
