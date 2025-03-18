using Airline.Domain.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Airline.Domain.Services;

/// <summary>
/// Интерфейс репозитория для работы с рейсами.
/// </summary>
public interface IFlightRepository
{
    /// <summary>
    /// Получает список всех рейсов.
    /// </summary>
    /// <returns>Список всех рейсов.</returns>
    Task<IList<Flight>> GetAll();

    /// <summary>
    /// Получает рейс по его идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор рейса.</param>
    /// <returns>Рейс с указанным идентификатором или null, если рейс не найден.</returns>
    Task<Flight?> GetById(int id);

    /// <summary>
    /// Добавляет новый рейс в репозиторий.
    /// </summary>
    /// <param name="flight">Рейс для добавления.</param>
    /// <returns>Добавленный рейс.</returns>
    Task<Flight> Add(Flight flight);

    /// <summary>
    /// Обновляет существующий рейс в репозитории.
    /// </summary>
    /// <param name="flight">Рейс с обновленными данными.</param>
    /// <returns>Обновленный рейс.</returns>
    Task<Flight> Update(Flight flight);

    /// <summary>
    /// Удаляет рейс по его идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор рейса для удаления.</param>
    /// <returns>True, если рейс был удален; иначе False.</returns>
    Task<bool> Delete(int id);

    /// <summary>
    /// Получает список рейсов по указанному маршруту.
    /// </summary>
    /// <param name="departurePoint">Пункт отправления.</param>
    /// <param name="arrivalPoint">Пункт назначения.</param>
    /// <returns>Список рейсов, соответствующих указанному маршруту.</returns>
    Task<IList<Flight>> GetFlightsByRoute(string departurePoint, string arrivalPoint);

    /// <summary>
    /// Получает список рейсов по типу самолета и периоду времени.
    /// </summary>
    /// <param name="aircraftType">Тип самолета.</param>
    /// <param name="startDate">Начальная дата периода.</param>
    /// <param name="endDate">Конечная дата периода.</param>
    /// <returns>Список рейсов, соответствующих указанным критериям.</returns>
    Task<IList<Flight>> GetFlightsByAircraftTypeAndPeriod(string aircraftType, DateTime startDate, DateTime endDate);

    /// <summary>
    /// Получает топ-5 рейсов по количеству пассажиров.
    /// </summary>
    /// <returns>Список из 5 рейсов с наибольшим количеством пассажиров.</returns>
    Task<IList<Flight>> GetTop5FlightsByPassengerCount();

    /// <summary>
    /// Получает список рейсов с минимальным временем в пути.
    /// </summary>
    /// <returns>Список рейсов с минимальным временем в пути.</returns>
    Task<IList<Flight>> GetFlightsWithMinTravelTime();

    /// <summary>
    /// Получает среднюю и максимальную загрузку рейсов по указанному пункту отправления.
    /// </summary>
    /// <param name="departurePoint">Пункт отправления.</param>
    /// <returns>Кортеж, содержащий среднюю и максимальную загрузку рейсов.</returns>
    Task<(double AverageLoad, double MaxLoad)> GetFlightLoadByDeparturePoint(string departurePoint);
}
