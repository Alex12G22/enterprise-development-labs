using Airline.Domain.Model;
using Airline.Domain.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airline.Domain.Services.InMemory;

public class PassengerInMemoryRepository : IPassengerRepository
{
    private readonly List<Passenger> _passengers;

    public PassengerInMemoryRepository()
    {
        _passengers = DataSeeder.Passengers;
    }

    public Task<IList<Passenger>> GetAll()
    {
        return Task.FromResult<IList<Passenger>>(_passengers);
    }

    public Task<Passenger?> GetById(int id)
    {
        var passenger = _passengers.FirstOrDefault(p => p.Id == id);
        return Task.FromResult(passenger);
    }

    public Task<Passenger> Add(Passenger passenger)
    {
        _passengers.Add(passenger);
        return Task.FromResult(passenger);
    }

    public Task<Passenger> Update(Passenger passenger)
    {
        var existingPassenger = _passengers.FirstOrDefault(p => p.Id == passenger.Id);
        if (existingPassenger != null)
        {
            existingPassenger.PassportNumber = passenger.PassportNumber;
            existingPassenger.FullName = passenger.FullName;
        }
        return Task.FromResult(passenger);
    }

    public Task<bool> Delete(int id)
    {
        var passenger = _passengers.FirstOrDefault(p => p.Id == id);
        if (passenger != null)
        {
            _passengers.Remove(passenger);
            return Task.FromResult(true);
        }
        return Task.FromResult(false);
    }

    public Task<IList<Passenger>> GetPassengersWithZeroBaggage(int flightId)
    {
        var passengers = DataSeeder.Bookings
            .Where(b => b.FlightId == flightId && b.BaggageWeight == 0)
            .Join(_passengers,
                b => b.PassengerId,
                p => p.Id,
                (b, p) => p)
            .OrderBy(p => p.FullName)
            .ToList();
        return Task.FromResult<IList<Passenger>>(passengers);
    }
}