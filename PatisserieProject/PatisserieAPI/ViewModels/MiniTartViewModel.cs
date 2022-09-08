namespace PatisserieAPI.ViewModels
{
    public sealed record MiniTartViewModel : ProductViewModel
    {
        public string Type { get; set; } = null!;
    }
}
