using AutoMapper;
using ChallengeFrotcom.Api.ViewModel;
using ChallengeFrotcom.Bussines.Model;

namespace ChallengeFrotcom.Api.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Categorie, CategorieViewModel>().ReverseMap();
            CreateMap<ImageModel, ImageViewModel>().ReverseMap();
            CreateMap<CategorieModel, CategorieImagemViewModel>().ReverseMap();
        }
    }
}
