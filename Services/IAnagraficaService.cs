using PoliziaMunicipale.Models;

namespace PoliziaMunicipale.Services
{
    public interface IAnagraficaService
    {
        List<Anagrafica> GetAll();
        Anagrafica? Get(int id);
        void Add(Anagrafica a);
        void Update(Anagrafica a);
        void Delete(int id);
    }
}
