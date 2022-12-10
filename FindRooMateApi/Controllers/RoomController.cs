using FindRooMateApi.BLL.Services.Implementation;
using FindRooMateApi.BLL.Services.Interface;
using FindRooMateApi.DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FindRooMateApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomservice)
        {
            _roomService = roomservice ?? throw new ArgumentNullException(nameof(roomservice));
        }

        [HttpGet("read")]
        public async Task<IActionResult> Get()
        {
            var result = await _roomService.GetAllAsync();

            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(string name, int dormitoryId, int capacity)
        {
            if (string.IsNullOrEmpty(name) || dormitoryId == 0 || capacity == 0)
            {
                BadRequest("Please provide all neccesary information for the room");
            }

            var result = await _roomService.AddAsync(name, dormitoryId, capacity);

            return Ok(result);
        }
    }
}
