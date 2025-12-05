using Microsoft.AspNetCore.Mvc;
using PoliziaMunicipale.Services;
using PoliziaMunicipale.Models;

namespace PoliziaMunicipale.Controllers
{
    public class TipoViolazioneController : Controller
    {
        private readonly ITipoViolazioneService _service;

        public TipoViolazioneController(ITipoViolazioneService service)
        {
            _service = service;
        }

        public IActionResult Index() =>
            View(_service.GetAll());

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(TipoViolazione t)
        {
            if (ModelState.IsValid)
            {
                _service.Add(t);
                return RedirectToAction("Index");
            }
            return View(t);
        }

        public IActionResult Edit(int id)
        {
            var t = _service.Get(id);
            if (t == null) return NotFound();
            return View(t);
        }

        [HttpPost]
        public IActionResult Edit(TipoViolazione t)
        {
            if (ModelState.IsValid)
            {
                _service.Update(t);
                return RedirectToAction("Index");
            }
            return View(t);
        }

        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
