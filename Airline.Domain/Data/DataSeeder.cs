using Airline.Domain.Model;

namespace Airline.Domain.Data;

/// <summary>
/// Статический класс для заполнения начальных данных в системе.
/// </summary>
public static class DataSeeder
{
    /// <summary>
    /// Список рейсов, доступных в системе.
    /// </summary>
    public static readonly List<Flight> Flights =
    [
        new() { Id = 1, Code = "FL001", DeparturePoint = "Москва", ArrivalPoint = "Санкт-Петербург", DepartureDate = new DateTime(2023, 10, 1), ArrivalDate = new DateTime(2023, 10, 1), DepartureTime = TimeSpan.FromHours(10), TravelTime = TimeSpan.FromHours(2), AircraftType = "Boeing 737" },
        new() { Id = 2, Code = "FL002", DeparturePoint = "Москва", ArrivalPoint = "Новосибирск", DepartureDate = new DateTime(2023, 10, 2), ArrivalDate = new DateTime(2023, 10, 2), DepartureTime = TimeSpan.FromHours(12), TravelTime = TimeSpan.FromHours(4), AircraftType = "Airbus A320" },
        new() { Id = 3, Code = "FL003", DeparturePoint = "Санкт-Петербург", ArrivalPoint = "Екатеринбург", DepartureDate = new DateTime(2023, 10, 3), ArrivalDate = new DateTime(2023, 10, 3), DepartureTime = TimeSpan.FromHours(14), TravelTime = TimeSpan.FromHours(3), AircraftType = "Boeing 737" },
        new() { Id = 4, Code = "FL004", DeparturePoint = "Новосибирск", ArrivalPoint = "Казань", DepartureDate = new DateTime(2023, 10, 4), ArrivalDate = new DateTime(2023, 10, 4), DepartureTime = TimeSpan.FromHours(16), TravelTime = TimeSpan.FromHours(5), AircraftType = "Airbus A320" },
        new() { Id = 5, Code = "FL005", DeparturePoint = "Казань", ArrivalPoint = "Москва", DepartureDate = new DateTime(2023, 10, 5), ArrivalDate = new DateTime(2023, 10, 5), DepartureTime = TimeSpan.FromHours(18), TravelTime = TimeSpan.FromHours(2), AircraftType = "Boeing 737" },
        new() { Id = 6, Code = "FL006", DeparturePoint = "Екатеринбург", ArrivalPoint = "Новосибирск", DepartureDate = new DateTime(2023, 10, 6), ArrivalDate = new DateTime(2023, 10, 6), DepartureTime = TimeSpan.FromHours(20), TravelTime = TimeSpan.FromHours(4), AircraftType = "Airbus A320" },
        new() { Id = 7, Code = "FL007", DeparturePoint = "Москва", ArrivalPoint = "Казань", DepartureDate = new DateTime(2023, 10, 7), ArrivalDate = new DateTime(2023, 10, 7), DepartureTime = TimeSpan.FromHours(22), TravelTime = TimeSpan.FromHours(2), AircraftType = "Boeing 737" }
    ];

    /// <summary>
    /// Список доступных самолетов в системе.
    /// </summary>
    public static readonly List<Aircraft> Aircrafts =
    [
        new() { Id = 1, Model = "Boeing 737", LoadCapacity = 50000, Performance = 800, MaxPassengers = 200 },
        new() { Id = 2, Model = "Airbus A320", LoadCapacity = 45000, Performance = 750, MaxPassengers = 180 }
    ];

    /// <summary>
    /// Список пассажиров, зарегистрированных в системе.
    /// </summary>
    public static readonly List<Passenger> Passengers =
    [
        new() { Id = 1, PassportNumber = "1234567890", FullName = "Иванов И.И." },
        new() { Id = 2, PassportNumber = "0987654321", FullName = "Петров П.П." },
        new() { Id = 3, PassportNumber = "1122334455", FullName = "Сидоров С.С." },
        new() { Id = 4, PassportNumber = "5566778899", FullName = "Андреев А.А." },
        new() { Id = 5, PassportNumber = "9988776655", FullName = "Васильев В.В." },
        new() { Id = 6, PassportNumber = "4433221100", FullName = "Дмитриев Д.Д." },
        new() { Id = 7, PassportNumber = "0011223344", FullName = "Егоров Е.Е." }
    ];

    /// <summary>
    /// Список бронирований, сделанных пассажирами.
    /// </summary>
    public static readonly List<Booking> Bookings =
    [
        new() { Id = 1, FlightId = 1, PassengerId = 1, TicketNumber = "T001", SeatNumber = "A1", BaggageWeight = 20 },
        new() { Id = 2, FlightId = 1, PassengerId = 2, TicketNumber = "T002", SeatNumber = "A2", BaggageWeight = 0 },
        new() { Id = 3, FlightId = 2, PassengerId = 3, TicketNumber = "T003", SeatNumber = "B1", BaggageWeight = 15 },
        new() { Id = 4, FlightId = 2, PassengerId = 4, TicketNumber = "T004", SeatNumber = "B2", BaggageWeight = 0 },
        new() { Id = 5, FlightId = 3, PassengerId = 5, TicketNumber = "T005", SeatNumber = "C1", BaggageWeight = 10 },
        new() { Id = 6, FlightId = 3, PassengerId = 6, TicketNumber = "T006", SeatNumber = "C2", BaggageWeight = 0 },
        new() { Id = 7, FlightId = 4, PassengerId = 7, TicketNumber = "T007", SeatNumber = "D1", BaggageWeight = 25 }
    ];
}
