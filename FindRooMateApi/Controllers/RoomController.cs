using FindRooMateApi.BLL.Services.Interface;
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

        [HttpPost("create")]
        public async Task<IActionResult> Create(string name, int dormitoryid, int capacity)
        {
            if (string.IsNullOrEmpty(name) && !capacity.Equals(0))
            {
                BadRequest("Please provide all neccesary information for the room");
            }
            var id = _dormitoryService.GetAsync(dormitoryid).Result;
            var result = await _roomService.AddAsync(name, id, capacity);
            return Ok(result);
        }





    }
}
