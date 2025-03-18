using System.ComponentModel.DataAnnotations;

namespace Airline.Domain.Model;

public class Aircraft
{
    [Key]
    public required int Id { get; set; } // Идентификатор самолета
    public required string Model { get; set; } // Модель самолета
    public required double LoadCapacity { get; set; } // Грузоподъемность
    public required double Performance { get; set; } // Производительность
    public required int MaxPassengers { get; set; } // Максимальное количество пассажиров
}