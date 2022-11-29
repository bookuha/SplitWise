using SplitVeryWise.Application.Contracts.DTOs.Group;
using SplitVeryWise.Application.Contracts.DTOs.User;

namespace SplitVeryWise.Domain.Abstractions;

public interface IGroupService
{
    Task<IEnumerable<GroupNameResponse>> GetGroups();

    Task<GroupResponse> GetGroupById(int id);

    Task CreateGroup(GroupCreateRequest createRequest); // Contains user id so the creator
                                                                       // will be made the first participant

    Task UpdateGroup(int id, GroupUpdateRequest updateRequest);

    Task DeleteGroup(int id);

    Task<IEnumerable<UserResponse>> GetUsersByGroupId(int id);

    Task<UserResponse> GetSingleUserByGroupId(int id, int userId);

    Task AddUserToGroup(int id, int userId, int inviterUserId);

    Task DeleteUserFromGroup(int id, int userId); // Well, who's able to?




}