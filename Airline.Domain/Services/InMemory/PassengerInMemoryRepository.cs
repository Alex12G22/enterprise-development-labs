using Airline.Domain.Model;
using Airline.Domain.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airline.Domain.Services.InMemory;

/// <summary>
/// Репозиторий для работы с пассажирами, хранящимися в памяти.
/// </summary>
public class PassengerInMemoryRepository : IPassengerRepository
{
    private readonly List<Passenger> _passengers;

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="PassengerInMemoryRepository"/>.
    /// </summary>
    public PassengerInMemoryRepository()
    {
        _passengers = DataSeeder.Passengers;
    }

    /// <summary>
    /// Получает список всех пассажиров.
    /// </summary>
    /// <returns>Список всех пассажиров.</returns>
    public Task<IList<Passenger>> GetAll()
    {
        return Task.FromResult<IList<Passenger>>(_passengers);
    }

    /// <summary>
    /// Получает пассажира по его идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор пассажира.</param>
    /// <returns>Пассажир с указанным идентификатором или null, если пассажир не найден.</returns>
    public Task<Passenger?> GetById(int id)
    {
        var passenger = _passengers.FirstOrDefault(p => p.Id == id);
        return Task.FromResult(passenger);
    }

    /// <summary>
    /// Добавляет нового пассажира в репозиторий.
    /// </summary>
    /// <param name="passenger">Пассажир для добавления.</param>
    /// <returns>Добавленный пассажир.</returns>
    public Task<Passenger> Add(Passenger passenger)
    {
        _passengers.Add(passenger);
        return Task.FromResult(passenger);
    }

    /// <summary>
    /// Обновляет существующего пассажира в репозитории.
    /// </summary>
    /// <param name="passenger">Пассажир с обновленными данными.</param>
    /// <returns>Обновленный пассажир.</returns>
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

    /// <summary>
    /// Удаляет пассажира по его идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор пассажира для удаления.</param>
    /// <returns>True, если пассажир был удален; иначе False.</returns>
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

    /// <summary>
    /// Получает список пассажиров с нулевым весом багажа для указанного рейса.
    /// </summary>
    /// <param name="flightId">Идентификатор рейса.</param>
    /// <returns>Список пассажиров с нулевым весом багажа, отсортированный по полному имени.</returns>
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
