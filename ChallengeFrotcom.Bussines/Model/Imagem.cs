using Dapper;

namespace ChallengeFrotcom.Bussines.Model
{
    [Table("Images")]
    public class Imagem : Entity
    {
        [Column("name")]
        public string Name { get; set; }
        [Column("url")]
        public string Url { get; set; }        
    }
}
