using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ASP.NetWebApiMVCProject.Models;

namespace ASP.NetWebApiMVCProject.Controllers
{
    public class CoursController : ApiController
    {
        private webApiProjectEntities db = new webApiProjectEntities();

        // GET: api/Cours
        public IQueryable<Cours> GetCourses()
        {
            return db.Courses;
        }

        // GET: api/Cours/5
        [ResponseType(typeof(Cours))]
        public async Task<IHttpActionResult> GetCours(int id)
        {
            Cours cours = await db.Courses.FindAsync(id);
            if (cours == null)
            {
                return NotFound();
            }

            return Ok(cours);
        }

        // PUT: api/Cours/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCours(int id, Cours cours)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cours.CourseID)
            {
                return BadRequest();
            }

            db.Entry(cours).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoursExists(id))
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

        // POST: api/Cours
        [ResponseType(typeof(Cours))]
        public async Task<IHttpActionResult> PostCours(Cours cours)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Courses.Add(cours);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = cours.CourseID }, cours);
        }

        // DELETE: api/Cours/5
        [ResponseType(typeof(Cours))]
        public async Task<IHttpActionResult> DeleteCours(int id)
        {
            Cours cours = await db.Courses.FindAsync(id);
            if (cours == null)
            {
                return NotFound();
            }

            db.Courses.Remove(cours);
            await db.SaveChangesAsync();

            return Ok(cours);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CoursExists(int id)
        {
            return db.Courses.Count(e => e.CourseID == id) > 0;
        }
    }
}