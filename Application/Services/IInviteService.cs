using events_manager_api.Domain.Entities;
using events_manager_api.Domain.Enums;
using events_manager_api.Application.Dtos;

namespace events_manager_api.Application.Services;

public interface IInviteService
{

    /// <summary>
    /// Returns all invites for a given event id.
    /// </summary>
    /// <param name="eventId"></param>
    /// <returns>A collection of <see cref="InviteRetrievalDto"/> objects.</returns>
    public Task<ICollection<InviteRetrievalDto>> GetInvitesByEventId(int eventId);

    /// <summary>
    /// Returns all invites for a given developer email.
    /// </summary>
    /// <param name="developerEmail"></param>
    /// <returns>A collection of <see cref="InviteRetrievalDto"/> objects.</returns>
    public Task<ICollection<InviteRetrievalDto>> GetInvitesByDeveloperEmail(string developerEmail);

    /// <summary>
    /// Returns all invites for a given event id and status (Accepted, Rejected, Pending).
    /// </summary>
    /// <param name="eventId"></param>
    /// <param name="status"></param>
    /// <returns>A collection of <see cref="InviteRetrievalDto"/> objects.</returns>
    public Task<ICollection<InviteRetrievalDto>> GetInvitesByEventIdAndStatus(int eventId, InviteResponseStatus status);

    /// <summary>
    /// Returns all invites for a given developer email and status (Accepted, Rejected, Pending).
    /// </summary>
    /// <param name="developerEmail"></param>
    /// <param name="status"></param>
    /// <returns>A collection of <see cref="InviteRetrievalDto"/> objects.</returns>
    public Task<ICollection<InviteRetrievalDto>> GetInvitesByDeveloperEmailAndStatus(string developerEmail, InviteResponseStatus status);

    /// <summary>
    /// Update the status of an invite for a given event id and invite id and status (Accepted, Rejected, Pending).
    /// </summary>
    /// <param name="eventId"></param>
    /// <param name="inviteId"></param>
    /// <param name="status"></param>
    /// <returns>A <see cref="InviteRetrievalDto"/> object.</returns>
    public Task<InviteRetrievalDto> UpdateInviteStatus(int eventId, int inviteId, InviteResponseStatus status);

    /// <summary>
    /// Creates a new invite for a given event id and developer email.
    /// </summary>
    /// <param name="eventId"></param>
    /// <param name="developerEmail"></param>
    /// <returns>A <see cref="InviteRetrievalDto"/> object.</returns>
    Task<InviteRetrievalDto> CreateInvite(int eventId, string developerEmail);

    /// <summary>
    /// Creates a set of invites for a given event id and a list of developer emails from a <see cref="SendInviteDto"/> object.
    /// </summary>
    /// <param name="sendInviteDto"></param>
    /// <returns></returns>
    public Task<ICollection<InviteRetrievalDto>> CreateInvites(SendInviteDto sendInviteDto);
}