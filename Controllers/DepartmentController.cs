using DepartmentsCompanies.Data;
using DepartmentsCompanies.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepartmentsCompanies.Controllers
{
    [ApiController]
    [Route("departments")]
    public class DepartmentController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DepartmentController([FromServices] AppDbContext context)
            => _context = context;

        [Route("")]
        [HttpGet]
        public async Task<ActionResult<List<Department>>> GetAsync()
        {
            return Ok(await _context.Departments.AsNoTracking().ToListAsync());
        }
        
    }
}
