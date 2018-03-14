using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDem.DAL
{
    public class Comment
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public int Rating { get; set; }
        public string AuthorName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public virtual Auto Auto{ get; set; }
    }
}
