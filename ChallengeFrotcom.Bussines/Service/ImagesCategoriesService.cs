using ChallengeFrotcom.Bussines.Interface;
using ChallengeFrotcom.Bussines.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ChallengeFrotcom.Bussines.Service
{
    public class ImagesCategoriesService : BaseService, IImagesCategoriesService
    {
        private readonly IImagesCategoriesRepository _imagesCategoriesRepository;

        public ImagesCategoriesService(IImagesCategoriesRepository imagesCategoriesRepository,
                                INotification notificador) : base(notificador)
        {
            _imagesCategoriesRepository = imagesCategoriesRepository;
        }

        public async Task Add(ImageModel imageModel)
        {
            foreach (var category in imageModel.Categories)
            {
                var imageCategorie = await _imagesCategoriesRepository.GetImageCategoria(imageModel.ImageId, category.CategorieId);

                if (imageCategorie == null)
                {
                    var imageCategorieModel = new ImagesCategorie();
                    imageCategorieModel.Id = Guid.NewGuid();
                    imageCategorieModel.CategorieId = category.CategorieId;
                    imageCategorieModel.ImagemId = imageModel.ImageId;

                    await _imagesCategoriesRepository.Add(imageCategorieModel);
                }   
            }
        }

        public async Task Delete(Guid imageId, Guid categorieId)
        {
            var imageCategorie = await _imagesCategoriesRepository.GetImageCategoria(imageId, categorieId);

            if (imageCategorie != null)
                await _imagesCategoriesRepository.Delete(imageCategorie.Id);      
        }
    }
}
