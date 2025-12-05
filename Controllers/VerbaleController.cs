using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PoliziaMunicipale.Services;
using PoliziaMunicipale.Models;

namespace PoliziaMunicipale.Controllers
{
    public class VerbaleController : Controller
    {
        private readonly IVerbaleService _verbaleService;
        private readonly IAnagraficaService _anagraficaService;
        private readonly ITipoViolazioneService _violazioneService;

        public VerbaleController(
            IVerbaleService verbaleService,
            IAnagraficaService anagraficaService,
            ITipoViolazioneService violazioneService)
        {
            _verbaleService = verbaleService;
            _anagraficaService = anagraficaService;
            _violazioneService = violazioneService;
        }

        public IActionResult Index()
        {
            return View(_verbaleService.GetAll());
        }

        public IActionResult Create()
        {
            LoadDropdowns();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Verbale v)
        {
            Console.WriteLine("POST ARRIVATO!");
            Console.WriteLine("MODELSTATE: " + ModelState.IsValid);

            foreach (var error in ModelState)
            {
                foreach (var sub in error.Value.Errors)
                {
                    Console.WriteLine($"❌ {error.Key}: {sub.ErrorMessage}");
                }
            }

            if (ModelState.IsValid)
            {
                _verbaleService.Add(v);
                return RedirectToAction("Index");
            }

            LoadDropdowns();
            return View(v);
        }


        private void LoadDropdowns()
        {
            ViewBag.Anagrafiche = new SelectList(_anagraficaService.GetAll(), "IdAnagrafica", "Cognome");
            ViewBag.TipiViolazione = new SelectList(_violazioneService.GetAll(), "IdViolazione", "Descrizione");
        }
    }
}
