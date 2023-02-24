namespace ThePlaceToMeet.Contracts.DTO
{

    public partial class Aspnetuserclaim
    {
        public int Id { get; set; }

        public string UserId { get; set; } = null!;

        public string? ClaimType { get; set; }

        public string? ClaimValue { get; set; }
    }
}