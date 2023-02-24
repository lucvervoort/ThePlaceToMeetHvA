namespace ThePlaceToMeet.Contracts.DTO
{
    public partial class Reservation
    {
        public int Id { get; set; }

        public int AantalPersonen { get; set; }

        public DateTime Dag { get; set; }

        public int BeginUur { get; set; }

        public int DuurInUren { get; set; }

        public decimal PrijsPerUur { get; set; }

        public decimal PrijsPerPersoonStandaardCatering { get; set; }

        public decimal PrijsPerPersoonCatering { get; set; }

        public int? CateringId { get; set; }

        public int? KortingId { get; set; }

        public int VergaderruimteId { get; set; }

        public int KlantId { get; set; }

        public virtual Catering? Catering { get; set; }

        public virtual Customer Klant { get; set; } = null!;

        public virtual Discount? Korting { get; set; }

        public virtual MeetingRoom Vergaderruimte { get; set; } = null!;
    }
}
