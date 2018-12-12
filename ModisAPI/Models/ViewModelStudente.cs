using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModisAPI.Models
{
    public class ViewModelStudente
    {
        public int IdStudente { get; set; }
        public string NomeCompleto { get; set; }
        public List<Corso> Corsi { get; set; }

    }
}
