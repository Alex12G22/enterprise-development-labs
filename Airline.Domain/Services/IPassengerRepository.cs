using Airline.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Airline.Domain.Services;

public interface IPassengerRepository
{
    Task<IList<Passenger>> GetAll();
    Task<Passenger?> GetById(int id);
    Task<Passenger> Add(Passenger passenger);
    Task<Passenger> Update(Passenger passenger);
    Task<bool> Delete(int id);
    Task<IList<Passenger>> GetPassengersWithZeroBaggage(int flightId);
}