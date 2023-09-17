using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using VillaApi.Data;
using VillaApi.Models;

namespace VillaApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class VillaApiController : ControllerBase
    {
        ApplicationDbContext _db;
        public VillaApiController(ApplicationDbContext dbContext)
        {
            _db = dbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Villa>> GetVillas()
        {
            var villas = _db.Villas.ToList();
            return Ok(villas);
        }

        [HttpGet("{id:int}", Name = "GetVilla")]
        public ActionResult<Villa> GetVilla(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            Villa? villa = _db.Villas.Where(u => u.Id == id).FirstOrDefault();

            if (villa == null)
            {
                return NotFound();
            }
            return Ok(villa);
        }

        [HttpPost]
        public ActionResult<Villa> CreateVilla([FromBody] Villa villa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (villa == null)
            {
                return BadRequest();
            }
            if (villa.Id > 0)
            {
                return BadRequest();

            }

            _db.Villas.Add(villa);
            _db.SaveChanges();

            return CreatedAtRoute("GetVilla", new { id = villa.Id }, villa);
        }

        [HttpDelete]
        public ActionResult DeleteVilla(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var villa = _db.Villas.Where(u => u.Id == id).FirstOrDefault();

            if (villa == null)
            {
                return BadRequest();
            }

            _db.Villas.Remove(villa);
            _db.SaveChanges();

            return NoContent();
        }

        [HttpPut]
        public ActionResult UpdateVilla(int id, [FromBody] Villa villa) 
        {
            if (id == 0 || id != villa.Id || ModelState.IsValid)
            {
                _db.Villas.Update(villa);
                _db.SaveChanges();
                return NoContent();
            }
            return BadRequest();
        }

    }
}
