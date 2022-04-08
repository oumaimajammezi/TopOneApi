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
    public class ClientsController : ControllerBase
    {
        //private readonly TOPONEContext _context;

        TOPONEContext _context = new TOPONEContext();

        //public ClientsController(TOPONEContext context)
        //{
        //    _context = context;
        //}

        // GET: api/Clients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> GetClients()
        {
            return await _context.Clients.ToListAsync();
        }

        // GET: api/Clients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetClient(string id)
        {
            var client = await _context.Clients.FindAsync(id);

            if (client == null)
            {
                return NotFound();
            }

            return client;
        }

     
        [HttpGet]
        [Route("getListClient")]
        public ActionResult getListClient([FromQuery] PaginationFilter filter)
        {
            try
            { 
                var v = (from Clt in _context.Clients
                         join grp1 in _context.GroupeClients on Clt.Idgroupe equals grp1.Id                        
                         where Clt.Actif.Equals(true)
                         orderby Clt.Idparain descending
                         select new
                         {
                             idClient = Clt.Id,
                             IDParain = Clt.Idparain,
                             Nom = Clt.Nom,
                             Prenom = Clt.Prenom,
                             CIN = Clt.Cin,
                             TelGSM = Clt.TelGsm,
                             TelFixe = Clt.TelFixe,
                             Email = Clt.Email,
                             grade = grp1.Designation,
                         }).Distinct();

                return Ok(v.Skip((filter.PageNumber - 1) * filter.PageSize)
               .Take(filter.PageSize).ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(Utile.LogAG(ex));
            }
        }
        [HttpPut]
        [Route("putClient")]
        public ActionResult putClient([FromBody] Client MyClient)
        {
            #region Declaration 
            Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction trans = null;

            #endregion

            try
            {

                trans = _context.Database.BeginTransaction();


                var AncienClt = _context.Clients.Find(MyClient.Id);

                if (AncienClt == null)
                {
                    throw new ArgumentException("Client N°" + MyClient.Id + " est introuvable  ", new Exception("Csys Group"));
                }




                //AncienClt.Id = MyClient.Id;
                //AncienClt.Idparain = MyClient.Idparain;
                //AncienClt.Idgroupe = MyClient.Idgroupe;
                AncienClt.Nom = MyClient.Nom;
                AncienClt.Prenom = MyClient.Prenom;
                AncienClt.Cin = MyClient.Cin;
                AncienClt.IdpieceCinrecto = MyClient.IdpieceCinrecto;
                AncienClt.IdpieceCinverso = MyClient.IdpieceCinverso;
                AncienClt.Societe = MyClient.Societe;
                AncienClt.MatriculeFiscal = MyClient.MatriculeFiscal;
                AncienClt.TelGsm = MyClient.TelGsm;
                AncienClt.TelFixe = MyClient.TelFixe;
                AncienClt.Email = MyClient.Email;
                AncienClt.DateNaissance = MyClient.DateNaissance;
                AncienClt.Adresse = MyClient.Adresse;
                AncienClt.Ville = MyClient.Ville;
                AncienClt.Pays = MyClient.Pays;
                AncienClt.CodePostal = MyClient.CodePostal;
                AncienClt.Login = MyClient.Login;
                AncienClt.MotPasse = MyClient.MotPasse;
                AncienClt.DateInscription = MyClient.DateInscription;
                AncienClt.DerniereVisite = MyClient.DerniereVisite;
                AncienClt.Sexe = MyClient.Sexe;
                AncienClt.Sdebit = MyClient.Sdebit;
                AncienClt.Scredit = MyClient.Scredit;
                AncienClt.Note = MyClient.Note;
                AncienClt.Actif = MyClient.Actif;

                _context.Update(AncienClt);


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

        // POST: api/Clients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Client>> PostClient(Client client)
        {
            _context.Clients.Add(client);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ClientExists(client.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetClient", new { id = client.Id }, client);
        }

        // DELETE: api/Clients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(string id)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClientExists(string id)
        {
            return _context.Clients.Any(e => e.Id == id);
        }
    }
}
