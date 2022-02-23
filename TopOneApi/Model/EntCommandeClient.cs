using System;
using System.Collections.Generic;

#nullable disable

namespace TopOneApi.Model
{
    public partial class EntCommandeClient
    {
        public string NumPiece { get; set; }
        public DateTime? DatPiece { get; set; }
        public string TypPiece { get; set; }
        public string Idclient { get; set; }
        public int IdadresseLivraiconClient { get; set; }
        public int IdadresseFacturationClient { get; set; }
        public string Depot { get; set; }
        public int DelaiLiv { get; set; }
        public decimal TmntHt { get; set; }
        public decimal TmntTva { get; set; }
        public decimal Tremise { get; set; }
        public decimal TmntTtc { get; set; }
        public bool Payement { get; set; }
        public int EtatPiece { get; set; }
        public string IdpieceJointe { get; set; }
        public string EtatMail { get; set; }
        public string Idfacture { get; set; }
        public string Idbl { get; set; }
        public DateTime? DateCreation { get; set; }
        public string UserCreation { get; set; }
        public DateTime? DateSystem { get; set; }
    }
}
