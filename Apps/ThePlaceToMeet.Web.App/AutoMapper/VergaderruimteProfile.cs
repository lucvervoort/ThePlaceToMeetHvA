using AutoMapper;

namespace ThePlaceToMeet.Web.App.AutoMapper
{
    public class VergaderruimteProfile : Profile
    {
        public VergaderruimteProfile()
        {
            CreateMap<Domain.MeetingRoom, Contracts.DTO.MeetingRoom>();
            CreateMap<Contracts.DTO.MeetingRoom, Domain.MeetingRoom>();
        }
    }
}

// Microsoft.EntityFrameworkCore.Design must be added to Web.App
// dotnet ef database update --startup-project ThePlaceToMeet.Web.App