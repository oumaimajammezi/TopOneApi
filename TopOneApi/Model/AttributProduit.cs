using System;
using System.Collections.Generic;

#nullable disable

namespace TopOneApi.Model
{
    public partial class AttributProduit
    {
        public int Id { get; set; }
        public string Designation { get; set; }
        public int Ordre { get; set; }
        public bool Actif { get; set; }
    }
}
