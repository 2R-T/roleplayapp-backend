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
    public class BiographyController : ControllerBase
    {
        private readonly IBiographyInfrastructure _biographyInfrastructure;
        private readonly IBiographyDomain _biographyDomain; 
        private readonly IMapper _mapper;

        public BiographyController(IBiographyInfrastructure biographyInfrastructure, IBiographyDomain biographyDomain, IMapper mapper)
        {
            _biographyInfrastructure = biographyInfrastructure;
            _biographyDomain = biographyDomain;
            _mapper = mapper;
        }

        // GET api/biography
        [HttpGet]
        public async Task<List<BiographyResponse>> GetAllAsync()
        {
            var biographies = await _biographyInfrastructure.GetAllAsync();
            var biographyResponse = _mapper.Map<List<Biography>, List<BiographyResponse>>(biographies);
            return biographyResponse;
        }
        // GET: api/Biography/5
        [HttpGet("{id}")]
        public async Task<BiographyResponse> GetByIdAsync(int id)
        {
            var biography = await _biographyInfrastructure.GetByIdAsync(id);
            var biographyResponse = _mapper.Map<Biography, BiographyResponse>(biography);
            return biographyResponse;
        }
        //PUT
        [HttpPut("{id}")]
        public async Task PutAsync(int id, [FromBody] BiographyRequest biographyRequest)
        {
            if (ModelState.IsValid)
            {
                var biographyToUpdate = _mapper.Map<BiographyRequest, Biography>(biographyRequest);
                biographyToUpdate.Id = id;
                await _biographyDomain.UpdateAsync(id, biographyToUpdate);
            }
            else
            {
                StatusCode(400);
            }
        }
    }
}
