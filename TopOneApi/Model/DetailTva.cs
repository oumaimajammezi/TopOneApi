using System;
using System.Collections.Generic;

#nullable disable

namespace TopOneApi.Model
{
    public partial class DetailTva
    {
        public string NumPiece { get; set; }
        public string TypPiece { get; set; }
        public string CodeTva { get; set; }
        public string DesTva { get; set; }
        public decimal Assiette { get; set; }
        public decimal Montant { get; set; }
    }
}
