using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SplitVeryWise.Application.Contracts.DTOs.Group;
using SplitVeryWise.Application.Contracts.DTOs.User;
using SplitVeryWise.Domain.Abstractions;
using SplitVeryWise.Domain.Entities;
using SplitVeryWise.Domain.Exceptions.Group;
using SplitVeryWise.Domain.Exceptions.User;
using SplitVeryWise.Infrastructure;

namespace SplitVeryWise.Application.Services;

public class GroupService : IGroupService
{
    private readonly SplitVeryWiseContext _ctx;
    private readonly IMapper _mapper;


    public GroupService(SplitVeryWiseContext ctx, IMapper mapper)
    {
        _ctx = ctx;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GroupNameResponse>> GetGroups()
    {
        var groups = await _ctx.Groups
            .Include(group => group.Users)
            .ToListAsync();

        return _mapper.Map<IEnumerable<GroupNameResponse>>(groups);

    }

    public async Task<GroupResponse> GetGroupById(int id)
    {
        var group = await _ctx.Groups
            .Include(group => group.Users) // Will include users in further collections?
            .Include(group => group.Expenses).ThenInclude(expense => expense.Lines)
            .Include(group => group.Payments)
            .SingleOrDefaultAsync(group => group.Id == id);

        if (group == null)
        {
            throw new GroupNotFoundException();
        }

        return _mapper.Map<GroupResponse>(group);
    }

    public async Task CreateGroup(GroupCreateRequest createRequest)
    {
        var groupCreator = await _ctx.Users.FindAsync(createRequest.UserId);

        if (groupCreator is null)
        {
            throw new UserNotFoundException("Creator has to be a valid user"); // TODO: Use Group related exception?
        }

        // var group = _mapper.Map<Group>(createRequest);  
                             // Feels to complicated and unobvious here

        var group = new Group
        {
            Name = createRequest.Name
        };
        group.Users.Add(groupCreator); // As the first participant

        _ctx.Groups.Add(group);

        await _ctx.SaveChangesAsync();
    }

    public async Task UpdateGroup(int id, GroupUpdateRequest updateRequest)
    {
        var group = await _ctx.Groups.FindAsync(id);

        if (group is null)
        {
            throw new GroupNotFoundException();
        }

        group.Name = updateRequest.Name;

        _ctx.Groups.Update(group);

        await _ctx.SaveChangesAsync();
    }

    public async Task DeleteGroup(int id)
    {
        var group = await _ctx.Groups.FindAsync(id);

        if (group is null)
        {
            throw new GroupNotFoundException();
        }

        _ctx.Groups.Remove(group);

        await _ctx.SaveChangesAsync();
    }

    public async Task<IEnumerable<UserResponse>> GetUsersByGroupId(int id)
    {
        var group = await _ctx.Groups
            .Include(group => group.Users)
            .SingleOrDefaultAsync(group => group.Id == id);

        if (group is null)
        {
            throw new GroupNotFoundException();
        }

        return _mapper.Map<IEnumerable<UserResponse>>(group.Users);
    }

    public async Task<UserResponse> GetSingleUserByGroupId(int groupId, int userId)
    {
        var group = await _ctx.Groups
            .Include(group => group.Users)
            .SingleOrDefaultAsync(group => group.Id == groupId);

        if (group is null)
        {
            throw new GroupNotFoundException();
        }

        var user = group.Users.SingleOrDefault(user => user.Id == userId);

        if (user is null)
        {
            throw new NoSuchUserInGroupException();
        }

        return _mapper.Map<UserResponse>(user);
    }

    public async Task AddUserToGroup(int groupId, int userId, int inviterUserId)
    {
        var group = await _ctx.Groups
            .Include(group => group.Users)
            .SingleOrDefaultAsync(group => group.Id == groupId);

        if (group is null)
        {
            throw new GroupNotFoundException();
        }

        var inviter = group.Users.SingleOrDefault(user => user.Id == inviterUserId); // Is inviter in group

        if (inviter is null)
        {
            throw new NoSuchUserInGroupException();
        }

        var toBeInvited = await _ctx.Users.FindAsync(userId);

        if (toBeInvited is null)
        {
            throw new UserNotFoundException("Therefore cannot be added to the group.");
        }

        if (group.Users.Contains(toBeInvited)) // If already participating
        {
            throw new UserIsAlreadyParticipantException();
        }

        group.Users.Add(toBeInvited);

        _ctx.Groups.Update(group);

        await _ctx.SaveChangesAsync();

    }

    public async Task DeleteUserFromGroup(int groupId, int userId)
    {
        var group = await _ctx.Groups
            .Include(group => group.Users)
            .SingleOrDefaultAsync(group => group.Id == groupId);

        if (group is null)
        {
            throw new GroupNotFoundException();
        }
        var toBeDeleted = await _ctx.Users.FindAsync(userId);

        if (toBeDeleted is null)
        {
            throw new UserNotFoundException("Therefore cannot be deleted from the group.");
        }
        
        // TODO: Well, deletion should be done from some privileged user (creator maybe).
        // ANARCHY

        group.Users.Remove(toBeDeleted);

        _ctx.Groups.Update(group);

        await _ctx.SaveChangesAsync();
    }
}