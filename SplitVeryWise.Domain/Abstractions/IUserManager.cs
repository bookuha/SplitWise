using SplitVeryWise.Application.Contracts.DTOs.User;

namespace SplitVeryWise.Domain.Abstractions;

public interface IUserManager
{
    Task<IEnumerable<UserResponse>> GetUsers();

    Task<UserResponse> GetUserById(int id);

    Task<UserResponse> Register(UserRegisterRequest registerRequest); // TODO: Return JWT

    Task<UserResponse> Login(UserLoginRequest loginRequest); // TODO: Return JWT

    Task<UserResponse> UpdateUser(int id,UserUpdateRequest updateRequest);

    Task<UserResponse> DeleteUser(int id);

}