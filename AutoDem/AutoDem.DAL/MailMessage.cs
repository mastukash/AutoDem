using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDem.DAL
{
    public class MailMessage
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string AuthorFName { get; set; }
        public string AuthorLName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime DateTime { get; set; }
        public bool Read { get; set; }
    }
}
