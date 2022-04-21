using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSolutionSelf.Common.Enum;

namespace WebSolutionSelf.Common.Model
{
    public class CarSearchingParameters
    {
        public string CarName { get; set; }
        public string Manufacturer { get; set; }

        public string Model { get; set; }

        public ColorType Color { get; set; }

        public string ReleaseDate { get; set; }

    }
}
