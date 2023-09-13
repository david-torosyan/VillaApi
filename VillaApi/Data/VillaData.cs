using System.Xml.Linq;
using VillaApi.Models;

namespace VillaApi.Data
{
    public static class VillaData
    {
       public static List<VillaModel> Villas = new List<VillaModel>
            {
                new VillaModel() { Id = 1, Name = "Pool View" },
                new VillaModel() { Id = 2, Name = "Beach View" },
            };
}
}
