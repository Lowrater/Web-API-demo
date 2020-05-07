using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web_API_demo.Models;

namespace Web_API_demo.Controllers 
{
    /// <summary>
    /// This is a controller for filtering and getting data regarding users
    /// </summary>
    public class PeopleController : ApiController
    {
        List<Person> people = new List<Person>();

        
        /// <summary>
        /// Constructor of the PeopleController
        /// On run time, creates new persons
        /// </summary>
        public PeopleController()
        {
            //-- Default demo data
            people.Add(new Person { Id=1, Name = "Martin Stach", Age = 26, City = "Potatoe city" });
            people.Add(new Person { Id=2, Name = "Tim Corey", Age = 38, City = "New York" });
        }

        /// <summary>
        /// Returns a list of names
        /// </summary>
        /// <returns></returns>
        [Route("api/people/GetNames")]
        [HttpGet]
        public List<string> GetNames()
        {
            List<string> output = new List<string>();

            foreach (var p in people)
            {
                output.Add(p.Name);
            }

            return output;
        }


        // GET: api/People
        public List<Person> Get()
        {
            return people;
        }

        // GET: api/People/5
        public Person Get(int id)
        {
            return people.Where(p => p.Id == id).FirstOrDefault();
        }

        // POST: api/People
        public void Post(Person value)
        {
            people.Add(value);
        }

        // PUT: api/People/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/People/5
        public void Delete(int id)
        {
            people.Remove(people.Where(p => p.Id == id).FirstOrDefault());
        }
    }
}
