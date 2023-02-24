namespace ThePlaceToMeet.Contracts.DTO
{
    public partial class MeetingRoom
    {
        public int Id { get; set; }

        public string? Naam { get; set; }

        public MeetingRoomType VergaderruimteType { get; set; }

        public int MaximumAantalPersonen { get; set; }

        public decimal PrijsPerUur { get; set; }

        public decimal PrijsPerPersoonStandaardCatering { get; set; }

        public virtual ICollection<Reservation> Reservaties { get; } = new List<Reservation>();
    }
}
