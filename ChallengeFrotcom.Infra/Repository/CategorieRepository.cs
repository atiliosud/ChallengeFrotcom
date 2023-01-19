using ChallengeFrotcom.Bussines.Interface;
using ChallengeFrotcom.Bussines.Model;
using Microsoft.Extensions.Configuration;

namespace ChallengeFrotcom.Infra.Repository
{
    public class CategorieRepository : BaseRepository<Categorie>, ICategorieRepository
    {
        public CategorieRepository(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
