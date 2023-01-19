namespace ChallengeFrotcom.Api.ViewModel
{
    public class ImageViewModel
    {
        public Guid ImageId { get; set; }
        public string? NameImage { get; set; }
        public string? Url { get; set; }

        public List<CategorieImagemViewModel> Categories { get; set; }
    }

    public class CategorieImagemViewModel
    {
        public Guid CategorieId { get; set; }
        public string? NameCategorie { get; set; }
    }
}
