using EnsureThat;
using PatisserieAPI.Models.Products.Commands;

namespace PatisserieAPI.Model
{
    public class MiniTart : Product
    {
        private MiniTart()
        {

        }
        internal MiniTart(Guid id,
            string name,
            string description,
            double price,
            string type): base(id, name, description, price)
        {
            SetType(type);
        }
        public string Type { get; set; } = null!;

        //public static MiniTart Apply(AddMiniTarts command)
        //{
        //    EnsureArg.IsNotNull(command, nameof(command));

        //    return new (command.Product.Id!, command.Product.Name, command.Product.Description, command.Product.Price, command.Product.Type);

        //}
        //public MiniTart Apply(EditMiniTarts command)
        //{
        //    EnsureArg.IsNotNull(command, nameof(command));
        //    SetName(command.Product.Name);
        //    SetDescription(command.Product.Description);
        //    SetPrice(command.Product.Price);
        //    SetType(command.Product.Type);

        //    return this;

        //}
        private void SetType(string type)
        {
            EnsureArg.IsNotNull(type, nameof(type));
            Type = type;
        }
    }
}
