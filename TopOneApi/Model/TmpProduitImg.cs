using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TopOneApi.Model
{
    public class TmpProduitImg
    {
        public string Id { get; set; }
        public string Designation { get; set; }
        public string Reference { get; set; }
        public bool Actif { get; set; }
        public int Visibilite { get; set; }
        public bool DisponibiliteALaVente { get; set; }

        public decimal QteStk { get; set; }
        public bool AfficherPrix { get; set; }
        public bool ExclusiveWeb { get; set; }
        public int Etat { get; set; }
        public string Resume { get; set; }
        public string Description { get; set; }
        public string MotsCles { get; set; }
        public decimal PrixAchatHt { get; set; }
        public int CodeTva { get; set; }
        public string DesTva { get; set; }
        public decimal Marge { get; set; }
        public decimal PrixVenteHt { get; set; }
        public decimal PrixVenteTtc { get; set; }
        public bool AfficherBandoPromo { get; set; }
        public int Marque { get; set; }
        public int Categorie { get; set; }
        public int Fabriquant { get; set; }
        public string Acessoire { get; set; }
        public decimal LargeurDuColis { get; set; }
        public decimal HauteurColis { get; set; }
        public decimal ProfondeurColis { get; set; }
        public decimal PoidsColis { get; set; }
        public decimal FraisPortSupplimentaire { get; set; }
        public int Transporteur { get; set; }
        public int Declinaison { get; set; }
        public bool GestionStockAvance { get; set; }
        public bool StockEntrepot { get; set; }
        public bool StockManuel { get; set; }
        public bool RuptureAnnulerCommande { get; set; }
        public bool RuptureAccepteCommande { get; set; }
        public bool RuptureDefaut { get; set; }
        public string CaracteristiqueHauteur { get; set; }
        public string CaracteristiqueLargeur { get; set; }
        public string CaracteristiqueProfondeur { get; set; }
        public string CaracteristiquePoids { get; set; }
        public int CaracteristiqueIdcomposition { get; set; }
        public int CaracteristiqueIdstyle { get; set; }
        public int CaracteristiqueIdpropriete { get; set; }
      //  public string Categorie { get; set; }
         
        public List<ImageProduit> ImgProd { get; set; }

    }
}
