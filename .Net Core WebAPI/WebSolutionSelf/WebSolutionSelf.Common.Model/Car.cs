using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSolutionSelf.Common.Enum;

namespace WebSolutionSelf.Common.Model
{
    public class Car
    {
        public int Id { get; set; }
        public string CarName { get; set; }

        public string CarManufacturer { get; set; }

        public string CarModel { get; set; }

        public ColorType CarColor { get; set; }

        public string CarReleaseDate { get; set; }
       
    }
}
