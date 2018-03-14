using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDem.DAL
{
    public class PhotoAuto
    {
        public int Id { get; set; }
        public string PathToPhoto { get; set; }
        public virtual Auto Auto { get; set; }
    }
}
