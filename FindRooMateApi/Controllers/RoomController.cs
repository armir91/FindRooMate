using FindRooMateApi.BLL.Services.Interface;
using FindRooMateApi.DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;

namespace FindRooMateApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;
        private readonly IDormitoryService _dormitoryService;

        public RoomController(IDormitoryService dormitoryService, IRoomService roomService)
        {
            _dormitoryService = dormitoryService ?? throw new ArgumentNullException(nameof(dormitoryService));
            _roomService = roomService ?? throw new ArgumentNullException(nameof(roomService));
        }

        public IDormitoryService Get_dormitoryService()
        {
            return _dormitoryService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(string name, int dormitory, int capacity)
        {
            var res = _dormitoryService.GetAsync(dormitory);
            if (string.IsNullOrEmpty(name) || capacity.Equals(0))
            {

                return BadRequest("Plotesoj");
            }
            var result = await _roomService.AddAsync(name,res.Id, capacity);
            return Ok(result);


        }
    }
}
