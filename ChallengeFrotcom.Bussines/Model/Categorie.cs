using Dapper;

namespace ChallengeFrotcom.Bussines.Model
{
    [Table("Categories")]
    public class Categorie : Entity
    {
        [Column("name")]
        public string Name { get; set; }        
    }
}
