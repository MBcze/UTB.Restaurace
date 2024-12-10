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
        public void Create(Meal meal)
        {
            _restauraceDbContext.Meals.Add(meal);
            _restauraceDbContext.SaveChanges();
        }
        public bool Delete(int id)
        {
            bool deleted = false;
            Meal? meal
                = _restauraceDbContext.Meals.FirstOrDefault(prod => prod.Id == id);
            if (meal != null)
            {
                _restauraceDbContext.Meals.Remove(meal);
                _restauraceDbContext.SaveChanges();
                deleted = true;
            }
            return deleted;
        }
    }
}