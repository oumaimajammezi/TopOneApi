using System;
using System.Collections.Generic;

#nullable disable

namespace TopOneApi.Model
{
    public partial class MarqueProduit
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string AffichagePrix { get; set; }
        public string AfficherPrix { get; set; }
        public decimal Remise { get; set; }
        public int Ordre { get; set; }
        public bool Actif { get; set; }
    }
}
