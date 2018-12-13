using System;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ModisAPI.Models
{
    public class Corso
    {
        public int CorsoId { get; set; }
        public string Nome { get; set; }
        //[Column("DataInizio")]
        public DateTime? DataInizio { get; set; }
        public int DurataInOre { get; set; }
        public int Livello { get; set; }
        public int NumeroMassimoPartecipanti { get; set; }
        public List<StudenteCorso> StudenteCorsi { get; set; }

    }
}
