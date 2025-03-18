using Airline.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Airline.Domain.Services;

public interface IFlightRepository
{
    Task<IList<Flight>> GetAll();
    Task<Flight?> GetById(int id);
    Task<Flight> Add(Flight flight);
    Task<Flight> Update(Flight flight);
    Task<bool> Delete(int id);
    Task<IList<Flight>> GetFlightsByRoute(string departurePoint, string arrivalPoint);
    Task<IList<Flight>> GetFlightsByAircraftTypeAndPeriod(string aircraftType, DateTime startDate, DateTime endDate);
    Task<IList<Flight>> GetTop5FlightsByPassengerCount();
    Task<IList<Flight>> GetFlightsWithMinTravelTime();
    Task<(double AverageLoad, double MaxLoad)> GetFlightLoadByDeparturePoint(string departurePoint);
}