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

        [HttpGet("getById/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> getById(int id)
        {
            try
            {
                var data = await _repository.GetById(id);

                if (data != null) return Ok(data);
                else return Ok("No data found");

            }catch(Exception ex)
            {
                _logger.LogError($"Failed to get item: {ex}");
                return StatusCode(500, "Internal Server Error. Please try again later");
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> Post([FromBody] TblStudent model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = await _repository.existsAsync(x => x.FirstName.Trim() == model.FirstName.Trim() && x.LastName.Trim() == model.LastName.Trim());

                    if (data) return Conflict("Already exists");

                    _repository.add(model);

                    if (await _repository.SaveChangesAsync())
                    {
                        return Created($"/api/[controller]/getById/{model.Id}", model);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get items: {ex}");
                return StatusCode(500, "Something went wrong");
            }

            return BadRequest("The requested action cannot be executed.");
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<TblStudent>> Put([FromBody] TblStudent model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var table = await _repository.GetById(model.Id);

                    if (table == null) return NotFound($"No item was found, id {model.Id}");

                    var data = await _repository.existsAsync(x => x.FirstName.Trim() == model.FirstName.Trim() && x.LastName.Trim() == model.LastName.Trim() && x.Id != model.Id);

                    if (data) return Conflict("Already exists");

                    _repository.update(model);

                    if (await _repository.SaveChangesAsync()) return Ok();
                    else return StatusCode(204, "No data was modified");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get items: {ex}");
                return StatusCode(500, "Something went wrong");
            }

            return BadRequest("The requested action cannot be executed.");
        }
    }
}
