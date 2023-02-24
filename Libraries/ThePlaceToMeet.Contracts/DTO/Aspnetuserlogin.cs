namespace ThePlaceToMeet.Contracts.DTO
{
    public partial class Aspnetuserlogin
    {
        public string LoginProvider { get; set; } = null!;

        public string ProviderKey { get; set; } = null!;

        public string? ProviderDisplayName { get; set; }

        public string UserId { get; set; } = null!;
    }

}