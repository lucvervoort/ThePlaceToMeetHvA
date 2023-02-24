namespace ThePlaceToMeet.Contracts.DTO
{
    public partial class Discount
    {
        public int Id { get; set; }

        public int Percentage { get; set; }

        public int MinimumAantalReservatiesInJaar { get; set; }

        public virtual ICollection<Reservation> Reservaties { get; } = new List<Reservation>();
    }
}
