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

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Department>>> Get()
        {
            return Ok(await _context.Departments.AsNoTracking().ToListAsync());
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Department>> GetById(int id)
        {
            return Ok(await _context.Departments.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id));
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Department>> Post([FromBody] Department model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Departments.Add(model);
            await _context.SaveChangesAsync();
            return Ok(model);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<Department>> Put([FromBody] Department model, int id)
        {
            if (model.Id != id)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                _context.Departments.Update(model);
                await _context.SaveChangesAsync();
                return Ok(model);
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest(new { message = "Unable to update department" });
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<Department>> Delete(int id)
        {
            Department department = await _context.Departments.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            if (department is null)
                return BadRequest(new { message = "The department was not found" });

            try
            {
                _context.Departments.Remove(department);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Department successfully removed ieee" });
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest(new { message = "Unable to delete department" });
            }
        }
    }
}
