using Airline.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Airline.Domain.Services;

/// <summary>
/// Интерфейс репозитория для работы с пассажирами.
/// </summary>
public interface IPassengerRepository
{
    /// <summary>
    /// Получает список всех пассажиров.
    /// </summary>
    /// <returns>Список всех пассажиров.</returns>
    Task<IList<Passenger>> GetAll();

    /// <summary>
    /// Получает пассажира по его идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор пассажира.</param>
    /// <returns>Пассажир с указанным идентификатором или null, если пассажир не найден.</returns>
    Task<Passenger?> GetById(int id);

    /// <summary>
    /// Добавляет нового пассажира в репозиторий.
    /// </summary>
    /// <param name="passenger">Пассажир для добавления.</param>
    /// <returns>Добавленный пассажир.</returns>
    Task<Passenger> Add(Passenger passenger);

    /// <summary>
    /// Обновляет существующего пассажира в репозитории.
    /// </summary>
    /// <param name="passenger">Пассажир с обновленными данными.</param>
    /// <returns>Обновленный пассажир.</returns>
    Task<Passenger> Update(Passenger passenger);

    /// <summary>
    /// Удаляет пассажира по его идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор пассажира для удаления.</param>
    /// <returns>True, если пассажир был удален; иначе False.</returns>
    Task<bool> Delete(int id);

    /// <summary>
    /// Получает список пассажиров с нулевым весом багажа для указанного рейса.
    /// </summary>
    /// <param name="flightId">Идентификатор рейса.</param>
    /// <returns>Список пассажиров с нулевым весом багажа, отсортированный по полному имени.</returns>
    Task<IList<Passenger>> GetPassengersWithZeroBaggage(int flightId);
}
