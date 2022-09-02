namespace PatisserieAPI.Model
{
    public abstract class Product
    {

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public double Price { get; set; }

    }
}
