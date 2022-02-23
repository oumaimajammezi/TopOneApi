using System;
using System.Collections.Generic;

#nullable disable

namespace TopOneApi.Model
{
    public partial class DeclinaisonProduit
    {
        public string Id { get; set; }
        public string Idproduit { get; set; }
        public int Idattribut { get; set; }
        public int Idvaleur { get; set; }
        public decimal PrixAchat { get; set; }
        public int IdimpactPrixVente { get; set; }
        public decimal PrixDuImpactPrixVente { get; set; }
        public decimal PrixAuImpactPrixVente { get; set; }
        public decimal PrixFinalImpactPrixVente { get; set; }
        public decimal? QuantiteMinimal { get; set; }
        public DateTime DateDisponibilite { get; set; }
        public bool DeclinaisonParDefaut { get; set; }
        public string IdimageDeclinaison { get; set; }
        public decimal QuantiteStock { get; set; }
    }
}
