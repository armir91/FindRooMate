using FindRooMateApi.BLL.Services.Implementation;
using FindRooMateApi.BLL.Services.Interface;
using FindRooMateApi.DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FindRooMateApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;
        private readonly IDormitoryService _dormitoryService;

        public RoomController(IRoomService roomservice, IDormitoryService dormitoryService)
        {
            _roomService = roomservice ?? throw new ArgumentNullException(nameof(roomservice));
            _dormitoryService = dormitoryService ?? throw new ArgumentNullException(nameof(dormitoryService));
        }

        [HttpGet("read")]
        public async Task<IActionResult> Get()
        {
            var result = await _roomService.GetAllAsync();

            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] Room room)
        {
            if (string.IsNullOrEmpty(room.Name) && room.Capacity == 0 && room.DormitoryId == 0)
            {
                BadRequest("Please provide all neccesary information for the room");
            }
            var result = await _roomService.AddAsync(room.Name, room.DormitoryId, room.Capacity);

            if (result <= 0)
            {
                return BadRequest("The room has not been created successfully!");
            }
            else
            {
                string uri = $"https://localhost:7164/api/Room/{result}/";
                return Created(uri, result);
            }

        }
    }
}
