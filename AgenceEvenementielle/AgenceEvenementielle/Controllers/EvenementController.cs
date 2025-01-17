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
            List<Evenement> evenements = _context.Evenements.OrderBy(evenement => evenement.Nom).ToList();
            return View(evenements);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Evenement evenement)
        {
            _context.Evenements.Add(evenement);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(string id)
        {
            Evenement evenement = _context.Evenements.FirstOrDefault(evenement => evenement.Nom.Equals(id));
            if (evenement == null)
            
                return NotFound();
            
            return View(evenement);
            
        }

        [HttpPost]
        public IActionResult Edit(Evenement evenement)
        { 
            Evenement evenementExistant = _context.Evenements.FirstOrDefault(evenement => evenement.Nom.Equals(evenement.Nom));
            if (evenementExistant == null)
            {
                ViewBag.Erreur = "Cet événement n'existe pas";
                return View(evenement);
            }
            evenementExistant.Nom = evenement.Nom;
            evenementExistant.Lieu = evenement.Lieu;
            evenementExistant.Horraire = evenement.Horraire;
            evenementExistant.Date = evenement.Date;
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(string id)
        {
            Evenement evenement = _context.Evenements.FirstOrDefault(evenement => evenement.Nom.Equals(id));
            if (evenement == null)

                return NotFound();

            return View(evenement);
        }

        [HttpPost]
        public IActionResult Delete(Evenement evenement)
        {
            Evenement evenementASuppr = _context.Evenements.FirstOrDefault(evenement => evenement.Nom.Equals(evenement.Nom));
            if (evenementASuppr == null)
            {
                
                return View(evenement);
            }
            _context.Evenements.Remove(evenementASuppr);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Statistique()
        {
            return View();

        }

        public IActionResult Participant()
        {
            return View();

        }


    }
}
