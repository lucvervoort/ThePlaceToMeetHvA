using MeetingRoomService;
using MVVM;
using System.Collections.Generic;

namespace ThePlaceToMeet.Wpf.App.ViewModels
{
    public partial class MeetingRoomViewModel: ViewModelBase // om INotifyPropertyChanged minstens mee te doen
    {
        private int _id;
        private string? _naam;
        private MeetingRoomType _vergaderruimteType;
        private int _maximumAantalPersonen;
        private decimal _prijsPerUur;
        private decimal _prijsPerPersoonStandaardCatering;
        private List<Reservation> _reservaties = new();

        public int Id { get { return _id; } set { if (_id == value) return; _id = value; RaisePropertyChanged(); } }
        public string? Naam { get { return _naam; } set { if (_naam == value) return; _naam = value; RaisePropertyChanged(); } }
        public MeetingRoomType VergaderruimteType { get { return _vergaderruimteType; } set { if (_vergaderruimteType == value) return; _vergaderruimteType = value; RaisePropertyChanged(); } }
        public int MaximumAantalPersonen { get { return _maximumAantalPersonen; } set { if (_maximumAantalPersonen == value) return; _maximumAantalPersonen = value; RaisePropertyChanged(); } }
        public decimal PrijsPerUur { get { return _prijsPerUur; } set { if (_prijsPerUur == value) return; _prijsPerUur = value; RaisePropertyChanged(); } } //prijs voor huur vergaderruimte per uur
        public decimal PrijsPerPersoonStandaardCatering { get { return _prijsPerPersoonStandaardCatering; } set { if (_prijsPerPersoonStandaardCatering == value) return; _prijsPerPersoonStandaardCatering = value; RaisePropertyChanged(); } } //prijs voor de standaardcatering (koffie, thee, water) per persoon
        public List<Reservation> Reservaties { get { return _reservaties; } set { if (_reservaties == value) return; _reservaties = value; RaisePropertyChanged(); } }
    }
}
