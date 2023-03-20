using ThePlaceToMeet.Contracts.DTO;

namespace ThePlaceToMeet.Contracts.Interfaces
{
    // Abstracts away EF
    public interface ICateringRepository
    {
        IEnumerable<Catering> GetAll();
        Catering GetBy(int id);
    }
}
