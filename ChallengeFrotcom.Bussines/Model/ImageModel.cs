using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeFrotcom.Bussines.Model
{    
    public class ImageModel
    {
        public Guid ImageId { get; set; }
        public string NameImage { get; set; }            
        public string Url { get; set; }
    
        public List<CategorieModel> Categories { get; set; }
    }

    public class CategorieModel
    {
        public Guid CategorieId { get; set; }
        public string NameCategorie { get; set; }
    }
    
}
