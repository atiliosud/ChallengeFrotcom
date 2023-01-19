using ChallengeFrotcom.Bussines.Interface;
using ChallengeFrotcom.Bussines.Model;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace ChallengeFrotcom.Infra.Repository
{
    public class ImagemRepository : BaseRepository<Imagem>, IImagemRepository
    {
        public ImagemRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<IEnumerable<ImageModel>> GetAllImages()
        {
            using (var connection = CreateConnection())
            {
                var sql = $"SELECT I.id as ImageId, I.name as NameImage, I.url, C.id as CategorieId, c.name as NameCategorie " +
                    "FROM dbo.Images I " +
                    "LEFT JOIN dbo.ImagesCategories Ic ON Ic.imagem_id = I.id " +
                    "LEFT JOIN dbo.Categories C ON C.id = Ic.categorie_id ";

                var images = await connection.QueryAsync<ImageModel, CategorieModel, ImageModel>(sql,
                    (image, categorie) => {
                        if (image.Categories == null)
                            image.Categories = new List<CategorieModel>();
                        image.Categories.Add(categorie);
                        return image;
                    }, splitOn: "CategorieId");

                var result = images.GroupBy(p => p.ImageId).Select(g =>
                {
                    var image = g.First();
                    image.Categories = g.Select(p => p.Categories.Single()).ToList();
                    return image;
                });

                return result;

            }
        }

        public async Task<IEnumerable<ImageModel>> GetImagesByCategorie(Guid categorieId)
        {
            using (var connection = CreateConnection())
            {
                var sql = $"SELECT I.id as ImageId, I.name as NameImage, I.url, C.id as CategorieId, c.name as NameCategorie " +
                    "FROM dbo.Images I " +
                    "INNER JOIN dbo.ImagesCategories Ic ON Ic.imagem_id = I.id " +
                    "INNER JOIN dbo.Categories C ON C.id = Ic.categorie_id " +
                    "WHERE c.id = @categorieId ";

                var queryParameters = new
                {
                    categorieId = categorieId
                };

                var images = await connection.QueryAsync<ImageModel, CategorieModel, ImageModel>(sql,
                    (image, categorie) => {
                        if (image.Categories == null)
                            image.Categories = new List<CategorieModel>();
                        image.Categories.Add(categorie);
                        return image;
                    }, param : queryParameters, splitOn: "CategorieId");

                var result = images.GroupBy(p => p.ImageId).Select(g =>
                {
                    var image = g.First();
                    image.Categories = g.Select(p => p.Categories.Single()).ToList();
                    return image;
                });

                return result;

            }
        }
    }
}
