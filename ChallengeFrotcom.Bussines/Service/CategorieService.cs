using ChallengeFrotcom.Bussines.Interface;
using ChallengeFrotcom.Bussines.Model;
using ChallengeFrotcom.Bussines.Model.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeFrotcom.Bussines.Service
{
    public class CategorieService : BaseService,ICategorieService
    {
        private readonly ICategorieRepository _categorieRepository;

        public CategorieService(ICategorieRepository categorieRepository,
                                INotification notificador) : base(notificador)
        {
            _categorieRepository = categorieRepository;
        }

        public async Task Add(Categorie categorie)
        {
            if (!RunValidation(new CategorieValidation(), categorie)) return;

            categorie.Id = Guid.NewGuid();

            await _categorieRepository.Add(categorie);
        }

        public async Task<IEnumerable<Categorie>> GetAll()
        {
            return await _categorieRepository.GetAll();
        }
    }
}
