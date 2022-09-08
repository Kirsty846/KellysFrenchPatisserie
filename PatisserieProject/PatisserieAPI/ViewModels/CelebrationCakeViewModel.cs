namespace PatisserieAPI.ViewModels
{
    public sealed record CelebrationCakeViewModel : ProductViewModel
    {
        public int Tiers { get; set; }
        public string FlavourId { get; set; } = null!;
        public FlavourViewModel? Flavour { get; set; }
        public string IcingFlavour { get; set; } = null!;
    }
}
