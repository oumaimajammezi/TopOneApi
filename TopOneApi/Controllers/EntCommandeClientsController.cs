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
            #region Declaration 
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

    }
}
