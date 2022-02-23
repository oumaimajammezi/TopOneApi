using System;
using System.Collections.Generic;

#nullable disable

namespace TopOneApi.Model
{
    public partial class DetCommandeClient
    {
        public string NumPiece { get; set; }
        public string Idproduit { get; set; }
        public DateTime? DatePiece { get; set; }
        public string TypePiece { get; set; }
        public string CodeDepot { get; set; }
        public string Lot { get; set; }
        public string DesignationArticle { get; set; }
        public decimal PrixUarticle { get; set; }
        public decimal MargeArticle { get; set; }
        public decimal Qte { get; set; }
        public decimal QteLivre { get; set; }
        public string CodTva { get; set; }
        public string Tva { get; set; }
        public decimal Remise { get; set; }
        public decimal PrixU { get; set; }
        public decimal MntHt { get; set; }
        public decimal MntTtc { get; set; }
        public int Ordre { get; set; }
    }
}
