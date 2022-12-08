using FindRooMateApi.BLL.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FindRooMateApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DormitoryController : ControllerBase
    {
        private readonly IDormitoryService _dormitoryService;

        public DormitoryController(IDormitoryService dormitoryService)
        {
            _dormitoryService = dormitoryService ?? throw new ArgumentNullException(nameof(dormitoryService));
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(string code, string name, int maxcap)
        {
            if (string.IsNullOrEmpty(code) || string.IsNullOrEmpty(name) || maxcap.Equals(0))
            {
                return BadRequest("Plotesoj");
            }
            var createdDormitory = await _dormitoryService.AddAsync(code, name, maxcap);
            return Ok(createdDormitory);

        }



    }
}
