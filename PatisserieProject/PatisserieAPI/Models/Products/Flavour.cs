namespace PatisserieAPI.Model
{
    public class Flavour
    {
        public Flavour(string id,
            string name)
        {
            if(string.IsNullOrEmpty(id) || string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("Flavour ID or Name is invalid");
            }

            Id = id;
            Name = name;
        }
        public string Id { get; private set; }
        public string Name { get; private set; }
    }
}
