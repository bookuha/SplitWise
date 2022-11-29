using Microsoft.AspNetCore.Mvc;
using SplitVeryWise.Application.Contracts.DTOs.Group;
using SplitVeryWise.Application.Contracts.DTOs.User;
using SplitVeryWise.Domain.Abstractions;


namespace SplitVeryWise.Web.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {

        private readonly IGroupService _groupService;

        public GroupsController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        // GET: <GroupsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GroupNameResponse>>> GetGroups()
        {
            return Ok(await _groupService.GetGroups());
        }

        // GET <GroupsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GroupResponse>> GetGroupById(int id)
        {
            return Ok(await _groupService.GetGroupById(id));
        }

        // POST <GroupsController>
        [HttpPost]
        public async Task<ActionResult> CreateGroup([FromBody] GroupCreateRequest createRequest)
        {
            await _groupService.CreateGroup(createRequest);
            return Ok();
        }

        // PUT <GroupsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<GroupResponse>> UpdateGroup(int id, [FromBody] GroupUpdateRequest updateRequest)
        {
            await _groupService.UpdateGroup(id, updateRequest);
            return Ok();
        }

        // DELETE <GroupsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GroupResponse>> DeleteGroup(int id)
        {
            await _groupService.DeleteGroup(id);
            return Ok();
        }

        [HttpGet("{groupId}/users")]
        public async Task<ActionResult<IEnumerable<UserResponse>>> GetUsersByGroupId(int groupId)
        {
            return Ok(await _groupService.GetUsersByGroupId(groupId));
        }

        [HttpGet("{groupId}/users/{userId}")]
        public async Task<ActionResult<UserResponse>> GetSingleUserByGroupId(int groupId, int userId)
        {
            return Ok(await _groupService.GetSingleUserByGroupId(groupId, userId));
        }

        [HttpPut("{groupId}/users")]
        public async Task<ActionResult<UserResponse>> AddUserToGroup(int groupId, [FromBody] AddUserRequest request) // TODO: Eliminate tuple. Access inviter id from the HttpContext
        {
            await _groupService.AddUserToGroup(groupId, request.UserId, request.InviterUserId);
            return Ok();
        } 
    }
}
