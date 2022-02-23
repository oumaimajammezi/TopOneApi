using System;
using System.Collections.Generic;

#nullable disable

namespace TopOneApi.Model
{
    public partial class VisibiliteProduit
    {
        public decimal Id { get; set; }
        public string Designation { get; set; }
        public int Ordre { get; set; }
        public bool Actif { get; set; }
    }
}
