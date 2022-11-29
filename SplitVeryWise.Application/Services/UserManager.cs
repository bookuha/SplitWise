using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SplitVeryWise.Application.Contracts.DTOs.User;
using SplitVeryWise.Domain.Abstractions;
using SplitVeryWise.Domain.Entities;
using SplitVeryWise.Domain.Exceptions.User;
using SplitVeryWise.Infrastructure;

namespace SplitVeryWise.Application.Services;

public class UserManager : IUserManager
{
    private readonly SplitVeryWiseContext _ctx;
    private readonly IMapper _mapper;

    public UserManager(SplitVeryWiseContext ctx, IMapper mapper)
    {
        _ctx = ctx;
        _mapper = mapper;
    }

    public async Task<IEnumerable<UserResponse>> GetUsers()
    {
        var users = await _ctx.Users.ToListAsync();

        return _mapper.Map<IEnumerable<UserResponse>>(users);
    }

    public async Task<UserResponse> GetUserById(int id)
    {
        var user = await _ctx.Users.FindAsync(id);
        if (user is null)
            throw new UserNotFoundException();

        return _mapper.Map<UserResponse>(user);
    }

    public async Task<UserResponse> Register(UserRegisterRequest registerRequest) // TODO: Return JWT
    {
        var user = _mapper.Map<User>(registerRequest);

        _ctx.Users.Add(user);

        await _ctx.SaveChangesAsync();

        return _mapper.Map<UserResponse>(user);
    }

    public async Task<UserResponse> Login(UserLoginRequest loginRequest) // TODO: Return JWT
    {
        if (await _ctx.Users
                .AnyAsync(user => user.Name == loginRequest.Name && user.Password == loginRequest.Password)
            is false)
            throw new UserNotFoundException();

        return new UserResponse(9999, "TEST");
        // Auth logic ...
    }

    public async Task<UserResponse> UpdateUser(int id, UserUpdateRequest updateRequest)
    {
        var user = await _ctx.Users.FindAsync(id);
        if (user is null)
            throw new UserNotFoundException();

        user.Name = updateRequest.Name;
        user.Password = updateRequest.Password;

        _ctx.Users.Update(user);

        await _ctx.SaveChangesAsync();

        return _mapper.Map<UserResponse>(user);
    }

    public async Task<UserResponse> DeleteUser(int id)
    {
        var user = await _ctx.Users.FindAsync(id);
        if (user is null)
            throw new UserNotFoundException();

        _ctx.Users.Remove(user);

        await _ctx.SaveChangesAsync();

        return _mapper.Map<UserResponse>(user);
    }
}