using ChallengeFrotcom.Bussines.Interface;
using ChallengeFrotcom.Bussines.Model;
using ChallengeFrotcom.Bussines.Model.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ChallengeFrotcom.Bussines.Service
{
    public class ImagemService : BaseService, IImagemService
    {
        private readonly IImagemRepository _imagemRepository;
        public ImagemService(IImagemRepository imagemRepository,
                                INotification notificador) : base(notificador)
        {
            _imagemRepository = imagemRepository;
        }

        public async Task Add()
        {
            var imagem = new Imagem();
            imagem.Id = Guid.NewGuid();
            imagem.Url = generateUrl();
            imagem.Name = imagem.Url;

            await _imagemRepository.Add(imagem);
        }

        private string generateUrl()
        {
            List<string> urlImage = new List<string>();
            urlImage.Add("https://cataas.com/cat");
            urlImage.Add("https://place.dog/300/200");
            urlImage.Add("http://shibe.online/api/shibes");

            Random randNum = new Random();
            int aRandomPos = randNum.Next(urlImage.Count);//Returns a nonnegative random number less than the specified maximum (firstNames.Count).

            string currUrl = urlImage[aRandomPos];

            if (aRandomPos == 2)
                currUrl.Replace("[", "").Replace("]","").Replace("\"", "");

            return currUrl;
        }

        public async Task<IEnumerable<ImageModel>> GetAllImages()
        {
            return await _imagemRepository.GetAllImages();
        }

        public async Task<IEnumerable<ImageModel>> GetImagesByCategorie(Guid categorieId)
        {
            return await _imagemRepository.GetImagesByCategorie(categorieId);
        }
    }
}
