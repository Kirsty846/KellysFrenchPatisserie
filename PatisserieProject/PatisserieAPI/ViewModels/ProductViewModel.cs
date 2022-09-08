namespace PatisserieAPI.ViewModels
{
    public record ProductViewModel
    {
        public Guid? Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public double Price { get; set; }
    }
}
