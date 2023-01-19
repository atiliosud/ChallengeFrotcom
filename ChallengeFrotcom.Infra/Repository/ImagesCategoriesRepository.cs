using ChallengeFrotcom.Bussines.Interface;
using ChallengeFrotcom.Bussines.Model;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeFrotcom.Infra.Repository
{
    public class ImagesCategoriesRepository : BaseRepository<ImagesCategorie>, IImagesCategoriesRepository
    {
        public ImagesCategoriesRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<ImagesCategorie> GetImageCategoria(Guid imageId, Guid categorieId)
        {
            using (var connection = CreateConnection())
            {
                var sql = $"SELECT * " +
                    "FROM dbo.ImagesCategories Ic " +
                    "WHERE Ic.imagem_id = @imageId " +
                    "AND Ic.categorie_id = @categorieId ";

                var queryParameters = new
                {
                    categorieId = categorieId,
                    imageId = imageId,
                };

                var result = await connection.QueryFirstOrDefaultAsync<ImagesCategorie>(sql, queryParameters);

                return result;

            }
        }
    }
}
