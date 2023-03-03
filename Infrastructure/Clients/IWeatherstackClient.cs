using events_manager_api.Domain.Structs;

namespace events_manager_api.Infrastructure.Clients;

public interface IWeatherstackClient
{
    Task<string?> GetTimeZoneIdByCityName(string cityName);
    Task<Location?> GetLocationByCityName(string cityName);
}