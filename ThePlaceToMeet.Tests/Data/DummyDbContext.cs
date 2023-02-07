using System;
using System.Collections.Generic;
using System.Linq;
using ThePlaceToMeet.Domain;

namespace ThePlaceToMeet.Tests.Data
{
    public class DummyDbContext
    {
        public ICollection<MeetingRoom> Vergaderruimtes { get; }
        public IEnumerable<MeetingRoom> Vergaderruimtes20 => Vergaderruimtes.Where(v => v.MaximumAantalPersonen >= 20);
        public IEnumerable<Catering> Caterings { get; }
        public IEnumerable<Discount> Kortingen { get; }
        public Customer Peter { get; } // een klant met 2 reservaties
        public Customer Jan { get; } // een klant met 4 reservaties
        public Customer Piet { get; } // een klant zonder reservaties
        public MeetingRoom Vergaderruimte { get; } // een vergaderruimte met 6 reservaties
        public Catering CateringSushi { get; }
        public DateTime Dag { get; } // 01/08 van volgend jaar

        public DummyDbContext()
        {
            Vergaderruimtes = new List<MeetingRoom>();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 1; j < 4; j++)
                {
                    MeetingRoom r = new MeetingRoom() { Id = (i * 3) + j, Naam = $"{((MeetingRoomType)i).ToString() } {j * 10} personen", MaximumAantalPersonen = j * 10, PrijsPerPersoonStandaardCatering = 10, PrijsPerUur = (15 + i) * j, VergaderruimteType = (MeetingRoomType)i };
                    Vergaderruimtes.Add(r);
                }
            }

            Catering cateringSalad = new Catering() { Id = 1, Titel = "Salad in a jar", Beschrijving = "Salad in a jar", PrijsPerPersoon = 11 };
            Catering cateringBroodjes = new Catering() { Id = 2, Titel = "Broodjes", Beschrijving = "Broodjes", PrijsPerPersoon = 8 };
            CateringSushi = new Catering() { Id = 3, Titel = "Sushi - Sashimi", Beschrijving = "Sushi - Sashimi", PrijsPerPersoon = 12 };
            Caterings = new List<Catering> { cateringSalad, cateringBroodjes, CateringSushi };

            Discount korting1 = new Discount() { MinimumAantalReservatiesInJaar = 3, Percentage = 5 };
            Discount korting2 = new Discount() { MinimumAantalReservatiesInJaar = 5, Percentage = 10 };
            Kortingen = new List<Discount> { korting1, korting2 };

            Peter = new Customer() { Naam = "Claeyssens", Voornaam = "Peter", Email = "peter@hogent.be", Bedrijf = "HoGent" };
            Jan = new Customer() { Naam = "Peeters", Voornaam = "Jan", Email = "jan@gmail.com", Bedrijf = "HoGent" };
            Piet = new Customer() { Naam = "Pieters", Voornaam = "Piet", Email = "piet@gmail.com", Bedrijf = "HoGent" };

            Dag = new DateTime(DateTime.Now.Year + 1, 8, 1);
            Vergaderruimte = Vergaderruimtes.First();
            Reservation res = new Reservation() { Dag = Dag.AddDays(8), BeginUur = 8, DuurInUren = 5, AantalPersonen = 10, Catering = cateringBroodjes, PrijsPerPersoonCatering = 10, PrijsPerUur = 10 };
            Peter.VoegReservatieToe(res);
            Vergaderruimte.Reservaties.Add(res);
            res = new Reservation() { Dag = Dag, BeginUur = 14, DuurInUren = 4, AantalPersonen = 10, PrijsPerPersoonCatering = 10, PrijsPerUur = 10 };
            Peter.VoegReservatieToe(res);
            Vergaderruimte.Reservaties.Add(res);
            res = new Reservation() { Dag = Dag, BeginUur = 9, DuurInUren = 3, AantalPersonen = 10, PrijsPerPersoonCatering = 12, PrijsPerUur = 10 };
            Jan.VoegReservatieToe(res);
            Vergaderruimte.Reservaties.Add(res);
            res = new Reservation() { Dag = Dag.AddDays(1), BeginUur = 9, DuurInUren = 3, AantalPersonen = 10, PrijsPerPersoonCatering = 12, PrijsPerUur = 10 };
            Jan.VoegReservatieToe(res);
            Vergaderruimte.Reservaties.Add(res);
            res = new Reservation() { Dag = Dag.AddDays(2), BeginUur = 9, DuurInUren = 3, AantalPersonen = 10, PrijsPerPersoonCatering = 12, PrijsPerUur = 10 };
            Jan.VoegReservatieToe(res);
            Vergaderruimte.Reservaties.Add(res);
            res = new Reservation() { Dag = Dag.AddDays(3), BeginUur = 9, DuurInUren = 3, AantalPersonen = 10, PrijsPerPersoonCatering = 12, PrijsPerUur = 10 };
            Jan.VoegReservatieToe(res);
            Vergaderruimte.Reservaties.Add(res);
        }
    }
}
