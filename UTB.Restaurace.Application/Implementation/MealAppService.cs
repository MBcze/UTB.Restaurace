using UTB.Restaurace.Application.Abstraction;
using UTB.Restaurace.Domain.Entities;
using UTB.Restaurace.Infrastructure.Database;
namespace UTB.Restaurace.Application.Implementation
{
    public class MealAppService : IMealAppService
    {
        RestauraceDbContext _restauraceDbContext;
        public MealAppService(RestauraceDbContext restauraceDbContext)
        {
            _restauraceDbContext = restauraceDbContext;
        }
        public IList<Meal> Select()
        {
            return _restauraceDbContext.Meals.ToList();
        }
    }
}