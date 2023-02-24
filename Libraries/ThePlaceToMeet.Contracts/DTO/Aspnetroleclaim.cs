namespace ThePlaceToMeet.Contracts.DTO
{
    public partial class Aspnetroleclaim
    {
        public int Id { get; set; }

        public string RoleId { get; set; } = null!;

        public string? ClaimType { get; set; }

        public string? ClaimValue { get; set; }
    }
}