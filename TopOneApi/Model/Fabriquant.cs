using System;
using System.Collections.Generic;

#nullable disable

namespace TopOneApi.Model
{
    public partial class Fabriquant
    {
        public decimal Id { get; set; }
        public string Nom { get; set; }
        public string Resume { get; set; }
        public string Description { get; set; }
        public byte[] Logo { get; set; }
        public bool Actif { get; set; }
    }
}
