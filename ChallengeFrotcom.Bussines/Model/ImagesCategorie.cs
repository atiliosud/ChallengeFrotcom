using Dapper;

namespace ChallengeFrotcom.Bussines.Model
{
    [Table("ImagesCategories")]
    public class ImagesCategorie : Entity
    {
        [Column("imagem_id")]
        public Guid ImagemId { get; set; }
        [Column("categorie_id")]
        public Guid CategorieId { get; set; }
    }
}
