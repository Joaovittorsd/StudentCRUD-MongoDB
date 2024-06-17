using CRUD_With_MongoDb.Model;
using CRUD_With_MongoDb.Repositories;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace CRUD_With_MongoDb.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentController : ControllerBase
{
    private readonly IStudentRerpository _studentRepository;
    public StudentController(IStudentRerpository studentRerpository)
    {
        _studentRepository = studentRerpository;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Student student)
    {
        if (student == null || !ModelState.IsValid)
        {
            return BadRequest("Invalid student data.");
        }

        var id = await _studentRepository.Create(student);
        return Ok(id.ToString());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(string id)
    {
        if (!ObjectId.TryParse(id, out var objectId))
        {
            return BadRequest("Invalid ID format.");
        }

        var student = await _studentRepository.Get(objectId);
        if (student == null)
        {
            return NotFound();
        }

        return Ok(student);
    }

    [HttpGet("by-name/{name}")]
    public async Task<IActionResult> GetByName(string name)
    {
        var student = await _studentRepository.GetByName(name);
        if (student == null)
        {
            return NotFound();
        }

        return Ok(student);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, [FromBody] Student student)
    {
        if (!ObjectId.TryParse(id, out var objectId))
        {
            return BadRequest("Invalid ID format.");
        }

        if (student == null || !ModelState.IsValid)
        {
            return BadRequest("Invalid student data.");
        }

        var updatedStudent = await _studentRepository.Update(objectId, student);
        if (!updatedStudent)
        {
            return NotFound();
        }

        return Ok(updatedStudent);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        if (!ObjectId.TryParse(id, out var objectId))
        {
            return BadRequest("Invalid ID format.");
        }

        var deletedStudent = await _studentRepository.Delete(objectId);
        if (!deletedStudent)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpGet("fetch")]
    public async Task<IActionResult> GetAll()
    {
        var students = await _studentRepository.GetAll();
        return Ok(students);
    }
}
