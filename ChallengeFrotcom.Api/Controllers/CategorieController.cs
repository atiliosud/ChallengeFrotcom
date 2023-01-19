using AutoMapper;
using ChallengeFrotcom.Api.ViewModel;
using ChallengeFrotcom.Bussines.Interface;
using ChallengeFrotcom.Bussines.Model;
using Microsoft.AspNetCore.Mvc;

namespace ChallengeFrotcom.Api.Controllers
{
    [Route("api/Categorie")]
    public class CategorieController : MainController
    {
        private readonly ICategorieService _categorieService;
        private readonly IMapper _mapper;

        public CategorieController(ICategorieService categorieService,
                                      IMapper mapper,
                                      INotification notification) : base(notification)
        {
            _categorieService = categorieService;
            _mapper = mapper;   
        }

        [HttpPost]
        public async Task<ActionResult<CategorieViewModel>> Add(CategorieViewModel categorieViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _categorieService.Add(_mapper.Map<Categorie>(categorieViewModel));

            return CustomResponse(categorieViewModel);
        }

        [HttpGet]
        public async Task<IEnumerable<CategorieViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<CategorieViewModel>>(await _categorieService.GetAll());
        }
    }
}
