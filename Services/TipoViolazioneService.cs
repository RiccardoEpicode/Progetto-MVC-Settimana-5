using Microsoft.EntityFrameworkCore;
using PoliziaMunicipale.Data;
using PoliziaMunicipale.Models;

namespace PoliziaMunicipale.Services
{
    public class TipoViolazioneService : ITipoViolazioneService
    {
        private readonly AppDbContext _db;

        public TipoViolazioneService(AppDbContext db) => _db = db;

        public List<TipoViolazione> GetAll() => _db.TipiViolazione.ToList();

        public TipoViolazione? Get(int id) => _db.TipiViolazione.Find(id);

        public void Add(TipoViolazione t)
        {
            _db.TipiViolazione.Add(t);
            _db.SaveChanges();
        }

        public void Update(TipoViolazione t)
        {
            _db.TipiViolazione.Update(t);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var t = _db.TipiViolazione.Find(id);
            if (t != null)
            {
                _db.TipiViolazione.Remove(t);
                _db.SaveChanges();
            }
        }
    }
}
