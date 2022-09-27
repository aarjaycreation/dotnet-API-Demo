using DemoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DemoAPI.Controllers
{
    public class PeopleController : ApiController
    {

        List<Person>  people = new List<Person>();
        public PeopleController()
        {
            people.Add(new Person
            {
                Fname ="Rahul",
                Lname = "Jangir",
                Id = 1
            });

            people.Add(new Person
            {
                Fname = "Satyam",
                Lname = "Jagtap",
                Id = 2
            });

            people.Add(new Person
            {
                Fname = "Rushi",
                Lname = "jain",
                Id = 3
            });

            people.Add(new Person
            {
                Fname = "Ram",
                Lname = "Jangir",
                Id = 4
            });

            people.Add(new Person
            {
                Fname = "Harsh",
                Lname = "Shrama",
                Id = 5
            });
        }

        // GET: api/People
        public List<Person> Get()
        {
            return people;
        }

        // GET: api/People/5
        public Person Get(int id)
        {
            return people.Where(x => x.Id == id).FirstOrDefault();
        }

        // POST: api/People
        public void Post(Person val)
        {
            people.Add(val);
        }

       

        // DELETE: api/People/5
        public void Delete(int id)
        {
        }
    }
}
