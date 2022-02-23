using System;
using System.Collections.Generic;

#nullable disable

namespace TopOneApi.Model
{
    public partial class Depstock
    {
        public string Coddep { get; set; }
        public string Idproduit { get; set; }
        public string Lot { get; set; }
        public decimal Qte { get; set; }
        public decimal Pu { get; set; }
        public decimal Stkdep { get; set; }
        public decimal Stkrel { get; set; }
        public decimal Priinv { get; set; }
        public decimal Qte0 { get; set; }
        public decimal Stkdep0 { get; set; }
        public decimal Stkrel0 { get; set; }
        public string NumPiece { get; set; }
        public string TypPiece { get; set; }
        public DateTime? DatPiece { get; set; }
    }
}
