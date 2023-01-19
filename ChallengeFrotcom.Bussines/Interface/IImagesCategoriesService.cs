using ChallengeFrotcom.Bussines.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeFrotcom.Bussines.Interface
{
    public interface IImagesCategoriesService
    {
        Task Add(ImageModel imageModel);
        Task Delete(Guid imageId, Guid categorieId);
    }
}
