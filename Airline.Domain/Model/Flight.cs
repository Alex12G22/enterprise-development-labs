using System.ComponentModel.DataAnnotations;

namespace Airline.Domain.Model;

public class Flight
{
    [Key]
    public required int Id { get; set; } // Идентификатор рейса
    public required string Code { get; set; } // Шифр рейса
    public required string DeparturePoint { get; set; } // Пункт отправления
    public required string ArrivalPoint { get; set; } // Пункт прибытия
    public required DateTime DepartureDate { get; set; } // Дата отправления
    public required DateTime ArrivalDate { get; set; } // Дата прибытия
    public required TimeSpan DepartureTime { get; set; } // Время отправления
    public required TimeSpan TravelTime { get; set; } // Время в пути
    public required string AircraftType { get; set; } // Тип самолета
}