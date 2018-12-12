using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModisAPI.Models;
using ModisAPI.WorkerServices;

namespace ModisAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentiController : ControllerBase
    {
        private IWorkerServiceStudenti worker;

        public StudentiController(IWorkerServiceStudenti _worker)
        {
            worker = _worker;
        }

        [HttpGet]
        public IEnumerable<ViewModelStudente> Get()
        {
            return worker.RestituisciListaStudenti();
        }

        [HttpGet("{id}", Name = "Get")]
        public Studente Get(int id)
        {
            return worker.RestituisciStudente(id);
        }

        [HttpPost]
        public void Post(Studente studente)
        {
            worker.CreaStudente(studente);
        }

        // PUT: api/Studenti/5
        [HttpPut("{id}")]
        public void Put(int id, Studente studenteModificato)
        {
            worker.ModificaStudente(studenteModificato);
        }

        // DELETE: api/ApiWithActions/5
        //[Route("canc/{id}")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            worker.CancellaStudente(id);
        }
    }
}