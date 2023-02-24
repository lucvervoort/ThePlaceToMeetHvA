namespace ThePlaceToMeet.Contracts.DTO
{
    public partial class Catering
    {
        public int Id { get; set; }

        public string Titel { get; set; } = null!;

        public string Beschrijving { get; set; } = null!;

        public decimal PrijsPerPersoon { get; set; }

        public virtual ICollection<Reservation> Reservaties { get; } = new List<Reservation>();
    }
}
