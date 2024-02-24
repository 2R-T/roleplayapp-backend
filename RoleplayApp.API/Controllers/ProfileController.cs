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
    public class ProfileController : ControllerBase
    {
        private readonly IProfileInfrastructure _profileInfrastructure;
        private readonly IProfileDomain _profileDomain;
        private readonly IMapper _mapper;

        public ProfileController(IProfileInfrastructure profileInfrastructure, IProfileDomain profileDomain, IMapper mapper)
        {
            _profileInfrastructure = profileInfrastructure;
            _profileDomain = profileDomain;
            _mapper = mapper;
        }

        // GET api/profile
        [HttpGet]
        public async Task<List<ProfileResponse>> GetAllAsync()
        {
            var profiles = await _profileInfrastructure.GetAllAsync();
            var profileResponse = _mapper.Map<List<Infrastructure.Models.Profile>, List<ProfileResponse>>(profiles);
            return profileResponse;
        }
        //UPDATE 
        [HttpPut("{id}")]
        public async Task PutAsync(int id, [FromBody] ProfileRequest profileRequest)
        {
            if (ModelState.IsValid)
            {
                var profileToUpdate = _mapper.Map<ProfileRequest, Infrastructure.Models.Profile>(profileRequest);
                profileToUpdate.Id = id;
                await _profileDomain.UpdateAsync(id, profileToUpdate);
            }
            else
            {
                StatusCode(400);
            }
        }
        
    }
}
