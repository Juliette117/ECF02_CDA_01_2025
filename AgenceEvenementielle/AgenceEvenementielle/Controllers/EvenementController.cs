using AgenceEvenementielle.Data;
using AgenceEvenementielle.Models;
using Microsoft.AspNetCore.Mvc;

namespace AgenceEvenementielle.Controllers
{
    public class EvenementController : Controller
    {
        private readonly EvenementContext _context;

        public EvenementController(EvenementContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Evenement> evenements = _context.Evenements.OrderBy(evenement => evenement.Id).ToList();
            return View(evenements);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }
    }
}
