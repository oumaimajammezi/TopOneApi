using System;
using System.Collections.Generic;

#nullable disable

namespace TopOneApi.Model
{
    public partial class ReductionGroupe
    {
        public int Idgroupe { get; set; }
        public int Idcategorie { get; set; }
        public decimal Remise { get; set; }
        public bool Actif { get; set; }
    }
}
