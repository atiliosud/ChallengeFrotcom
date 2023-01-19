using ChallengeFrotcom.Bussines.Model;

namespace ChallengeFrotcom.Bussines.Interface
{
    public interface IImagesCategoriesRepository : IBaseRepository<ImagesCategorie>
    {
        Task<ImagesCategorie> GetImageCategoria(Guid imageId, Guid categorieId);
    }
}
