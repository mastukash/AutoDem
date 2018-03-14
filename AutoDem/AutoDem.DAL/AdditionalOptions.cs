using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDem.DAL
{
    public class AdditionalOption
    {
        public int Id { get; set; }
        public string characteristic { get; set; }
        public virtual List<Auto> Autos { get; set; }
    }
}
