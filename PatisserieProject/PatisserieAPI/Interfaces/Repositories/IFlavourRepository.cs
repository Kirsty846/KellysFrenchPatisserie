using PatisserieAPI.Model;

namespace PatisserieAPI.Interfaces
{
    public interface IFlavourRepository 
    {
        IQueryable<Flavour> GetFlavours();
    }
}
