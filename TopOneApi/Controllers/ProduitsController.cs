using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TopOneApi.Model;

namespace TopOneApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProduitsController : ControllerBase
    {
        //private readonly TOPONEContext _context;

        //public ProduitsController(TOPONEContext context)
        //{
        //    _context = context;
        //}
        TOPONEContext _context = new TOPONEContext();

        // GET: api/Produits
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produit>>> GetProduits()
        {
            return await _context.Produits.ToListAsync();
        }

        // GET: api/Produits/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Produit>> GetProduit(string id)
        {
            var produit = await _context.Produits.FindAsync(id);

            if (produit == null)
            {
                return NotFound();
            }

            return produit;
        }

        // PUT: api/Produits/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduit(string id, Produit produit)
        {
            if (id != produit.Id)
            {
                return BadRequest();
            }

            _context.Entry(produit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProduitExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        [HttpGet]
        [Route("GetListeProduit")]
        public ActionResult GetListeProduit([FromQuery] PaginationFilter filter)
        {
            try
            {
              //  var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
                //var v = (from Prod in _context.Produits
                //         join Cat in _context.CategorieProduits on Prod.Categorie equals (Cat.Id)
                //         orderby Prod.Id descending 
                //      select new
                //      {
                //          id = Prod.Id,
                //          designation = Prod.Designation,
                //          reference = Prod.Reference,
                //          Categorie = Cat.Designation,
                //          prixBase = Prod.PrixVenteTtc,
                //          prixFinal = Prod.PrixVenteTtc, 
                //          quantite = Prod.QteStk, 
                //          Etat = Prod.Etat,

                //      }).Distinct();

                List<Produit> MyListProd = _context.Produits.Where(x => x.Actif.Equals(true)).Skip((filter.PageNumber - 1) * filter.PageSize)
               .Take(filter.PageSize)
              .ToList();

                List<TmpProduitImg> RetListe = new List<TmpProduitImg>();

                foreach (var obj in MyListProd)
                {
                    TmpProduitImg myTmp = new TmpProduitImg();

                    myTmp.Id = obj.Id;
                    myTmp.Designation = obj.Designation;
                    myTmp.Reference = obj.Reference;
                    myTmp.Actif = obj.Actif;
                    myTmp.Visibilite = obj.Visibilite;
                    myTmp.DisponibiliteALaVente = obj.DisponibiliteALaVente;
                    myTmp.QteStk = obj.QteStk;
                    myTmp.AfficherPrix = obj.AfficherPrix;
                    myTmp.ExclusiveWeb = obj.ExclusiveWeb;
                    myTmp.Etat = obj.Etat;
                    myTmp.Resume = obj.Resume;
                    myTmp.Description = obj.Description;
                    myTmp.MotsCles = obj.MotsCles;
                    myTmp.PrixAchatHt = obj.PrixAchatHt;
                    myTmp.CodeTva = obj.CodeTva;
                    myTmp.DesTva = obj.DesTva;
                    myTmp.Marge = obj.Marge;
                    myTmp.PrixVenteHt = obj.PrixVenteHt;
                    myTmp.PrixVenteTtc = obj.PrixVenteTtc;
                    myTmp.AfficherBandoPromo = obj.AfficherBandoPromo;
                    myTmp.Marque = obj.Marque;
                    myTmp.Categorie = obj.Categorie;
                    myTmp.Fabriquant = obj.Fabriquant;
                    myTmp.Acessoire = obj.Acessoire;
                    myTmp.LargeurDuColis = obj.LargeurDuColis;
                    myTmp.HauteurColis = obj.HauteurColis;
                    myTmp.ProfondeurColis = obj.ProfondeurColis;
                    myTmp.PoidsColis = obj.PoidsColis;
                    myTmp.FraisPortSupplimentaire = obj.FraisPortSupplimentaire;
                    myTmp.Transporteur = obj.Transporteur;
                    myTmp.Declinaison = obj.Declinaison;
                    myTmp.GestionStockAvance = obj.GestionStockAvance;
                    myTmp.StockEntrepot = obj.StockEntrepot;
                    myTmp.StockManuel = obj.StockManuel;
                    myTmp.RuptureAnnulerCommande = obj.RuptureAnnulerCommande;
                    myTmp.RuptureAccepteCommande = obj.RuptureAccepteCommande;
                    myTmp.RuptureDefaut = obj.RuptureDefaut;
                    myTmp.CaracteristiqueHauteur = obj.CaracteristiqueHauteur;
                    myTmp.CaracteristiqueLargeur = obj.CaracteristiqueLargeur;
                    myTmp.CaracteristiqueProfondeur = obj.CaracteristiqueProfondeur;
                    myTmp.CaracteristiquePoids = obj.CaracteristiquePoids;
                    myTmp.CaracteristiqueIdcomposition = obj.CaracteristiqueIdcomposition;
                    myTmp.CaracteristiqueIdstyle = obj.CaracteristiqueIdstyle;
                    myTmp.CaracteristiqueIdpropriete = obj.CaracteristiqueIdpropriete;
                    myTmp.Categorie = obj.Categorie;
                    myTmp.ImgProd = _context.ImageProduits.Where(x => x.Idproduit.Equals(myTmp.Id)).ToList();
                    RetListe.Add(myTmp);
                }


                return Ok(RetListe);
            }
            catch (Exception ex)
            {
                return BadRequest(Utile.LogAG(ex));
            }
        }
        [HttpPost]
        [Route("postProduit")]
        public ActionResult postProduit([FromBody] TmpProduitImg MyTmpProduit)
        {
            #region Declaration 

            Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction trans = null;

            #endregion

            try
            {

                trans = _context.Database.BeginTransaction();
                
                #region Get Compteur
                Param myparam = _context.Params.Find("CompteurProduit");

                string Compteur = myparam.Valeur;
                Param myparam2 = _context.Params.Find("CompteurImage");

                string CompteurImage = myparam2.Valeur;
                #endregion
                #region Ajout produit 
                Produit MyProduit = new Produit();
                MyProduit.Id = Compteur;
                MyProduit.Designation = MyTmpProduit.Designation;
                MyProduit.Reference = MyTmpProduit.Reference;
                MyProduit.Actif = MyTmpProduit.Actif;
                MyProduit.Visibilite = MyTmpProduit.Visibilite;
                MyProduit.DisponibiliteALaVente = MyTmpProduit.DisponibiliteALaVente;
                MyProduit.QteStk = MyTmpProduit.QteStk;
                MyProduit.AfficherPrix = MyTmpProduit.AfficherPrix;
                MyProduit.ExclusiveWeb = MyTmpProduit.ExclusiveWeb;
                MyProduit.Etat = MyTmpProduit.Etat;
                MyProduit.Resume = MyTmpProduit.Resume;
                MyProduit.Description = MyTmpProduit.Description;
                MyProduit.MotsCles = MyTmpProduit.MotsCles;
                MyProduit.PrixAchatHt = MyTmpProduit.PrixAchatHt;
                MyProduit.CodeTva = MyTmpProduit.CodeTva;
                MyProduit.DesTva = MyTmpProduit.DesTva;
                MyProduit.Marge = MyTmpProduit.Marge;
                MyProduit.PrixVenteHt = MyTmpProduit.PrixVenteHt;
                MyProduit.PrixVenteTtc = MyTmpProduit.PrixVenteTtc;
                MyProduit.AfficherBandoPromo = MyTmpProduit.AfficherBandoPromo;
                MyProduit.Marque = MyTmpProduit.Marque;
                MyProduit.Categorie = MyTmpProduit.Categorie;
                MyProduit.Fabriquant = MyTmpProduit.Fabriquant;
                MyProduit.Acessoire = MyTmpProduit.Acessoire;
                MyProduit.LargeurDuColis = MyTmpProduit.LargeurDuColis;
                MyProduit.HauteurColis = MyTmpProduit.HauteurColis;
                MyProduit.ProfondeurColis = MyTmpProduit.ProfondeurColis;
                MyProduit.PoidsColis = MyTmpProduit.PoidsColis;
                MyProduit.FraisPortSupplimentaire = MyTmpProduit.FraisPortSupplimentaire;
                MyProduit.Transporteur = MyTmpProduit.Transporteur;
                MyProduit.Declinaison = MyTmpProduit.Declinaison;
                MyProduit.GestionStockAvance = MyTmpProduit.GestionStockAvance;
                MyProduit.StockEntrepot = MyTmpProduit.StockEntrepot;
                MyProduit.StockManuel = MyTmpProduit.StockManuel;
                MyProduit.RuptureAnnulerCommande = MyTmpProduit.RuptureAnnulerCommande;
                MyProduit.RuptureAccepteCommande = MyTmpProduit.RuptureAccepteCommande;
                MyProduit.RuptureDefaut = MyTmpProduit.RuptureDefaut;
                MyProduit.CaracteristiqueHauteur = MyTmpProduit.CaracteristiqueHauteur;
                MyProduit.CaracteristiqueLargeur = MyTmpProduit.CaracteristiqueLargeur;
                MyProduit.CaracteristiqueProfondeur = MyTmpProduit.CaracteristiqueProfondeur;
                MyProduit.CaracteristiquePoids = MyTmpProduit.CaracteristiquePoids;
                MyProduit.CaracteristiqueIdcomposition = MyTmpProduit.CaracteristiqueIdcomposition;
                MyProduit.CaracteristiqueIdstyle = MyTmpProduit.CaracteristiqueIdstyle;
                MyProduit.CaracteristiqueIdpropriete = MyTmpProduit.CaracteristiqueIdpropriete;

                _context.Produits.Add(MyProduit);
                #endregion

                int i = 0;
                foreach (var obj in MyTmpProduit.ImgProd)
                {
                    if (i != 0)
                        CompteurImage = (Int32.Parse(CompteurImage) + 1).ToString();

                    obj.Idproduit = MyProduit.Id;
                    obj.Idimage = CompteurImage;

                    _context.ImageProduits.Add(obj);
                    i++;
                }
                myparam.Valeur = (Int32.Parse(myparam.Valeur) + 1).ToString();

                myparam2.Valeur = (Int32.Parse(CompteurImage) + 1).ToString();

                /// l'access groupe 
                _context.SaveChanges();
                trans.Commit();
                return Ok("Ajouté avec succée");

            }
            catch (Exception ex)
            {
                trans.Rollback();

                return BadRequest(Utile.LogAG(ex));

            }
        }


        [HttpPut]
        [Route("putProduit")]
        public ActionResult putProduit([FromBody] TmpProduitImg MyTmpProduit)
        {
            #region Declaration 
            Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction trans = null;

            #endregion

            try
            {

                trans = _context.Database.BeginTransaction();

                Param myparam2 = _context.Params.Find("CompteurImage");

                string CompteurImage = myparam2.Valeur;

                //  var obj1 = _context.CategorieProduits.Find(Mycategorie.Id);

                var AncienProd = _context.Produits.Find(MyTmpProduit.Id);

                if (AncienProd == null)
                {
                    throw new ArgumentException("Produit N°" + MyTmpProduit.Id + " est introuvable  ", new Exception("Csys Group"));
                }
                #region Update produit 
                AncienProd.Id = MyTmpProduit.Id;
                AncienProd.Designation = MyTmpProduit.Designation;
                AncienProd.Reference = MyTmpProduit.Reference;
                AncienProd.Actif = MyTmpProduit.Actif;
                AncienProd.Visibilite = MyTmpProduit.Visibilite;
                AncienProd.DisponibiliteALaVente = MyTmpProduit.DisponibiliteALaVente;
                AncienProd.AfficherPrix = MyTmpProduit.AfficherPrix;
                AncienProd.ExclusiveWeb = MyTmpProduit.ExclusiveWeb;
                AncienProd.Etat = MyTmpProduit.Etat;
                AncienProd.Resume = MyTmpProduit.Resume;
                AncienProd.Description = MyTmpProduit.Description;
                AncienProd.MotsCles = MyTmpProduit.MotsCles;
                AncienProd.PrixAchatHt = MyTmpProduit.PrixAchatHt;
                AncienProd.CodeTva = MyTmpProduit.CodeTva;
                AncienProd.DesTva = MyTmpProduit.DesTva;
                AncienProd.Marge = MyTmpProduit.Marge;
                AncienProd.PrixVenteHt = MyTmpProduit.PrixVenteHt;
                AncienProd.PrixVenteTtc = MyTmpProduit.PrixVenteTtc;
                AncienProd.AfficherBandoPromo = MyTmpProduit.AfficherBandoPromo;
                AncienProd.Marque = MyTmpProduit.Marque;
                AncienProd.Categorie = MyTmpProduit.Categorie;
                AncienProd.Fabriquant = MyTmpProduit.Fabriquant;
                AncienProd.Acessoire = MyTmpProduit.Acessoire;
                AncienProd.LargeurDuColis = MyTmpProduit.LargeurDuColis;
                AncienProd.HauteurColis = MyTmpProduit.HauteurColis;
                AncienProd.ProfondeurColis = MyTmpProduit.ProfondeurColis;
                AncienProd.PoidsColis = MyTmpProduit.PoidsColis;
                AncienProd.FraisPortSupplimentaire = MyTmpProduit.FraisPortSupplimentaire;
                AncienProd.Transporteur = MyTmpProduit.Transporteur;
                AncienProd.Declinaison = MyTmpProduit.Declinaison;
                AncienProd.GestionStockAvance = MyTmpProduit.GestionStockAvance;
                AncienProd.StockEntrepot = MyTmpProduit.StockEntrepot;
                AncienProd.StockManuel = MyTmpProduit.StockManuel;
                AncienProd.RuptureAnnulerCommande = MyTmpProduit.RuptureAnnulerCommande;
                AncienProd.RuptureAccepteCommande = MyTmpProduit.RuptureAccepteCommande;
                AncienProd.RuptureDefaut = MyTmpProduit.RuptureDefaut;
                AncienProd.CaracteristiqueHauteur = MyTmpProduit.CaracteristiqueHauteur;
                AncienProd.CaracteristiqueLargeur = MyTmpProduit.CaracteristiqueLargeur;
                AncienProd.CaracteristiqueProfondeur = MyTmpProduit.CaracteristiqueProfondeur;
                AncienProd.CaracteristiquePoids = MyTmpProduit.CaracteristiquePoids;
                AncienProd.CaracteristiqueIdcomposition = MyTmpProduit.CaracteristiqueIdcomposition;
                AncienProd.CaracteristiqueIdstyle = MyTmpProduit.CaracteristiqueIdstyle;
                AncienProd.CaracteristiqueIdpropriete = MyTmpProduit.CaracteristiqueIdpropriete;
                AncienProd.QteStk = MyTmpProduit.QteStk;

                _context.Update(AncienProd);

                #endregion
                List<ImageProduit> ListeImgProd = _context.ImageProduits.Where(x => x.Idproduit == MyTmpProduit.Id).ToList();

                _context.ImageProduits.RemoveRange(ListeImgProd);

                //int i = 0;
                //foreach (var obj in MyTmpProduit.ImgProd)
                //{
                //    if (i != 0)
                //        CompteurImage = (Int32.Parse(CompteurImage) + 1).ToString();

                //    obj.Idproduit = MyTmpProduit.Id;
                //    obj.Idimage = CompteurImage;

                //    _context.ImageProduits.Add(obj);
                //    i++;
                //}

             //   myparam2.Valeur = (Int32.Parse(CompteurImage) + 1).ToString();
                 
                /// l'access groupe 
                _context.SaveChanges();
                trans.Commit();
                return Ok("Modifié avec succée");

            }
            catch (Exception ex)
            {
                trans.Rollback();

                return BadRequest(Utile.LogAG(ex));

            }
        }

        [HttpDelete]
        [Route("DeleteProduit")]
        public ActionResult DeleteProduit([FromQuery] string id)
        {
            #region Declaration 
           
            Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction trans = null;

            #endregion

            try
            {

                trans = _context.Database.BeginTransaction();

                var AncienProd = _context.Produits.Find(id);

                if (AncienProd == null)
                {
                    throw new ArgumentException("Produit N°" + AncienProd.Id + " est introuvable  ", new Exception("Csys Group"));
                }

                _context.Produits.Remove(AncienProd);
                 
                //  l'access groupe 
                _context.SaveChanges();
                trans.Commit();
                return Ok("Supprimé avec succée");

            }
            catch (Exception ex)
            {
                trans.Rollback();

                return BadRequest(Utile.LogAG(ex));
            }
        }

        // POST: api/Produits
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Produit>> PostProduit(Produit produit)
        {
            _context.Produits.Add(produit);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProduitExists(produit.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProduit", new { id = produit.Id }, produit);
        }

        

        private bool ProduitExists(string id)
        {
            return _context.Produits.Any(e => e.Id == id);
        }
    }
}
