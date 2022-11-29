using SplitVeryWise.Application.Contracts.DTOs.User;

namespace SplitVeryWise.Application.Contracts.DTOs.Group;

public record GroupWithUsersResponse(int id, string Name, IEnumerable<UserResponse> Users);