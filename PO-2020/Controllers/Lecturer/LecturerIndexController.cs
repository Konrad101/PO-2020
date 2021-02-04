using Microsoft.AspNetCore.Mvc;

namespace PO_implementacja_StudiaPodyplomowe.Controllers.Lecturer
{
    public class LecturerIndexController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
