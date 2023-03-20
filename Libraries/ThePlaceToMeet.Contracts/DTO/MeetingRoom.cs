namespace ThePlaceToMeet.Contracts.DTO
{
    public class MeetingRoom
    {
        #region Properties
        public int Id { get; set; }
        public string? Naam { get; set; }
        public MeetingRoomType VergaderruimteType { get; set; }
        public int MaximumAantalPersonen { get; set; }
        public decimal PrijsPerUur { get; set; } //prijs voor huur vergaderruimte per uur
        public decimal PrijsPerPersoonStandaardCatering { get; set; } //prijs voor de standaardcatering (koffie, thee, water) per persoon
        public List<Reservation> Reservaties { get; private set; }
        #endregion

        #region Constructors and methods
        public MeetingRoom()
        {
            Reservaties = new List<Reservation>();
        }
        #endregion
    }
}
