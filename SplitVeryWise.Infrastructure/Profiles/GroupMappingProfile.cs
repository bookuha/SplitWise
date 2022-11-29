using AutoMapper;
using SplitVeryWise.Application.Contracts.DTOs.Group;
using SplitVeryWise.Domain.Entities;

namespace SplitVeryWise.Infrastructure.Profiles;

public class GroupMappingProfile : Profile
{
    public GroupMappingProfile()
    {
        CreateMap<Group, GroupNameResponse>();
        CreateMap<GroupCreateRequest, Group>();
    }
}