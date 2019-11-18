using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ClientProject.Models;

namespace ClientProject.Controllers
{
    public class ClientDetailsController : ApiController
    {
        private ClientProjectContext db = new ClientProjectContext();

        // GET: api/ClientDetails
        public IQueryable<ClientDetails> GetClientDetails()
        {
            return db.ClientDetails;
        }

        // GET: api/ClientDetails/5
        [ResponseType(typeof(ClientDetails))]
        public IHttpActionResult GetClientDetails(int id)
        {
            ClientDetails clientDetails = db.ClientDetails.Find(id);
            if (clientDetails == null)
            {
                return NotFound();
            }

            return Ok(clientDetails);
        }

        // PUT: api/ClientDetails/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutClientDetails(int id, ClientDetails clientDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != clientDetails.id)
            {
                return BadRequest();
            }

            db.Entry(clientDetails).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientDetailsExists(id))
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

        // POST: api/ClientDetails
        [ResponseType(typeof(ClientDetails))]
        public IHttpActionResult PostClientDetails(ClientDetails clientDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ClientDetails.Add(clientDetails);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = clientDetails.id }, clientDetails);
        }

        // DELETE: api/ClientDetails/5
        [ResponseType(typeof(ClientDetails))]
        public IHttpActionResult DeleteClientDetails(int id)
        {
            ClientDetails clientDetails = db.ClientDetails.Find(id);
            if (clientDetails == null)
            {
                return NotFound();
            }

            db.ClientDetails.Remove(clientDetails);
            db.SaveChanges();

            return Ok(clientDetails);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClientDetailsExists(int id)
        {
            return db.ClientDetails.Count(e => e.id == id) > 0;
        }
    }
}