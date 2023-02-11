using ThePlaceToMeet.Contracts.DTO;

namespace ThePlaceToMeet.Contracts.Interfaces
{
    public interface IMeetingRoomRepository
    {
        #region Synchronous
        IEnumerable<MeetingRoom> GetAll();
        IEnumerable<MeetingRoom> GetByMaxAantalPersonen(int maxAantalPersonen);
        MeetingRoom? GetById(int id);
        void Add(MeetingRoom meetingRoom);
        void SaveChanges();
        #endregion

        #region Async
        Task<List<MeetingRoom>> GetAllAsync();
        Task<List<MeetingRoom>> GetByMaxAantalPersonenAsync(int maxAantalPersonen);
        Task<MeetingRoom?> GetByIdAsync(int id);
        #endregion
    }
}
