using PoliziaMunicipale.Models;

namespace PoliziaMunicipale.Services
{
    public interface IVerbaleService
    {
        List<Verbale> GetAll();
        Verbale? Get(int id);
        void Add(Verbale v);
    }
}
