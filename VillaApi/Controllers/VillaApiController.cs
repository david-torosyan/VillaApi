using Microsoft.AspNetCore.Mvc;
using VillaApi.Models;

namespace VillaApi.Controllers
{
    [Route("api/VillaApi")]
    [ApiController]
    public class VillaApiController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<VillaModel> GetVillas()
        {
            return new List<VillaModel>
            {
                new VillaModel() {Id = 1, Name = "Pool View" },
                new VillaModel() {Id = 2, Name = "Beach View" },
            };
        }
    }
}
