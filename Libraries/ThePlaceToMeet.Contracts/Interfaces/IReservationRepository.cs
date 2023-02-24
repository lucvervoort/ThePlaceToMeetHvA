using ThePlaceToMeet.Contracts.DTO;

namespace ThePlaceToMeet.Contracts.Interfaces
{
    public interface IReservationRepository
    {
        #region Synchronous
        IEnumerable<Reservation> GetAll();
        Reservation? GetById(int id);
        void Add(Reservation reservation);
        void SaveChanges();
        #endregion

        #region Async
        Task<List<Reservation>> GetAllAsync();
        Task<Reservation?> GetByIdAsync(int id);
        #endregion
    }
}
