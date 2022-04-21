using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSolutionSelf.WebApp._4_DataAccess.Entities
{
    public class CarEntities
    {
        public int Id { get; set; }
        public string CarName { get; set; }

        public string CarManufacturer { get; set; }

        public string CarModel { get; set; }

        public int CarColor  { get; set; }

        public string CarReleaseDate { get; set; }
    }
}
