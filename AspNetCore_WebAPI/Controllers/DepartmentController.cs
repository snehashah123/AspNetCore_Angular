using AspNetCore_WebAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore_WebAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class DepartmentController : ControllerBase
  {
    private readonly IDepartmentRepository _department;

    public DepartmentController(IDepartmentRepository departmentRepository)
    {
      _department = departmentRepository;
    }

    [HttpGet]
    [Route("GetDepartment")]
    public async Task<IActionResult> Get()
    {
      return Ok(await _department.GetDepartments());
    }

    [HttpGet]
    [Route("GetDepartmentByID/{Id}")]
    public async Task<IActionResult> GetDeptById(int Id)
    {
      return Ok(await _department.GetDepartmentByID(Id));
    }

  }
}
