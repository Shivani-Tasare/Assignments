using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using ClientProject.Models;
using System.Web.Routing;

namespace ClientProject.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ClientsController : ApiController
    {
        private ClientProjectContext db = new ClientProjectContext();

        // GET: api/Clients
        [Route("enterName/")]
        public IQueryable<Client> GetClients()
        {
            int noOfRecords = 5;

            return db.Clients.Include(cd => cd.clientDetails).Take(noOfRecords);
        }

        // GET: api/Clients/5
        [ResponseType(typeof(Client))]
        public IHttpActionResult GetClient(int id)
        {
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }
       [Route("enterName/{fname}/{lname}")]
        [ResponseType(typeof(Client))]
        public IHttpActionResult GetClientByBothName(string fname, string lname)
        {
          

          var  clients = db.Clients.Include(cd => cd.clientDetails).Where(n => n.first_name == fname && n.last_name == lname).ToList();

            if(clients == null)
            {
                return NotFound();
            }

            return Ok(clients);
        }

        [Route("enterName/{name}")]
        [ResponseType(typeof(Client))]
        public IHttpActionResult GetClientBySingleName(string name)
        {
            IList<Client> clients = null;

            clients = db.Clients.Include(cd => cd.clientDetails).Where(n => (n.first_name.Contains(name)) || (n.last_name.Contains(name)) ).ToList();
            
            if(clients == null)
            {
                return NotFound();
            }

            return Ok(clients);
        }
        // PUT: api/Clients/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutClient(int id, Client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != client.clientId)
            {
                return BadRequest();
            }

            db.Entry(client).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Clients
        [ResponseType(typeof(Client))]
        public IHttpActionResult PostClient(Client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Clients.Add(client);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = client.clientId }, client);
        }

        // DELETE: api/Clients/5
        [ResponseType(typeof(Client))]
        public IHttpActionResult DeleteClient(int id)
        {
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return NotFound();
            }

            db.Clients.Remove(client);
            db.SaveChanges();

            return Ok(client);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClientExists(int id)
        {
            return db.Clients.Count(e => e.clientId == id) > 0;
        }
    }
}