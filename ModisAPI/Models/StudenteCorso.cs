using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModisAPI.Models
{
    public class StudenteCorso
    {
        public int StudenteID { get; set; }
        public Studente Studente { get; set; }
        public int CorsoID { get; set; }
        public Corso Corso { get; set; }
    }
}
