using events_manager_api.Domain.Entities;
using events_manager_api.Application.Dtos;

namespace events_manager_api.Application.Services;
public interface IEventService
{
    public Task<EventRetrievalDto> CreateEvent(EventCreationDto eventEntity);
    public EventRetrievalDto GetEventById(int id);
    public Task<ICollection<EventRetrievalDto>> GetEvents();
}