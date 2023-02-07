namespace ThePlaceToMeet.Contracts.DTO
{
    public class Customer
    {
        #region Properties
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public string? Mobile { get; set; }
        public string? Company { get; set; }
        //public List<int> ReservationIds { get; set; }
        public List<Reservation> Reservations { get; private set; }

        private readonly static List<Reservation> _reservations = new();
        #endregion

        #region Constructors and methods
        public Customer()
        {
            //ReservationIds = new List<int>();
            Reservations = new List<Reservation>();
        }

        public void VoegReservatieToe(Reservation reservation)
        {
            Reservations.Add(reservation);
            //ReservationIds.Add(reservatie.Id);
            if (_reservations != null && !_reservations.Contains(reservation))
            {
                _reservations.Add(reservation);
            }
        }
        #endregion
    }
}
