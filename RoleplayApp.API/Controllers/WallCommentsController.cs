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
    public class WallCommentsController : ControllerBase
    {
        private readonly IWallCommentsInfrastructure _wallCommentsInfrastructure;
        private readonly IMapper _mapper;
        private readonly IWallCommentsDomain _wallCommentsDomain;

        public WallCommentsController(IWallCommentsInfrastructure wallCommentsInfrastructure, IMapper mapper, IWallCommentsDomain wallCommentsDomain)
        {
            _wallCommentsInfrastructure = wallCommentsInfrastructure;
            _mapper = mapper;
            _wallCommentsDomain = wallCommentsDomain;
        }

        //GET 
        [HttpGet]
        public async Task<List<WallCommentsResponse>> GetAllAsync()
        {
            var wallComments = await _wallCommentsInfrastructure.GetAllAsync();
            var wallCommentsResponse = _mapper.Map<List<WallComments>, List<WallCommentsResponse>>(wallComments);
            return wallCommentsResponse;
        }
        //GET
        [HttpGet("/send/{senderId}")]
        public async Task<List<WallCommentsResponse>> GetAllBySenderIdAsync(int senderId)
        {
            var wallComments = await _wallCommentsInfrastructure.GetBySenderId(senderId);
            var wallCommentsResponse = _mapper.Map<List<WallComments>, List<WallCommentsResponse>>(wallComments);
            return wallCommentsResponse;
        }
        //GET
        [HttpGet("/receive/{receiverId}")]
        public async Task<List<WallCommentsResponse>> GetAllByReceiverIdAsync(int receiverId)
        {
            var wallComments = await _wallCommentsInfrastructure.GetByReceiverId(receiverId);
            var wallCommentsResponse = _mapper.Map<List<WallComments>, List<WallCommentsResponse>>(wallComments);
            return wallCommentsResponse;
        }
        //POST
        [HttpPost]
        public async Task PostAsync([FromBody] WallCommentsRequest request)
        {
            if (ModelState.IsValid)
            {
                var wallComments = _mapper.Map<WallCommentsRequest, WallComments>(request);
                await _wallCommentsDomain.SaveAsync(wallComments);
            }
            else
            {
                StatusCode(400);
            }
        }
    }
}
