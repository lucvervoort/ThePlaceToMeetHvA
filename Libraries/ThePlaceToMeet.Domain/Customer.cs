namespace ThePlaceToMeet.Domain
{
    public class Customer
    {
        #region Properties
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? Naam { get; set; }
        public string? Voornaam { get; set; }
        public string? GSM { get; set; }
        public string? Bedrijf { get; set; }
        //public List<int> ReservatieIds { get; private set; }
        public List<Reservation> Reservaties { get; set; }

        private static readonly List<Reservation> _reservaties = new();
        #endregion

        #region Constructors and methods
        public Customer()
        {
            //ReservatieIds = new List<int>();
            Reservaties = new List<Reservation>();
        }

        public int GetAantalReservaties(int jaar)
        {
            //implementeer
            return Reservaties.Count(r => r.Dag.Year == jaar);
        }

        public void VoegReservatieToe(Reservation reservatie)
        {
            Reservaties.Add(reservatie);
            //ReservatieIds.Add(reservatie.Id);
            if (_reservaties != null && !_reservaties.Contains(reservatie))
            {
                _reservaties.Add(reservatie);
            }
        }
        #endregion
    }
}
