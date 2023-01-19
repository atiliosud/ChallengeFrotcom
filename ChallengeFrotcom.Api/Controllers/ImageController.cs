using AutoMapper;
using ChallengeFrotcom.Api.ViewModel;
using ChallengeFrotcom.Bussines.Interface;
using ChallengeFrotcom.Bussines.Model;
using ChallengeFrotcom.Bussines.Service;
using Microsoft.AspNetCore.Mvc;

namespace ChallengeFrotcom.Api.Controllers
{
    [Route("api/Image")]
    public class ImageController : MainController
    {
        private readonly IImagemService _imagemService;
        private readonly IImagesCategoriesService _imagesCategorieService;
        private readonly IMapper _mapper;

        public ImageController(IImagemService imagemService,
                                  IImagesCategoriesService imagesCategoriesService,
                                  IMapper mapper,
                                  INotification notification) : base(notification)
        {
            _imagemService = imagemService;
            _imagesCategorieService = imagesCategoriesService;
            _mapper = mapper;

        }

        [HttpPost]
        public async Task<ActionResult> Add()
        {            
            await _imagemService.Add();

            return CustomResponse();
        }

        [HttpGet("{categorieId:guid}")]
        public async Task<IEnumerable<ImageViewModel>> GetImagesByCategorie(Guid categorieId)
        {
            return _mapper.Map<IEnumerable<ImageViewModel>>(await _imagemService.GetImagesByCategorie(categorieId));
        }

        [HttpGet("")]
        public async Task<IEnumerable<ImageViewModel>> GetImagesByCategorie()
        {
            return _mapper.Map<IEnumerable<ImageViewModel>>(await _imagemService.GetAllImages());
        }

        [HttpPost]
        [Route("/Categorie")]
        public async Task<ActionResult<ImageViewModel>> AddImagemCategorie(ImageViewModel imageViewModel)
        {
            await _imagesCategorieService.Add(_mapper.Map<ImageModel>(imageViewModel));

            return CustomResponse(imageViewModel);
        }

        [HttpDelete("{imageId:guid}/{categorieId:guid}")]        
        public async Task<ActionResult> DeleteImagemCategorie(Guid imageId, Guid categorieId)
        {
            await _imagesCategorieService.Delete(imageId,categorieId);

            return CustomResponse();
        }
    }
}
