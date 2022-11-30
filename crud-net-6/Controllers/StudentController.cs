using crud_net_6.Data.Interfaces;
using crud_net_6.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace crud_net_6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ILogger<StudentController> _logger;

        private readonly IStudent<TblStudent> _repository;

        public StudentController(ILogger<StudentController> logger, IStudent<TblStudent> repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> get()
        {
            try
            {
                return Ok(await _repository.GetAll());
            } catch(Exception ex)
            {
                _logger.LogError($"Failed to get items: {ex}");
                return StatusCode(500, "Internal Server Error. Please try again later");
            }
        }
    }
}
