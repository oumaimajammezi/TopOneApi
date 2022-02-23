using System;
using System.Collections.Generic;

#nullable disable

namespace TopOneApi.Model
{
    public partial class Gouvernorat
    {
        public string Id { get; set; }
        public string DesGouv { get; set; }
        public string Idpays { get; set; }
        public int Ordre { get; set; }
        public bool Actif { get; set; }
    }
}
