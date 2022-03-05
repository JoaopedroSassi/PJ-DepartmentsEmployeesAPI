using DepartmentsCompanies.Data;
using DepartmentsCompanies.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepartmentsCompanies.Controllers
{
    [ApiController]
    [Route("employees")]
    public class EmployeeController : ControllerBase
    {
        private readonly AppDbContext _context;
        public EmployeeController([FromServices] AppDbContext context)
            => _context = context;

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Employee>>> Get()
            => await _context.Employees.AsNoTracking().ToListAsync();  

        [HttpGet]
        [Route("{departmentId:int}")]
        public async Task<ActionResult<List<Employee>>> GetByDepartment(int departmentId)
        {
            Department department = await _context.Departments.AsNoTracking().FirstOrDefaultAsync(x => x.Id == departmentId);

            if (department is null)
                return BadRequest(ModelState);

            return Ok(await _context.Employees.Where(x => x.DepartmentId == departmentId).AsNoTracking().ToListAsync());
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Employee>> Post([FromBody] Employee model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Department department = await _context.Departments.AsNoTracking().FirstOrDefaultAsync(x => x.Id == model.DepartmentId);

            if (department is null)
                return BadRequest(new {message = "Department not found"});

            _context.Employees.Add(model);
            await _context.SaveChangesAsync();
            return Ok(model);
        }

        [HttpPut]
        [Route("")]
        public async Task<ActionResult<Employee>> Put([FromBody] Employee model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                _context.Employees.Update(model);
                await _context.SaveChangesAsync();
                return Ok(model);
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest(new { message = "Unable to update employee" });
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<Employee>> Delete(int id)
        {
            Employee employee = await _context.Employees.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            if (employee is null)
                return BadRequest(new { message = "The employee was not found" });

            try
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Employee successfully removed" });
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest(new { message = "Unable to delete department" });
            }
        }

        
    }
}
