namespace PatisserieAPI.ViewModels
{
    public sealed record FudgeViewModel : ProductViewModel
    {
        public double Size { get; set; }
        public string FlavourId { get; set; } = null!;
        public FlavourViewModel? Flavour { get; set; }
    }
}
