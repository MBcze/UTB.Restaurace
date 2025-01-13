using Moq;
using UTB.Restaurace.Areas.Admin.Controllers;
using UTB.Restaurace.Application.Abstraction;
using UTB.Restaurace.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

public class MealControllerTests
{
    // Test case to verify that the Select method sorts meals by Id in ascending order
    [Fact]
    public void Select_SortsMealsByIdAscending()
    {
        // Arrange
        var mockMealAppService = new Mock<IMealAppService>();

        // Create a list of meals with different Id values
        var meals = new List<Meal>
        {
            new Meal { Id = 3, Name = "Meal 3", Price = 20.00 },
            new Meal { Id = 1, Name = "Meal 1", Price = 10.00 },
            new Meal { Id = 2, Name = "Meal 2", Price = 15.00 }
        };

        // Setup the mock to return the list of meals when Select is called
        mockMealAppService.Setup(s => s.Select()).Returns(meals);

        // Create the controller instance, passing the mocked service
        var controller = new MealController(mockMealAppService.Object);

        // Act
        // Call the Select method, requesting to sort by "Id" in ascending order
        var result = controller.Select("Id", "asc") as ViewResult;

        // Retrieve the model from the ViewResult, which should contain a list of meals
        var model = result?.Model as List<Meal>;

        // Assert
        // Ensure that the model is not null
        Assert.NotNull(model);

        // Verify that the meals are sorted by Id in ascending order
        Assert.Equal(1, model[0].Id); // First meal should have Id = 1
        Assert.Equal(2, model[1].Id); // Second meal should have Id = 2
        Assert.Equal(3, model[2].Id); // Third meal should have Id = 3
    }

    // Test case to verify that the Select method sorts meals by Price in descending order
    [Fact]
    public void Select_SortsMealsByPriceDescending()
    {
        // Arrange
        var mockMealAppService = new Mock<IMealAppService>();

        // Create a list of meals with different price values
        var meals = new List<Meal>
        {
            new Meal { Id = 3, Name = "Meal 3", Price = 20.00 },
            new Meal { Id = 1, Name = "Meal 1", Price = 10.00 },
            new Meal { Id = 2, Name = "Meal 2", Price = 15.00 }
        };

        // Setup the mock to return the list of meals when Select is called
        mockMealAppService.Setup(s => s.Select()).Returns(meals);

        // Create the controller instance, passing the mocked service
        var controller = new MealController(mockMealAppService.Object);

        // Act
        // Call the Select method, requesting to sort by "Price" in descending order
        var result = controller.Select("Price", "desc") as ViewResult;

        // Retrieve the model from the ViewResult, which should contain a list of meals
        var model = result?.Model as List<Meal>;

        // Assert
        // Ensure that the model is not null
        Assert.NotNull(model);

        // Verify that the meals are sorted by Price in descending order
        Assert.Equal(20.00, model[0].Price); // First meal should have Price = 20.00
        Assert.Equal(15.00, model[1].Price); // Second meal should have Price = 15.00
        Assert.Equal(10.00, model[2].Price); // Third meal should have Price = 10.00
    }

    // Test case to verify that the Delete method redirects to Select after successfully deleting a meal
    [Fact]
    public void Delete_ValidId_RedirectsToSelect()
    {
        // Arrange
        var mockMealAppService = new Mock<IMealAppService>();

        // Setup the mock to return true for the Delete method when called with a specific meal ID (1)
        mockMealAppService.Setup(m => m.Delete(1)).Returns(true);

        // Create the controller instance, passing the mocked service
        var controller = new MealController(mockMealAppService.Object);

        // Act
        // Call the Delete method with a valid meal ID (1)
        var result = controller.Delete(1) as RedirectToActionResult;

        // Assert
        // Ensure that the result is a RedirectToActionResult
        Assert.NotNull(result);

        // Verify that the redirection is to the "Select" action after deletion
        Assert.Equal("Select", result.ActionName);

        // Verify that the Delete method was called exactly once with the specified meal ID
        mockMealAppService.Verify(m => m.Delete(1), Times.Once);
    }
}
