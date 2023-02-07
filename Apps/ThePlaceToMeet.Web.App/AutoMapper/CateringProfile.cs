using AutoMapper;

namespace ThePlaceToMeet.Web.App.AutoMapper
{
    public class CateringProfile : Profile
    {
        public CateringProfile()
        {
            CreateMap<Domain.Catering, Contracts.DTO.Catering>();
            CreateMap<Contracts.DTO.Catering, Domain.Catering>();
        }
    }
}

// Microsoft.EntityFrameworkCore.Design must be added to Web.App
// dotnet ef database update --startup-project ThePlaceToMeet.Web.App