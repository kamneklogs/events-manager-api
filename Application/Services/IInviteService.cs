using events_manager_api.Domain.Entities;
using events_manager_api.Domain.Enums;
using events_manager_api.Application.Dtos;

namespace events_manager_api.Application.Services;

public interface IInviteService
{
    public Task<ICollection<InviteRetrievalDto>> GetInvitesByEventId(int eventId);
    public Task<ICollection<InviteRetrievalDto>> GetInvitesByDeveloperEmail(string developerEmail);
    public Task<ICollection<InviteRetrievalDto>> GetInvitesByEventIdAndStatus(int eventId, InviteResponseStatus status);
    public Task<ICollection<InviteRetrievalDto>> GetInvitesByDeveloperEmailAndStatus(string developerEmail, InviteResponseStatus status);
    public Task<InviteRetrievalDto> UpdateInviteStatus(int eventId, int inviteId, InviteResponseStatus status);
    public Task<InviteRetrievalDto> CreateInvite(int eventId, string developerEmail);
    public Task<ICollection<InviteRetrievalDto>> CreateInvites(SendInviteDto sendInviteDto);
}