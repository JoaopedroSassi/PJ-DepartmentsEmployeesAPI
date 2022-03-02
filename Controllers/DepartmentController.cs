using Microsoft.AspNetCore.Mvc;

namespace DepartmentsCompanies.Controllers
{
    public class DepartmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
