namespace ThePlaceToMeet.Contracts.DTO
{
    // Protected against usage of EF
    public class Catering
    {
        public int Id { get; set; }
        public string? Titel { get; set; }
        public string? Beschrijving { get; set; }
        public decimal PrijsPerPersoon { get; set; }
    }
}
