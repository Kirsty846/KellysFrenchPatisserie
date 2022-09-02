namespace PatisserieAPI.Model
{
    public class CelebrationCake : Product
    {
        public int Tiers { get; set; }
        public string FlavourId { get; set; } = null!;
        public Flavour Flavour { get; set; } = null!;
        public string IcingFlavour { get; set; } = null!;
    }
}
