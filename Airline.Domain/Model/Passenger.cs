using System.ComponentModel.DataAnnotations;

namespace Airline.Domain.Model;

public class Passenger
{
    [Key]
    public required int Id { get; set; } // Идентификатор пассажира
    public required string PassportNumber { get; set; } // Номер паспорта
    public required string FullName { get; set; } // ФИО
}