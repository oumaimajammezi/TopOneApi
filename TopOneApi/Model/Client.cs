using System;
using System.Collections.Generic;

#nullable disable

namespace TopOneApi.Model
{
    public partial class Client
    {
        public string Id { get; set; }
        public string Idparain { get; set; }
        public int? Idgroupe { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Cin { get; set; }
        public string IdpieceCinrecto { get; set; }
        public string IdpieceCinverso { get; set; }
        public string Societe { get; set; }
        public string MatriculeFiscal { get; set; }
        public string TelGsm { get; set; }
        public string TelFixe { get; set; }
        public string Email { get; set; }
        public DateTime? DateNaissance { get; set; }
        public string Adresse { get; set; }
        public string Ville { get; set; }
        public string Pays { get; set; }
        public string CodePostal { get; set; }
        public string Login { get; set; }
        public string MotPasse { get; set; }
        public DateTime? DateInscription { get; set; }
        public DateTime? DerniereVisite { get; set; }
        public string Sexe { get; set; }
        public decimal Sdebit { get; set; }
        public decimal Scredit { get; set; }
        public string Note { get; set; }
        public bool Actif { get; set; }
    }
}
