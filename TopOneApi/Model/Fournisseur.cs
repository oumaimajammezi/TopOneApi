using System;
using System.Collections.Generic;

#nullable disable

namespace TopOneApi.Model
{
    public partial class Fournisseur
    {
        public int Id { get; set; }
        public string RaisonSocial { get; set; }
        public string Tel { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Adresse { get; set; }
        public bool Assujiti { get; set; }
        public bool Exonore { get; set; }
        public bool Timbre { get; set; }
        public bool Fodec { get; set; }
        public int CodeTva { get; set; }
        public decimal SoldeDebit { get; set; }
        public decimal SoldeCredit { get; set; }
        public int DelaiReg { get; set; }
        public bool Suspension { get; set; }
        public string AttestationSuspention { get; set; }
        public bool Actif { get; set; }
    }
}
