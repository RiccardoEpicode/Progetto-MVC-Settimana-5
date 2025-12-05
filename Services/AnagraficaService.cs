using Microsoft.EntityFrameworkCore;
using PoliziaMunicipale.Data;
using PoliziaMunicipale.Models;

namespace PoliziaMunicipale.Services
{
    public class AnagraficaService : IAnagraficaService
    {
        private readonly AppDbContext _db;

        public AnagraficaService(AppDbContext db) => _db = db;

        public List<Anagrafica> GetAll() => _db.Anagrafiche.ToList();

        public Anagrafica? Get(int id) => _db.Anagrafiche.Find(id);

        public void Add(Anagrafica a)
        {
            _db.Anagrafiche.Add(a);
            _db.SaveChanges();
        }

        public void Update(Anagrafica a)
        {
            _db.Anagrafiche.Update(a);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var a = _db.Anagrafiche.Find(id);
            if (a != null)
            {
                _db.Anagrafiche.Remove(a);
                _db.SaveChanges();
            }
        }
    }
}
