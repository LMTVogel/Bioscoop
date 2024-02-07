using Xunit;
using Bioscoop;
using System;
using System.Collections.Generic;
using Bioscoop.ExportOrderBehavior;
using Bioscoop.PriceCalculatorBehavior;

public class OrderTests
{
    [Fact]
    public void CalculateStandardPrice_Should_Return_13_For_1_Premium_And_1_Normal_Ticket_On_Weekday()
    {
        // Arrange
        var movie = new Movie("Test Movie");
        
        var order = new Order(1, new StandardPriceCalculator(), new JsonExportOrder());
        var movieScreening = new MovieScreening(movie, new DateTime(2024, 2, 2), 10);
        order.AddSeatReservation(new MovieTicket(movieScreening, 1, 1, true)); // Premium ticket
        order.AddSeatReservation(new MovieTicket(movieScreening, 1, 2, false)); // Normal ticket

        // Act
        decimal price = order.CalculatePrice();

        // Assert
        Assert.Equal(23M, price);
    }

    [Fact]
    public void CalculateStandardPrice_Should_Return_54_For_6_Normal_Tickets_On_Weekend()
    {
        // Arrange
        var movie = new Movie("Test Movie");
        var order = new Order(2, new StandardPriceCalculator(), new JsonExportOrder());
        var movieScreening = new MovieScreening(movie, new DateTime(2024, 2, 2), 10);
        for (int i = 0; i < 6; i++)
        {
            order.AddSeatReservation(new MovieTicket(movieScreening, 1, i + 1, false)); // Normal tickets
        }

        // Act
        decimal price = order.CalculatePrice();

        // Assert
        Assert.Equal(54M, price);
    }

    [Fact]
    public void CalculateStandardPrice_Should_Return_23_For_1_Premium_And_3_Normal_Tickets_On_Weekday()
    {
        // Arrange
        var movie = new Movie("Test Movie");
        var order = new Order(3, new StandardPriceCalculator(), new JsonExportOrder());
        var movieScreening = new MovieScreening(movie, new DateTime(2024, 2, 1), 10);
        order.AddSeatReservation(new MovieTicket(movieScreening, 1, 1, true)); // Premium ticket
        for (int i = 0; i < 3; i++)
        {
            order.AddSeatReservation(new MovieTicket(movieScreening, 1, i + 2, false)); // Normal tickets
        }

        // Act
        decimal price = order.CalculatePrice();

        // Assert
        Assert.Equal(23M, price);
    }

    [Fact]
    public void CalculateStudentPrice_Should_Return_34_For_3_Premium_And_3_Normal_Tickets_On_Weekday()
    {
        // Arrange
        var movie = new Movie("Test Movie");
        var order = new Order(4, new StudentPriceCalculator(), new JsonExportOrder());
        var movieScreening = new MovieScreening(movie, new DateTime(2024, 2, 8), 10);
        for (int i = 0; i < 3; i++)
        {
            order.AddSeatReservation(new MovieTicket(movieScreening, 1, i + 1, true)); // Premium tickets
        }
        for (int i = 0; i < 3; i++)
        {
            order.AddSeatReservation(new MovieTicket(movieScreening, 1, i + 4, false)); // Normal tickets
        }
        
        // Act
        decimal price = order.CalculatePrice();
        
        // Assert
        Assert.Equal(34M, price);
    }
}