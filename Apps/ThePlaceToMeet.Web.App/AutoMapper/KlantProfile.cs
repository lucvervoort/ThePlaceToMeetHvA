using AutoMapper;

namespace ThePlaceToMeet.Web.App.AutoMapper
{
    public class KlantProfile : Profile
    {
        public KlantProfile()
        {
            // .MaxDepth(2) cannot be used
            CreateMap<Domain.Customer, Contracts.DTO.Customer>().ForMember(dest => dest.Reservaties, act => act.Ignore());
            CreateMap<Contracts.DTO.Customer, Domain.Customer>().ForMember(dest => dest.Reservaties, act => act.Ignore());
        }
    }
}

// Microsoft.EntityFrameworkCore.Design must be added to Web.App
// dotnet ef database update --startup-project ThePlaceToMeet.Web.App