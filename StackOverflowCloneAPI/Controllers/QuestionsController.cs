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
using StackOverflowCloneAPI.Data;
using StackOverflowCloneAPI.Models;

namespace StackOverflowCloneAPI.Controllers
{
    [EnableCors(origins: "https://stackoverflowcloneraklet.azurewebsites.net", headers: "*", methods: "*")]
    public class QuestionsController : ApiController
    {
        private StackOverflowCloneAPIContext db = new StackOverflowCloneAPIContext();

        // GET: api/Questions
        public IQueryable<Questions> GetQuestions()
        {
            return db.Questions;
        }

        // GET: api/Questions/5
        [ResponseType(typeof(Questions))]
        public IHttpActionResult GetQuestions(int id)
        {
            Questions questions = db.Questions.Find(id);
            if (questions == null)
            {
                return NotFound();
            }

            return Ok(questions);
        }

        // PUT: api/Questions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutQuestions(int id, Questions questions)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != questions.id)
            {
                return BadRequest();
            }

            db.Entry(questions).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestionsExists(id))
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

        // POST: api/Questions
        [ResponseType(typeof(Questions))]
        public IHttpActionResult PostQuestions(Questions questions)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Questions.Add(questions);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = questions.id }, questions);
        }

        // DELETE: api/Questions/5
        [ResponseType(typeof(Questions))]
        public IHttpActionResult DeleteQuestions(int id)
        {
            Questions questions = db.Questions.Find(id);
            if (questions == null)
            {
                return NotFound();
            }

            db.Questions.Remove(questions);
            db.SaveChanges();

            return Ok(questions);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool QuestionsExists(int id)
        {
            return db.Questions.Count(e => e.id == id) > 0;
        }
    }
}