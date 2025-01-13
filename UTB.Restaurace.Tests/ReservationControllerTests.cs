using Moq;
using Xunit;
using System.Collections.Generic;
using System.Linq;
using UTB.Restaurace.Domain.Entities;
using UTB.Restaurace.Infrastructure.Database;
using UTB.Restaurace.Application.Implementation;
using Microsoft.EntityFrameworkCore;
using UTB.Restaurace.Application.Abstraction;
using Microsoft.AspNetCore.Mvc;
using UTB.Restaurace.Areas.Admin.Controllers;

public class ReservationControllerTests
{
    // Test case to verify that the Edit GET method returns NotFound when an invalid reservation ID is provided
    [Fact]
    public void Edit_InvalidId_ReturnsNotFound()
    {
        // Arrange
        var reservationId = 999; // Set up an invalid reservation ID that doesn't exist
        var mockReservationAppService = new Mock<IReservationAppService>();

        // Mock the GetById method to return null when the invalid reservationId is passed
        mockReservationAppService.Setup(service => service.GetById(reservationId)).Returns((Reservation)null);

        var controller = new ReservationController(mockReservationAppService.Object);

        // Act
        var result = controller.Edit(reservationId); // Call the Edit method with the invalid ID

        // Assert
        // The result should be of type NotFoundResult since no reservation was found
        Assert.IsType<NotFoundResult>(result);
    }

    // Test case to verify that the Edit POST method redirects to the Select action after a successful reservation update
    [Fact]
    public void Edit_PostValidReservation_RedirectsToSelect()
    {
        // Arrange
        var reservationId = 1; // Define a valid reservation ID
        var reservation = new Reservation { Id = reservationId, UserName = "Test User", ReservationDate = DateTime.Now };

        var mockReservationAppService = new Mock<IReservationAppService>();

        // Mock the Update method to ensure that it gets called when the reservation is posted
        mockReservationAppService.Setup(service => service.Update(reservation));

        var controller = new ReservationController(mockReservationAppService.Object);

        // Act
        var result = controller.Edit(reservationId, reservation) as RedirectToActionResult;

        // Assert
        // Ensure that the result is a redirect to the Select action
        Assert.NotNull(result); // The result should not be null
        Assert.Equal("Select", result.ActionName); // Check that the action name is "Select" (the expected redirect destination)

        // Verify that the Update method was called exactly once on the service
        mockReservationAppService.Verify(service => service.Update(reservation), Times.Once);
    }

    // Test case to verify that the Edit POST method returns a BadRequest when the ID in the URL does not match the ID of the posted reservation
    [Fact]
    public void Edit_PostInvalidReservationId_ReturnsBadRequest()
    {
        // Arrange
        var reservationId = 1; // The ID from the URL
        var reservation = new Reservation { Id = 2, UserName = "Test User", ReservationDate = DateTime.Now }; // The posted reservation has a different ID

        var mockReservationAppService = new Mock<IReservationAppService>();
        var controller = new ReservationController(mockReservationAppService.Object);

        // Act
        var result = controller.Edit(reservationId, reservation); // Call the Edit method with mismatched IDs

        // Assert
        // The result should be a BadRequest since the IDs do not match
        Assert.IsType<BadRequestResult>(result);
    }
}
