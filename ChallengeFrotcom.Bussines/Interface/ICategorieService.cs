using ChallengeFrotcom.Bussines.Model;

namespace ChallengeFrotcom.Bussines.Interface
{
    public interface ICategorieService
    {
        Task Add(Categorie categorie);
        Task<IEnumerable<Categorie>> GetAll();
    }
}
