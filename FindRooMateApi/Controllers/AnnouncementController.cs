using FindRooMateApi.BLL.Services.Implementation;
using FindRooMateApi.BLL.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace FindRooMateApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnnouncementController : ControllerBase
    {

        private readonly IAnnouncementService _announcementService;
        public AnnouncementController(IAnnouncementService announcementService)
        {
            _announcementService = announcementService ?? throw new ArgumentNullException(nameof(announcementService));
        }



        [HttpPost("create")]
        public async Task<IActionResult> Create(string title, string description, int roomId)
        {
            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(description) || roomId < 0)
            {
                return BadRequest("Te lutem ploteso te dhenat!");
            }
            var createdAnnoucement = await _announcementService.AddAsync(title, description, roomId);

            return Ok(createdAnnoucement);
        }

        [HttpGet("get")]
        public async Task<IActionResult> Get(int announcementId)
        {
            var result = _announcementService.GetAsync(announcementId);
            return Ok(result);
        }

    }
}
