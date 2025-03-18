using Airline.Domain.Model;
using Airline.Domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airline.Domain.Services.InMemory;

/// <summary>
/// Репозиторий для работы с рейсами, хранящимися в памяти.
/// </summary>
public class FlightInMemoryRepository : IFlightRepository
{
    private readonly List<Flight> _flights;

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="FlightInMemoryRepository"/>.
    /// </summary>
    public FlightInMemoryRepository()
    {
        _flights = DataSeeder.Flights;
    }

    /// <summary>
    /// Получает список всех рейсов.
    /// </summary>
    /// <returns>Список всех рейсов.</returns>
    public Task<IList<Flight>> GetAll()
    {
        return Task.FromResult<IList<Flight>>(_flights);
    }

    /// <summary>
    /// Получает рейс по его идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор рейса.</param>
    /// <returns>Рейс с указанным идентификатором или null, если рейс не найден.</returns>
    public Task<Flight?> GetById(int id)
    {
        var flight = _flights.FirstOrDefault(f => f.Id == id);
        return Task.FromResult(flight);
    }

    /// <summary>
    /// Добавляет новый рейс в репозиторий.
    /// </summary>
    /// <param name="flight">Рейс для добавления.</param>
    /// <returns>Добавленный рейс.</returns>
    public Task<Flight> Add(Flight flight)
    {
        _flights.Add(flight);
        return Task.FromResult(flight);
    }

    /// <summary>
    /// Обновляет существующий рейс в репозитории.
    /// </summary>
    /// <param name="flight">Рейс с обновленными данными.</param>
    /// <returns>Обновленный рейс.</returns>
    public Task<Flight> Update(Flight flight)
    {
        var existingFlight = _flights.FirstOrDefault(f => f.Id == flight.Id);
        if (existingFlight != null)
        {
            existingFlight.Code = flight.Code;
            existingFlight.DeparturePoint = flight.DeparturePoint;
            existingFlight.ArrivalPoint = flight.ArrivalPoint;
            existingFlight.DepartureDate = flight.DepartureDate;
            existingFlight.ArrivalDate = flight.ArrivalDate;
            existingFlight.DepartureTime = flight.DepartureTime;
            existingFlight.TravelTime = flight.TravelTime;
            existingFlight.AircraftType = flight.AircraftType;
        }
        return Task.FromResult(flight);
    }

    /// <summary>
    /// Удаляет рейс по его идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор рейса для удаления.</param>
    /// <returns>True, если рейс был удален; иначе False.</returns>
    public Task<bool> Delete(int id)
    {
        var flight = _flights.FirstOrDefault(f => f.Id == id);
        if (flight != null)
        {
            _flights.Remove(flight);
            return Task.FromResult(true);
        }
        return Task.FromResult(false);
    }

    /// <summary>
    /// Получает список рейсов по указанному маршруту.
    /// </summary>
    /// <param name="departurePoint">Пункт отправления.</param>
    /// <param name="arrivalPoint">Пункт назначения.</param>
    /// <returns>Список рейсов, соответствующих указанному маршруту.</returns>
    public Task<IList<Flight>> GetFlightsByRoute(string departurePoint, string arrivalPoint)
    {
        var flights = _flights
            .Where(f => f.DeparturePoint == departurePoint && f.ArrivalPoint == arrivalPoint)
            .ToList();
        return Task.FromResult<IList<Flight>>(flights);
    }

    /// <summary>
    /// Получает список рейсов по типу самолета и периоду времени.
    /// </summary>
    /// <param name="aircraftType">Тип самолета.</param>
    /// <param name="startDate">Начальная дата периода.</param>
    /// <param name="endDate">Конечная дата периода.</param>
    /// <returns>Список рейсов, соответствующих указанным критериям.</returns>
    public Task<IList<Flight>> GetFlightsByAircraftTypeAndPeriod(string aircraftType, DateTime startDate, DateTime endDate)
    {
        var flights = _flights
            .Where(f => f.AircraftType == aircraftType && f.DepartureDate >= startDate && f.DepartureDate <= endDate)
            .ToList();
        return Task.FromResult<IList<Flight>>(flights);
    }

    /// <summary>
    /// Получает топ-5 рейсов по количеству пассажиров.
    /// </summary>
    /// <returns>Список из 5 рейсов с наибольшим количеством пассажиров.</returns>
    public Task<IList<Flight>> GetTop5FlightsByPassengerCount()
    {
        var topFlights = DataSeeder.Bookings
            .GroupBy(b => b.FlightId)
            .OrderByDescending(g => g.Count())
            .Take(5)
            .Join(_flights,
                g => g.Key,
                f => f.Id,
                (g, f) => f)
            .ToList();
        return Task.FromResult<IList<Flight>>(topFlights);
    }

    /// <summary>
    /// Получает список рейсов с минимальным временем в пути.
    /// </summary>
    /// <returns>Список рейсов с минимальным временем в пути.</returns>
    public Task<IList<Flight>> GetFlightsWithMinTravelTime()
    {
        var minTravelTime = _flights.Min(f => f.TravelTime);
        var flights = _flights
            .Where(f => f.TravelTime == minTravelTime)
            .ToList();
        return Task.FromResult<IList<Flight>>(flights);
    }

    /// <summary>
    /// Получает среднюю и максимальную загрузку рейсов по указанному пункту отправления.
    /// </summary>
    /// <param name="departurePoint">Пункт отправления.</param>
    /// <returns>Кортеж, содержащий среднюю и максимальную загрузку рейсов.</returns>
    public Task<(double AverageLoad, double MaxLoad)> GetFlightLoadByDeparturePoint(string departurePoint)
    {
        var flights = _flights
            .Where(f => f.DeparturePoint == departurePoint)
            .ToList();

        if (!flights.Any())
        {
            return Task.FromResult((0.0, 0.0)); // Возвращаем значения по умолчанию, если нет рейсов
        }

        var loads = flights
            .Select(f => DataSeeder.Bookings.Count(b => b.FlightId == f.Id))
            .ToList();

        var averageLoad = loads.Average();
        var maxLoad = (double)loads.Max(); // Приводим maxLoad к типу double

        return Task.FromResult((averageLoad, maxLoad));
    }
}
