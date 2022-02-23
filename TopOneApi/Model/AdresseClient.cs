using System;
using System.Collections.Generic;

#nullable disable

namespace TopOneApi.Model
{
    public partial class AdresseClient
    {
        public int Id { get; set; }
        public string Idclient { get; set; }
        public string Adresse { get; set; }
        public string Idville { get; set; }
        public string CodePostal { get; set; }
        public string TelGsm { get; set; }
        public string TelFix { get; set; }
        public string Type { get; set; }
    }
}
