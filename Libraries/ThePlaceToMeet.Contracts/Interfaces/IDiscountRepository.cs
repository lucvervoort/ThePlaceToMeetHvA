using ThePlaceToMeet.Contracts.DTO;

namespace ThePlaceToMeet.Contracts.Interfaces
{
    public interface IDiscountRepository
    {
        IEnumerable<Discount> GetAll();
    }
}
