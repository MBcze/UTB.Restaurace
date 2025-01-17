﻿using Microsoft.EntityFrameworkCore;
using UTB.Restaurace.Application.Abstraction;
using UTB.Restaurace.Domain.Entities;
using UTB.Restaurace.Infrastructure.Database;
namespace UTB.Restaurace.Application.Implementation
{
    public class MealAppService : IMealAppService
    {
        RestauraceDbContext _restauraceDbContext;
        IFileUploadService _fileUploadService;
        public MealAppService(RestauraceDbContext restauraceDbContext, IFileUploadService fileUploadService)
        {
            _restauraceDbContext = restauraceDbContext;
            _fileUploadService = fileUploadService;
        }
        public IList<Meal> Select()
        {
            return _restauraceDbContext.Meals.ToList();
        }
        public void Create(Meal meal)
        {
            if (meal.Image != null && meal.Category != "nápoj")
            {
                string imageSrc = _fileUploadService.FileUpload(meal.Image, Path.Combine("img", "meals"));
                meal.ImageSrc = imageSrc;
            }
            else if (meal.Image != null && meal.Category == "nápoj")
            {
                string imageSrc = _fileUploadService.FileUpload(meal.Image, Path.Combine("img", "drinks"));
                meal.ImageSrc = imageSrc;
            }

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

                if (meal.Image != null)
                {
                    string folder = meal.Category == "nápoj" ? "img/drinks" : "img/meals";
                    string imageSrc = _fileUploadService.FileUpload(meal.Image, Path.Combine(folder));
                    existingMeal.ImageSrc = imageSrc;
                }

                existingMeal.Category = meal.Category;
                existingMeal.Available = meal.Available;

                _restauraceDbContext.SaveChanges();
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