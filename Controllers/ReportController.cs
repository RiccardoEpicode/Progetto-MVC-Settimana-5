using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PoliziaMunicipale.Data;

namespace PoliziaMunicipale.Controllers
{
    public class ReportController : Controller
    {
        private readonly AppDbContext _db;

        public ReportController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult VerbaliPerTrasgressore()
        {
            var result = _db.Verbali
                .Include(v => v.Anagrafica)
                .GroupBy(v => v.Anagrafica)
                .Select(g => new
                {
                    Nome = g.Key.Nome,
                    Cognome = g.Key.Cognome,
                    TotaleVerbali = g.Count()
                })
                .ToList();

            return View(result);
        }

        public IActionResult PuntiPerTrasgressore()
        {
            var result = _db.Verbali
                .Include(v => v.Anagrafica)
                .GroupBy(v => v.Anagrafica)
                .Select(g => new
                {
                    Nome = g.Key.Nome,
                    Cognome = g.Key.Cognome,
                    Punti = g.Sum(v => v.DecurtamentoPunti)
                })
                .ToList();

            return View(result);
        }

        public IActionResult PuntiOltreDieci()
        {
            var result = _db.Verbali
                .Include(v => v.Anagrafica)
                .Where(v => v.DecurtamentoPunti > 10)
                .ToList();

            return View(result);
        }

        public IActionResult ImportoOltre400()
        {
            var result = _db.Verbali
                .Include(v => v.Anagrafica)
                .Where(v => v.Importo > 400)
                .ToList();

            return View(result);
        }
    }
}
