using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using ThePlaceToMeet.Infrastructure.DTO;

namespace ThePlaceToMeet.Infrastructure
{
    public class ApplicationDataInitializer
    {
        private readonly RepositoryDbContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;

        public ApplicationDataInitializer(RepositoryDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public async Task InitializeData()
        {
            // TODO LVET: make this work without db if EnsureDeleted is commented out
            // First use only:
            // _dbContext.Database.EnsureDeleted();
            if (_dbContext.Database.EnsureCreated())
            {
                await InitializeUsers();
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 1; j < 4; j++)
                    {
                        Contracts.DTO.MeetingRoom r = new () { Naam = $"{((Contracts.DTO.MeetingRoomType)i).ToString()} Room - {j} ", MaximumAantalPersonen = j * 10, PrijsPerPersoonStandaardCatering = 10, PrijsPerUur = (15 + i) * j, VergaderruimteType = (Contracts.DTO.MeetingRoomType)i };
                        _dbContext.Vergaderruimtes.Add(r);
                    }
                }
                _dbContext.SaveChanges();

                Contracts.DTO.Catering cateringSalad = new () { Titel = "Salad in a jar", Beschrijving = "Salad in a jar", PrijsPerPersoon = 10 };
                Contracts.DTO.Catering cateringBroodjes = new () { Titel = "Broodjes", Beschrijving = "Broodjes", PrijsPerPersoon = 8 };
                Contracts.DTO.Catering cateringSushi = new () { Titel = "Sushi - Sashimi", Beschrijving = "Sushi - Sashimi", PrijsPerPersoon = 12 };
                Contracts.DTO.Catering[] caterings =
                new Contracts.DTO.Catering[] { cateringSalad, cateringBroodjes, cateringSushi };
                _dbContext.Caterings.AddRange(caterings);
                _dbContext.SaveChanges();

                Contracts.DTO.Discount korting1 = new () { MinimumReservationsInAYear = 3, Percentage = 5 };
                Contracts.DTO.Discount korting2 = new () { MinimumReservationsInAYear = 10, Percentage = 10 };
                _dbContext.Kortingen.AddRange(new Contracts.DTO.Discount[] { korting1, korting2 });
                _dbContext.SaveChanges();

                Contracts.DTO.Customer peter = new () { LastName = "Claeyssens", FirstName = "Peter", Email = "peter@hogent.be", Company = "HoGent" };
                _dbContext.Klanten.Add(peter);
                Contracts.DTO.Customer jan = new () { LastName = "Peeters", FirstName = "Jan", Email = "jan@gmail.com", Company = "HoGent" };
                _dbContext.Klanten.Add(jan);
                _dbContext.SaveChanges();

                Contracts.DTO.MeetingRoom ruimte = _dbContext.Vergaderruimtes.SingleOrDefault(t => t.Id == 1);
                Contracts.DTO.Reservation res = new () { Dag = DateTime.Today.AddDays(10), BeginUur = 8, DuurInUren = 5, AantalPersonen = 10, Catering = cateringBroodjes, PrijsPerPersoonCatering = 10, PrijsPerUur = 10 };
                peter.Reservations.Add(res);
                ruimte.Reservaties.Add(res);
                res = new Contracts.DTO.Reservation() { Dag = DateTime.Today.AddDays(10), BeginUur = 14, DuurInUren = 4, AantalPersonen = 10, PrijsPerPersoonCatering = 10, PrijsPerUur = 10 };
                peter.Reservations.Add(res);
                ruimte.Reservaties.Add(res);
                res = new Contracts.DTO.Reservation() { Dag = DateTime.Today.AddDays(8), BeginUur = 9, DuurInUren = 4, AantalPersonen = 10, PrijsPerPersoonCatering = 12, PrijsPerUur = 10 };
                jan.Reservations.Add(res);
                ruimte.Reservaties.Add(res);
                _dbContext.SaveChanges();
            }
        }

        private async Task InitializeUsers()
        {
            string eMailAddress = "peter@hogent.be";
            ApplicationUser user = new() { UserName = eMailAddress, Email = eMailAddress };
            await _userManager.CreateAsync(user, "$P@ssword1");
            await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "klant"));

            eMailAddress = "jan@gmail.com";
            user = new () { UserName = eMailAddress, Email = eMailAddress };
            await _userManager.CreateAsync(user, "$P@ssword1");
            await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "klant"));
        }
    }
}

