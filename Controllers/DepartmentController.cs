using DepartmentsCompanies.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepartmentsCompanies.Controllers
{
    [ApiController]
    [Route("departments")]
    public class DepartmentController : ControllerBase
    {
        private readonly DataContext _context;
        public DepartmentController([FromServices] DataContext context)
            => _context = context;

        [Route("")]
        [HttpGet]
        public async Task<ActionResult<List<Department>>> GetAsync()
        {
            
        }
        
    }
}
