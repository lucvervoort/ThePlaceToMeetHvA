using AutoMapper;

namespace ThePlaceToMeet.Web.App.AutoMapper
{
    public class ReservatieProfile : Profile
    {
        public ReservatieProfile()
        {
            CreateMap<Domain.Reservation, Contracts.DTO.Reservation>();
            CreateMap<Contracts.DTO.Reservation, Domain.Reservation>();
        }
    }
}

// Microsoft.EntityFrameworkCore.Design must be added to Web.App
// dotnet ef database update --startup-project ThePlaceToMeet.Web.App