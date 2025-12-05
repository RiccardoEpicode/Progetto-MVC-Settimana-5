using Microsoft.EntityFrameworkCore;
using PoliziaMunicipale.Data;
using PoliziaMunicipale.Models;

namespace PoliziaMunicipale.Services
{
    public class VerbaleService : IVerbaleService
    {
        private readonly AppDbContext _db;

        public VerbaleService(AppDbContext db) => _db = db;

        public List<Verbale> GetAll() =>
            _db.Verbali
               .Include(v => v.Anagrafica)
               .Include(v => v.TipoViolazione)
               .ToList();

        public Verbale? Get(int id) =>
            _db.Verbali
               .Include(v => v.Anagrafica)
               .Include(v => v.TipoViolazione)
               .FirstOrDefault(v => v.IdVerbale == id);

        public void Add(Verbale v)
        {
            _db.Verbali.Add(v);
            _db.SaveChanges();
        }
    }
}
