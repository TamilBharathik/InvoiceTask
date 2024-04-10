using backendtask.Repo;
using Microsoft.AspNetCore.Mvc;
using backendtask.Model;

namespace backendtask.Controllers
{
    [Route("[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly ILogger<DepartmentController> _logger;
    private readonly DepartmentRepository _departmentRepository;

    public DepartmentController(ILogger<DepartmentController> logger, DepartmentRepository departmentRepository)
    {
        _logger = logger;
        _departmentRepository = departmentRepository;
    }

    [HttpPost]
    public IActionResult CreateDepartment([FromBody] Department department)
    {
        try
        {
            _departmentRepository.CreateDepartment(department);
            return Ok("Department created successfully.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating department.");
            return StatusCode(500, "Error creating department.");
        }
    }
    }
}