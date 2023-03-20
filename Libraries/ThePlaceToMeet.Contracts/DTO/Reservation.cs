namespace ThePlaceToMeet.Contracts.DTO
{
    public class Reservation
    {
        public int Id { get; set; }
        public int AantalPersonen { get; set; }
        public DateTime Dag { get; set; }
        public int BeginUur { get; set; }
        public int DuurInUren { get; set; }
        public int Tot => BeginUur + DuurInUren;
        public decimal PrijsPerUur { get; set; } //prijs voor huur vergaderruimte per uur op het moment van de reservatie, nog zonder de korting
        public decimal PrijsPerPersoonStandaardCatering { get; set; } //prijs voor de standaardcatering (koffie, thee, water) per persoon op het moment van de reservatie. 0 als geen standaardcatering wordt aangevraagd
        public decimal PrijsPerPersoonCatering { get; set; } //prijs voor de catering per persoon op het moment van de reservatie, indien voorzien, anders 0. 
        public Catering? Catering { get; set; }
        public Discount? Discount { get; set; }
        public MeetingRoom? MeetingRoom { get; set; }
    }
}
