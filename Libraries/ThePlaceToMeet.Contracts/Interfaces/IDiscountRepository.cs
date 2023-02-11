using ThePlaceToMeet.Contracts.DTO;

namespace ThePlaceToMeet.Contracts.Interfaces
{
    public interface IDiscountRepository
    {
        IEnumerable<Discount> GetAll();
        Discount GetById(int id);
        void Add(Discount klant);
        void SaveChanges();
    }
}
