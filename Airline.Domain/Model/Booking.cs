using System.ComponentModel.DataAnnotations;

namespace Airline.Domain.Model;

public class Booking
{
    [Key]
    public required int Id { get; set; } // Идентификатор регистрации
    public required int FlightId { get; set; } // Идентификатор рейса
    public required int PassengerId { get; set; } // Идентификатор пассажира
    public required string TicketNumber { get; set; } // Номер билета
    public required string SeatNumber { get; set; } // Номер места
    public required double BaggageWeight { get; set; } // Вес багажа
}