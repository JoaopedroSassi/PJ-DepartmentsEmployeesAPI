using Microsoft.AspNetCore.Mvc;

namespace DepartmentsCompanies.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
