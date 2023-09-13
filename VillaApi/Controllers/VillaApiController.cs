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
        [HttpGet]
        public ActionResult<IEnumerable<VillaModel>> GetVillas()
        {
            return Ok(VillaData.Villas);
        }

        [HttpGet("{id:int}", Name = "GetVilla")]
        public ActionResult<VillaModel> GetVilla(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var villa = VillaData.Villas.Where(u => u.Id == id).FirstOrDefault();
            if (villa == null)
            {
                return NotFound();
            }
            return Ok(villa);
        }

        [HttpPost]
        public ActionResult<VillaModel> CreateVilla([FromBody] VillaModel villa)
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

            villa.Id = VillaData.Villas.OrderByDescending(u => u.Id).FirstOrDefault().Id + 1;
            VillaData.Villas.Add(villa);

            return CreatedAtRoute("GetVilla", new { id = villa.Id }, villa);
        }


    }
}
