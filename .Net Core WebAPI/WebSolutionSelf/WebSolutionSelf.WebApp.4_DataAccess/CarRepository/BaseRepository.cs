using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSolutionSelf.WebApp._4_DataAccess.CarRepository
{
    public class BaseRepository
    {
        public Context context { get; set; }
        public BaseRepository(Context context)
        {
            this.context = context;
        }

        
    }
}
