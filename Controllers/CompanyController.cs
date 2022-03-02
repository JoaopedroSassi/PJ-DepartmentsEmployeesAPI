using Microsoft.AspNetCore.Mvc;

namespace DepartmentsCompanies.Controllers
{
    public class CompanyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
