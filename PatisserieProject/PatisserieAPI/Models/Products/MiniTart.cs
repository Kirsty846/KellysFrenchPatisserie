using EnsureThat;

namespace PatisserieAPI.Model
{
    public class MiniTart : Product
    {
        private MiniTart()
        {

        }
        public MiniTart(Guid id,
            string name,
            string description,
            double price,
            string type): base(id, name, description, price)
        {
            SetType(type);
        }
        public string Type { get; set; } = null!;

        private void SetType(string type)
        {
            EnsureArg.IsNotNullOrEmpty(type, nameof(type));
            Type = type;
        }
    }
}
