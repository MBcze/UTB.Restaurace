using Microsoft.EntityFrameworkCore;
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
        public Meal GetById(int id)
        {
            return _restauraceDbContext.Meals.FirstOrDefault(m => m.Id == id);
        }
        public void Update(Meal meal)
        {
            var existingMeal = _restauraceDbContext.Meals.FirstOrDefault(m => m.Id == meal.Id);
            if (existingMeal != null)
            {
                existingMeal.Name = meal.Name;
                existingMeal.Description = meal.Description;
                existingMeal.Price = meal.Price;
                existingMeal.ImageSrc = meal.ImageSrc;
                existingMeal.Category = meal.Category;
                existingMeal.Available = meal.Available;
                _restauraceDbContext.SaveChanges(); // Ensure changes are saved
            }
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