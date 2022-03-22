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
        public ActionResult GetListeProduit()
        {
            try
            {
               
                   var v = (from Prod in _context.Produits
                            join Cat in _context.CategorieProduits on Prod.Categorie equals (Cat.Id)
                            orderby Prod.Id descending
                         select new
                         {
                             id = Prod.Id,
                             designation = Prod.Designation,
                             reference = Prod.Reference,
                             Categorie = Cat.Designation,
                             prixBase = Prod.PrixVenteTtc,
                             prixFinal = Prod.PrixVenteTtc,
                             quantite =0, // a verifer 
                             Etat = Prod.Etat, 

                         }).Distinct();

                return Ok(v.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(Utile.LogAG(ex));
            }
        }
        [HttpPost]
        [Route("postProduit")]
        public ActionResult postProduit([FromBody] Produit MyProduit)
        {
            #region Declaration 
            Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction trans = null;

            #endregion

            try
            {

                trans = _context.Database.BeginTransaction();
                //  DateTime DatSys = new Utile().GetDateSystem(_context);

                #region Get Compteur
                Param myparam = _context.Params.Find("CompteurProduit");
                 
                string Compteur  = myparam.Valeur;

                #endregion

                MyProduit.Id = Compteur;
                _context.Produits.Add(MyProduit);

                myparam.Valeur = (Int32.Parse(myparam.Valeur) + 1).ToString(); 

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
        public ActionResult putProduit([FromBody] Produit MyProduit)
        {
            #region Declaration 
            Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction trans = null;

            #endregion

            try
            {

                trans = _context.Database.BeginTransaction();

                //  var obj1 = _context.CategorieProduits.Find(Mycategorie.Id);

                var AncienProd = _context.Produits.Find(MyProduit.Id);

                if (AncienProd == null)
                {
                    throw new ArgumentException("Produit N°" + MyProduit.Id + " est introuvable  ", new Exception("Csys Group"));
                }
                AncienProd.Id = MyProduit.Id;
                AncienProd.Designation = MyProduit.Designation;
                AncienProd.Reference = MyProduit.Reference;
                AncienProd.Actif = MyProduit.Actif;
                AncienProd.Visibilite = MyProduit.Visibilite;
                AncienProd.DisponibiliteALaVente = MyProduit.DisponibiliteALaVente;
                AncienProd.AfficherPrix = MyProduit.AfficherPrix;
                AncienProd.ExclusiveWeb = MyProduit.ExclusiveWeb;
                AncienProd.Etat = MyProduit.Etat;
                AncienProd.Resume = MyProduit.Resume;
                AncienProd.Description = MyProduit.Description;
                AncienProd.MotsCles = MyProduit.MotsCles;
                AncienProd.PrixAchatHt = MyProduit.PrixAchatHt;
                AncienProd.CodeTva = MyProduit.CodeTva;
                AncienProd.DesTva = MyProduit.DesTva;
                AncienProd.Marge = MyProduit.Marge;
                AncienProd.PrixVenteHt = MyProduit.PrixVenteHt;
                AncienProd.PrixVenteTtc = MyProduit.PrixVenteTtc;
                AncienProd.AfficherBandoPromo = MyProduit.AfficherBandoPromo;
                AncienProd.Marque = MyProduit.Marque;
                AncienProd.Categorie = MyProduit.Categorie;
                AncienProd.Fabriquant = MyProduit.Fabriquant;
                AncienProd.Acessoire = MyProduit.Acessoire;
                AncienProd.LargeurDuColis = MyProduit.LargeurDuColis;
                AncienProd.HauteurColis = MyProduit.HauteurColis;
                AncienProd.ProfondeurColis = MyProduit.ProfondeurColis;
                AncienProd.PoidsColis = MyProduit.PoidsColis;
                AncienProd.FraisPortSupplimentaire = MyProduit.FraisPortSupplimentaire;
                AncienProd.Transporteur = MyProduit.Transporteur;
                AncienProd.Declinaison = MyProduit.Declinaison;
                AncienProd.GestionStockAvance = MyProduit.GestionStockAvance;
                AncienProd.StockEntrepot = MyProduit.StockEntrepot;
                AncienProd.StockManuel = MyProduit.StockManuel;
                AncienProd.RuptureAnnulerCommande = MyProduit.RuptureAnnulerCommande;
                AncienProd.RuptureAccepteCommande = MyProduit.RuptureAccepteCommande;
                AncienProd.RuptureDefaut = MyProduit.RuptureDefaut;
                AncienProd.CaracteristiqueHauteur = MyProduit.CaracteristiqueHauteur;
                AncienProd.CaracteristiqueLargeur = MyProduit.CaracteristiqueLargeur;
                AncienProd.CaracteristiqueProfondeur = MyProduit.CaracteristiqueProfondeur;
                AncienProd.CaracteristiquePoids = MyProduit.CaracteristiquePoids;
                AncienProd.CaracteristiqueIdcomposition = MyProduit.CaracteristiqueIdcomposition;
                AncienProd.CaracteristiqueIdstyle = MyProduit.CaracteristiqueIdstyle;
                AncienProd.CaracteristiqueIdpropriete = MyProduit.CaracteristiqueIdpropriete;

                _context.Update(AncienProd);


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
