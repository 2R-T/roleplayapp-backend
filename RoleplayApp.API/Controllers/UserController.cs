using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using RoleplayApp.API.Request;
using RoleplayApp.API.Response;
using RoleplayApp.Domain.Interfaces;
using RoleplayApp.Infrastructure.Interfaces;
using RoleplayApp.Infrastructure.Models;

namespace RoleplayApp.API.Controllers
{
    [EnableCors("AllowOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserInfrastructure _userInfrastructure;
        private readonly IMapper _mapper;
        private readonly IUserDomain _userDomain;

        public UserController(IUserInfrastructure userInfrastructure, IMapper mapper, IUserDomain userDomain)
        {
            _userInfrastructure = userInfrastructure;
            _mapper = mapper;
            _userDomain = userDomain;
        }

        // GET api/user
        [HttpGet]
        public async Task<List<UserResponse>> GetAllAsync()
        {
            var users = await _userInfrastructure.GetAllAsync();
            var usersResponse = _mapper.Map<List<User>, List<UserResponse>>(users);
            return usersResponse;

        }
        // GET: api/User/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<UserResponse> GetByIdAsync(int id)
        {
            var user = await _userInfrastructure.GetByIdAsync(id);
            var userResponse = _mapper.Map<User, UserResponse>(user);
            return userResponse;
        }
        [HttpPost]
        public async Task PostAsync([FromBody] UserRequest request)
        {
            if (ModelState.IsValid)
            {
                var user = _mapper.Map<UserRequest, User>(request);

                await _userDomain.SaveAsync(user);
            }
            else
            {
                StatusCode(400);
            }
        }
        [HttpPut("{id}")]
        public async Task PutAsync(int id, [FromBody] UserRequest request)
        {
            if (ModelState.IsValid)
            {
                var user = _mapper.Map<UserRequest, User>(request);
                user.Id = id;
                await _userDomain.UpdateAsync(id, user);
            }
            else
            {
                StatusCode(400);
            }
        }
        [HttpDelete("{id}")]
        public async Task DeleteAsync(int id)
        {
            await _userDomain.DeleteAsync(id);
        }

    }
}
