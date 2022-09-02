namespace PatisserieAPI.Model
{
    public class Fudge : Product
    {
        public double Size { get; set; }
        public string FlavourId { get; set; } = null!;
        public Flavour Flavour { get; set; } = null!;

    }
}
