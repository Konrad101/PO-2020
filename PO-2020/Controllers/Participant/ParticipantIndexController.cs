using Microsoft.AspNetCore.Mvc;

namespace PO_implementacja_StudiaPodyplomowe.Controllers.Participant
{
    public class ParticipantIndexController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
