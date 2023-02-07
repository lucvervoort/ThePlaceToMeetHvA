using AutoMapper;

namespace ThePlaceToMeet.Web.App.AutoMapper
{
    public class KortingProfile : Profile
    {
        public KortingProfile()
        {
            CreateMap<Domain.Discount, Contracts.DTO.Discount>();
            CreateMap<Contracts.DTO.Discount, Domain.Discount>();
        }
    }
}

// Microsoft.EntityFrameworkCore.Design must be added to Web.App
// dotnet ef database update --startup-project ThePlaceToMeet.Web.App