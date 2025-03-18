using Airline.Domain.Model;
using Airline.Domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airline.Domain.Services.InMemory;

public class FlightInMemoryRepository : IFlightRepository
{
    private readonly List<Flight> _flights;

    public FlightInMemoryRepository()
    {
        _flights = DataSeeder.Flights;
    }

    public Task<IList<Flight>> GetAll()
    {
        return Task.FromResult<IList<Flight>>(_flights);
    }

    public Task<Flight?> GetById(int id)
    {
        var flight = _flights.FirstOrDefault(f => f.Id == id);
        return Task.FromResult(flight);
    }

    public Task<Flight> Add(Flight flight)
    {
        _flights.Add(flight);
        return Task.FromResult(flight);
    }

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

    public Task<IList<Flight>> GetFlightsByRoute(string departurePoint, string arrivalPoint)
    {
        var flights = _flights
            .Where(f => f.DeparturePoint == departurePoint && f.ArrivalPoint == arrivalPoint)
            .ToList();
        return Task.FromResult<IList<Flight>>(flights);
    }

    public Task<IList<Flight>> GetFlightsByAircraftTypeAndPeriod(string aircraftType, DateTime startDate, DateTime endDate)
    {
        var flights = _flights
            .Where(f => f.AircraftType == aircraftType && f.DepartureDate >= startDate && f.DepartureDate <= endDate)
            .ToList();
        return Task.FromResult<IList<Flight>>(flights);
    }

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

    public Task<IList<Flight>> GetFlightsWithMinTravelTime()
    {
        var minTravelTime = _flights.Min(f => f.TravelTime);
        var flights = _flights
            .Where(f => f.TravelTime == minTravelTime)
            .ToList();
        return Task.FromResult<IList<Flight>>(flights);
    }

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