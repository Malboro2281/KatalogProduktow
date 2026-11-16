using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace KatalogProduktow
{
    public class Produkt : INotifyPropertyChanged
    {
        // dzięki temu interfejsowi lista i panel szczegółów odświeżają się po zmianie właściwości
        public event PropertyChangedEventHandler? PropertyChanged;
        private void Zmiana([CallerMemberName] string? nazwaWlasciwosci = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nazwaWlasciwosci));
        }

        private string nazwa = "";
        public string Nazwa
        {
            get { return nazwa; }
            set { nazwa = value; Zmiana(); }
        }

        private double cena;
        public double Cena
        {
            //jeśli ktoś chce odczytać cenę, zwracamy jej wartość
            get { return cena; }
            // Cena nie może być ujemna, więc jeśli ktoś spróbuje ustawić wartość ujemną, ustawiamy ją na 0
            set
            {
                cena = value < 0 ? 0 : value;
                Zmiana();
                Zmiana(nameof(WartoscMagazynu));
            }
        }

        private int ilosc;
        public int Ilosc
        {
            get { return ilosc; }
            set
            {
                ilosc = value;
                Zmiana();
                Zmiana(nameof(WartoscMagazynu));
            }
        }

        public string Kategoria { get; set; } = "";

        public double WartoscMagazynu => Cena * Ilosc;

        public bool Promocja { get; set; }
        //nadpisujemy domyślną metodę ToString, aby zwracała czytelny opis produktu
        //public override string ToString()
        //{
        //    return $"{Nazwa} ({Kategoria}): {Cena:F2} zł, ilość: {Ilosc}";
        //}
    }
}