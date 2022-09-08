namespace PatisserieAPI.Model
{
    public class Macaroon : Product
    {
        public double Size { get; set; }
        public string FlavourId { get; set; } = null!;
        public Flavour Flavour { get; set; } = null!;
    }
}
