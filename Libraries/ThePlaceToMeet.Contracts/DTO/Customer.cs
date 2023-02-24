namespace ThePlaceToMeet.Contracts.DTO
{
    public partial class Customer
    {
        public int Id { get; set; }

        public string Email { get; set; } = null!;

        public string Naam { get; set; } = null!;

        public string Voornaam { get; set; } = null!;

        public string? Gsm { get; set; }

        public string? Bedrijf { get; set; }

        public virtual ICollection<Reservation> Reservaties { get; } = new List<Reservation>();

        #region Constructors and methods
        public Customer()
        {
            //ReservationIds = new List<int>();
            Reservaties = new List<Reservation>();
        }

        public void VoegReservatieToe(Reservation reservation)
        {
            if (Reservaties != null && !Reservaties.Contains(reservation))
            {
                Reservaties.Add(reservation);
            }
        }
        #endregion
    }
}
