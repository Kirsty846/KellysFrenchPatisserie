using EnsureThat;

namespace PatisserieAPI.Model
{
    public abstract class Product
    {
        protected Product()
        {

        }

        protected Product(Guid id,
            string name,
            string description,
            double price)
        {
            SetId(id);
            SetName(name);
            SetDescription(description);
            SetPrice(price);
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public double Price { get; set; }

        private void SetId(Guid id)
        {
            EnsureArg.IsNotDefault(id);
            Id = id;
        }

        private void SetName(string name)
        {
            EnsureArg.IsNotNull(name);
            Name = name;
        }
        private void SetDescription(string description)
        {
            EnsureArg.IsNotNull(description);
            Description = description;
        }
        private void SetPrice(double price)
        {
            EnsureArg.IsGt(price, 0);
            Price = price;
        }

    }
}
