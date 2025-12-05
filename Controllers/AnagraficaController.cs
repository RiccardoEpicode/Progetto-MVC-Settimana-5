using Microsoft.AspNetCore.Mvc;
using PoliziaMunicipale.Services;
using PoliziaMunicipale.Models;

namespace PoliziaMunicipale.Controllers
{
    public class AnagraficaController : Controller
    {
        private readonly IAnagraficaService _service;

        public AnagraficaController(IAnagraficaService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var model = _service.GetAll();
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Anagrafica a)
        {
            if (ModelState.IsValid)
            {
                _service.Add(a);
                return RedirectToAction("Index");
            }
            return View(a);
        }

        public IActionResult Edit(int id)
        {
            var a = _service.Get(id);
            if (a == null) return NotFound();
            return View(a);
        }

        [HttpPost]
        public IActionResult Edit(Anagrafica a)
        {
            if (ModelState.IsValid)
            {
                _service.Update(a);
                return RedirectToAction("Index");
            }
            return View(a);
        }

        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
