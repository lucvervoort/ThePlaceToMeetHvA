using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ThePlaceToMeet.Filters;
using ThePlaceToMeet.Domain;
using ThePlaceToMeet.Contracts.Interfaces;
using AutoMapper;

namespace ThePlaceToMeet.Controllers
{
    public class ReservatieController : Controller
    {
        private readonly IMeetingRoomRepository _vergaderruimteRepository;
        private readonly ICateringRepository _cateringRepository;
        private readonly IDiscountRepository _kortingRepository;
        private readonly IMapper _mapper;

        public ReservatieController(IMeetingRoomRepository vergaderruimteRepository, ICateringRepository cateringRepository, IDiscountRepository kortingRepository, IMapper mapper)
        {
            _mapper = mapper;
            _vergaderruimteRepository = vergaderruimteRepository;
            _cateringRepository = cateringRepository;
            _kortingRepository = kortingRepository;
        }

        public IActionResult Index(int? aantalPersonen)
        {
            // implementeer
            List<MeetingRoom> ruimtes = new();
            if (aantalPersonen.HasValue)
            {
                var dtoRuimtes = _vergaderruimteRepository.GetByMaxAantalPersonen(aantalPersonen.Value);
                _mapper.Map(dtoRuimtes, ruimtes);
            }
            else
            {
                var dtoRuimtes = _vergaderruimteRepository.GetAll();
                _mapper.Map(dtoRuimtes, ruimtes);
            }
            ViewData["aantalPersonen"] = aantalPersonen;
            return View(ruimtes.OrderBy(v => v.VergaderruimteType).ThenBy(v => v.MaximumAantalPersonen));
        }

        [Authorize(Policy = "Klant")]
        public IActionResult Reserveer(int id)
        {
            MeetingRoom ruimte = new();
            var dtoRuimte = _vergaderruimteRepository.GetById(id);
            _mapper.Map(dtoRuimte, ruimte);
            if (ruimte == null)
                return NotFound();
            ViewData["catering"] = new SelectList(_cateringRepository.GetAll().OrderBy(c => c.Titel), nameof(Catering.Id), nameof(Catering.Titel));
            return View(new ReservatieViewModel(ruimte));
        }

        [HttpPost]
        [Authorize(Policy = "Klant")]
        [ServiceFilter(typeof(KlantFilter))]
        public IActionResult Reserveer(int id, ReservatieViewModel viewmodel, Customer klant)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Catering catering = new();
                    var dtoCatering = viewmodel.CateringId != 0 ? _cateringRepository.GetBy(viewmodel.CateringId) : null;
                    _mapper.Map(dtoCatering, catering);
                    MeetingRoom ruimte = new();
                    var dtoVergaderruimte = _vergaderruimteRepository.GetById(id);
                    _mapper.Map(dtoVergaderruimte, ruimte);
                    var dtoKortingen = _kortingRepository.GetAll();
                    List<Discount> kortingen = new();
                    _mapper.Map(dtoKortingen, kortingen);
                    Reservation reservatie = ruimte.Reserveer(klant, kortingen, viewmodel.Dag, viewmodel.BeginUur, viewmodel.Duur, viewmodel.AantalPersonen, catering, viewmodel.StandaardCatering);
                    _vergaderruimteRepository.SaveChanges();
                    TempData["message"] = $"Je reservatie voor {ruimte.Naam} op {reservatie.Dag.ToShortDateString()} werd geregistreerd...";
                }
                catch (Exception ex)
                {
                    TempData["error"] = $"Sorry, er is iets mis gegaan, we konden de vergaderruimte niet reserveren ({ex.Message})...";
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["catering"] = new SelectList(_cateringRepository.GetAll().OrderBy(c => c.Titel), nameof(Catering.Id), nameof(Catering.Titel));
            return View(viewmodel);
        }
    }
}