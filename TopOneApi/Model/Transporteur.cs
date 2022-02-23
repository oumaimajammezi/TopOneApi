using System;
using System.Collections.Generic;

#nullable disable

namespace TopOneApi.Model
{
    public partial class Transporteur
    {
        public decimal Id { get; set; }
        public string Nom { get; set; }
        public string Adresse { get; set; }
        public decimal Sdebit { get; set; }
        public decimal Scredit { get; set; }
        public string TelFixe { get; set; }
        public string TelGsm { get; set; }
        public string TelFax { get; set; }
        public int Ordre { get; set; }
        public bool Actif { get; set; }
    }
}
