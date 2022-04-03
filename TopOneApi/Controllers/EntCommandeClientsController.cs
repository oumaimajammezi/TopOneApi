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
    public class EntCommandeClientsController : ControllerBase
    {
        TOPONEContext _context = new TOPONEContext();

        //    private readonly TOPONEContext _context;

        //    public EntCommandeClientsController(TOPONEContext context)
        //    {
        //        _context = context;
        //    }


        [HttpPost]
        [Route("postCommande")]
        public ActionResult postCommande([FromBody] Commande MyCommande)
        {
            #region Declaration <
            Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction trans = null;

            #endregion

            try
            {

                trans = _context.Database.BeginTransaction();
                DateTime DatSys = new Utile().GetDateSystem(_context);

                #region Get Compteur
                Param myparam = _context.Params.Find("CompteurCommande");

                string Compteur = myparam.Valeur;

                #endregion

                foreach (var det in MyCommande.DetCmd)
                    det.NumPiece = Compteur;

                MyCommande.EntCmd.NumPiece = Compteur;
                MyCommande.EntCmd.DateSystem = DatSys;


                _context.EntCommandeClients.Add(MyCommande.EntCmd);
                _context.DetCommandeClients.AddRange(MyCommande.DetCmd);

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



        [HttpDelete]
        [Route("DeleteCommande")]
        public ActionResult DeleteCommande([FromQuery] string id)
        {
            #region Declaration 

            Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction trans = null;

            #endregion

            try
            {

                trans = _context.Database.BeginTransaction();

                var EntCommande = _context.EntCommandeClients.Find(id);

                if (EntCommande == null)
                {
                    throw new ArgumentException("Commande N°" + id + " est introuvable  ", new Exception("Csys Group"));
                }
                List<DetCommandeClient> MyDetailCmd = _context.DetCommandeClients.Where(x => x.NumPiece == id).ToList();

                // TO DO TABLE TRACE 
                _context.EntCommandeClients.Remove(EntCommande);
                _context.DetCommandeClients.RemoveRange(MyDetailCmd);

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





        [HttpGet]
        [Route("GetListeCommandeParIdClient")]
        public ActionResult GetListeCommandeParIdClient(string idClient)
        {
            try
            {
                var v = (from ent in _context.EntCommandeClients
                         join det in _context.DetCommandeClients on ent.NumPiece equals det.NumPiece
                         join cli in _context.Clients on ent.Idclient equals cli.Id
                         join adrLivraison in _context.AdresseClients on ent.IdadresseLivraiconClient equals adrLivraison.Id into gj
                         from adrLivraison in gj.DefaultIfEmpty()
                         join adrfacturation in _context.AdresseClients on ent.IdadresseFacturationClient equals adrfacturation.Id into gj2
                         from adrfacturation in gj2.DefaultIfEmpty()


                         join vilFact in _context.Villes on adrfacturation.Idville equals vilFact.Id into gv2
                         from vilFact in gv2.DefaultIfEmpty()

                         join vilLaiv in _context.Villes on adrLivraison.Idville equals vilLaiv.Id into gvL2
                         from vilLaiv in gvL2.DefaultIfEmpty()


                         where cli.Id.Equals(idClient)
                         orderby ent.DateCreation descending
                         select new
                         {
                             id_client = cli.Id,
                             Idparain = cli.Idparain,
                             Idgroupe = cli.Idgroupe,
                             Nom = cli.Nom,
                             Prenom = cli.Prenom,
                             Cin = cli.Cin,

                             NumPiece = ent.NumPiece,
                             DatPiece = ent.DatPiece,
                             TypPiece = ent.TypPiece,
                             Depot = ent.Depot,
                             TmntHt = ent.TmntHt,
                             TmntTva = ent.TmntTva,
                             Tremise = ent.Tremise,
                             TmntTtc = ent.TmntTtc,
                             Payement = ent.Payement,
                             EtatPiece = ent.EtatPiece,
                             EtatMail = ent.EtatMail,
                             DateCreation = ent.DateCreation  ,

                             adresseLivraiconClient = adrLivraison.Adresse,
                             adresseFacturationClient = adrfacturation.Adresse  ,

                             VilleLivraiconClient = vilLaiv.DesVille,
                             villeFacturationClient = vilFact.DesVille,
                         }).Distinct();

                return Ok(v.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(Utile.LogAG(ex));
            }
        }


    }
}
