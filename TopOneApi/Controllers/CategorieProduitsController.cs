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
    public class CategorieProduitsController : ControllerBase
    {
        //private readonly TOPONEContext _context;

        //public CategorieProduitsController(TOPONEContext context)
        //{
        //    _context = context;
        //}
        TOPONEContext _context = new TOPONEContext();

        // GET: api/CategorieProduits
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategorieProduit>>> GetCategorieProduits()
        {
            return await _context.CategorieProduits.ToListAsync();
        }
        [HttpGet]
        [Route("GetListeCategorie")]
        public ActionResult GetListeCategorie()
        {
            try
            { 
                var v = (from Cat in _context.CategorieProduits                  
                         orderby Cat.Id descending
                         select new
                         {
                             id= Cat.Id,
                             designation = Cat.Designation,
                             description = "",
                             position = Cat.Ordre,
                             affiche = Cat.Actif,
                            
                         }).Distinct();

                return Ok(v.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(Utile.LogAG(ex));
            }
        }
        [HttpPost]
        [Route("postCategorie")]
        public ActionResult postCategorie([FromBody] CategorieProduit Mycategorie)
        {
            #region Declaration 
            Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction trans = null;
            
            #endregion

            try
            {

                trans = _context.Database.BeginTransaction();
              //  DateTime DatSys = new Utile().GetDateSystem(_context);
                 
                Mycategorie.Id= 0;                
                _context.CategorieProduits.Add(Mycategorie);
                 

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
        [Route("putCategorie")]
        public ActionResult putCategorie([FromBody] CategorieProduit Mycategorie)
        {
            #region Declaration 
            Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction trans = null;

            #endregion

            try
            {

                trans = _context.Database.BeginTransaction();

              //  var obj1 = _context.CategorieProduits.Find(Mycategorie.Id);

                var AncienCat = _context.CategorieProduits.Find(Mycategorie.Id);

                if (AncienCat == null)
                {
                    throw new ArgumentException("Catégorie N°" + Mycategorie.Id + " est introuvable  ", new Exception("Csys Group"));
                }
                AncienCat.Designation = Mycategorie.Designation;
                AncienCat.Ordre = Mycategorie.Ordre;
                AncienCat.Actif = Mycategorie.Actif; 
                _context.Update(AncienCat);


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
        [Route("DeleteCategorie")]
        public ActionResult DeleteCategorie([FromQuery] decimal id)
        {
            #region Declaration 
            Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction trans = null;

            #endregion

            try
            {

                trans = _context.Database.BeginTransaction();
                 
                var AncienCat = _context.CategorieProduits.Find(id);

                if (AncienCat == null)
                {
                    throw new ArgumentException("Catégorie N°" +id + " est introuvable  ", new Exception("Csys Group"));
                }

                _context.CategorieProduits.Remove(AncienCat);


                /// l'access groupe 
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


        // GET: api/CategorieProduits/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategorieProduit>> GetCategorieProduit(decimal id)
        {
            var categorieProduit = await _context.CategorieProduits.FindAsync(id);

            if (categorieProduit == null)
            {
                return NotFound();
            }

            return categorieProduit;
        }

        // PUT: api/CategorieProduits/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategorieProduit(decimal id, CategorieProduit categorieProduit)
        {
            if (id != categorieProduit.Id)
            {
                return BadRequest();
            }

            _context.Entry(categorieProduit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategorieProduitExists(id))
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

        // POST: api/CategorieProduits
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CategorieProduit>> PostCategorieProduit(CategorieProduit categorieProduit)
        {
            _context.CategorieProduits.Add(categorieProduit);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategorieProduit", new { id = categorieProduit.Id }, categorieProduit);
        }

        // DELETE: api/CategorieProduits/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategorieProduit(decimal id)
        {
            var categorieProduit = await _context.CategorieProduits.FindAsync(id);
            if (categorieProduit == null)
            {
                return NotFound();
            }

            _context.CategorieProduits.Remove(categorieProduit);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CategorieProduitExists(decimal id)
        {
            return _context.CategorieProduits.Any(e => e.Id == id);
        }
    }
}
