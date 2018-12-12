using ModisAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace ModisAPI.WorkerServices
{
    public class WorkerServiceSQLServerDB : IWorkerServiceStudenti
    {
        private ModisContext db;

        public WorkerServiceSQLServerDB()
        {
            db = new ModisContext();
        }

        public void CreaStudente(Studente studente)
        {
            db.Studenti.Add(studente);
            db.SaveChanges();
        }

        public void ModificaStudente(Studente studenteModificato)
        {
            db.Entry(studenteModificato).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }

        public void CancellaStudente(int id)
        {
            db.Entry(RestituisciStudente(id)).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            db.SaveChanges();
        }

        public List<ViewModelStudente> RestituisciListaStudenti()
        {
            return db.Studenti.Include("Corsi").Select(y => new ViewModelStudente
            {
                IdStudente = y.Id,
                NomeCompleto = y.Nome + " " + y.Cognome,
                Corsi = y.StudenteCorsi.Select(z => new Corso()
                {
                    CorsoId = z.Corso.CorsoId,
                    Nome = z.Corso.Nome,
                    DataDate = z.Corso.DataDate,
                    Livello = z.Corso.Livello,
                    DurataInOre = z.Corso.DurataInOre,
                    NumeroMassimoPartecipanti = z.Corso.NumeroMassimoPartecipanti
                    
                }).ToList()
            }).ToList();
        }

        public Studente RestituisciStudente(int id)
        {
            //return db.Studenti.Find(id); se siamo sicuri sia una chiave 
            return db.Studenti.Where(x => x.Id == id).FirstOrDefault();
        }
    }

    //public class WorkerServiceOracleDb : IWorkerServiceStudenti
    //{
    //    public List<Studente> RestituisciListaStudenti()
    //    {

    //        throw new NotImplementedException();
    //    }

    //    public Studente RestituisciStudente(int id)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}

    //public class WorkerServiceStudenti : IWorkerServiceStudenti
    //{
    //    public List<Studente> RestituisciListaStudenti()
    //    {
    //        var studente1 = new Studente { Id = 1, Cognome = "Mario", Nome = "Rossi" };
    //        var studente2 = new Studente { Id = 2, Cognome = "MastroCesare", Nome = "Francesco" };
    //        return new List<Studente> { studente1, studente2 };
    //    }

    //    public Studente RestituisciStudente(int id)
    //    {
    //        return RestituisciListaStudenti().Where(x => x.Id == id).FirstOrDefault();
    //    }

    //    public void CreaStudente(Studente studente)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
