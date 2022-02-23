using System;
using System.Collections.Generic;

#nullable disable

namespace TopOneApi.Model
{
    public partial class Ville
    {
        public string Id { get; set; }
        public string DesVille { get; set; }
        public string Cp { get; set; }
        public string Idgouv { get; set; }
        public int Ordre { get; set; }
        public bool Actif { get; set; }
    }
}
