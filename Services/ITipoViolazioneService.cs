using PoliziaMunicipale.Models;

namespace PoliziaMunicipale.Services
{
    public interface ITipoViolazioneService
    {
        List<TipoViolazione> GetAll();
        TipoViolazione? Get(int id);
        void Add(TipoViolazione t);
        void Update(TipoViolazione t);
        void Delete(int id);
    }
}
