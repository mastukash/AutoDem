using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDem.DAL
{
    public class Model
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Producer { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual List<Auto> Autos { get; set; }
    }
}
