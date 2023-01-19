using ChallengeFrotcom.Bussines.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeFrotcom.Bussines.Interface
{
    public interface IImagemService
    {
        Task Add();
        Task<IEnumerable<ImageModel>> GetImagesByCategorie(Guid categorieId);
        Task<IEnumerable<ImageModel>> GetAllImages();
    }
}
