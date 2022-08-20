using Castle.Core.Internal;
using Microsoft.AspNetCore.Mvc;
using ListUser_net6.DB;
using ListUser_net6.Models;

namespace ListUser_net6.Controllers
{
    public class UserController : Controller
    {
        private DBContext dbContext;

        public UserController(DBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult List()
        {
            // select * from Persons;
            List<Person> persons = dbContext.Persons.ToList();

            // pass data from controller to view
            // ViewData["persons"] = persons;

            return View(persons);
        }

        public IActionResult Filter(string key)
        {

            if (key.IsNullOrEmpty())
            {
                var allPerson = dbContext.Persons.ToList();
                return View("List", allPerson);
            }

            key = key.ToLower();
            var persons = dbContext.Persons
                .Where(p => p.FirstName.ToLower().Contains(key) || p.LastName.ToLower().Contains(key) ||
                            p.JobTitle.ToLower().Contains(key)).ToList();

            if (persons.Count <= 0) return View("List", persons);

            // replace keyword
            foreach (var person in persons)
            {
                HighlightKeyword(person, key);
            }

            return View("List", persons);
        }

        private static void HighlightKeyword(Person person, string key)
        {
            if(key.IsNullOrEmpty()) return;

            person.FirstName = ExecuteReplace(person.FirstName, key);
            person.LastName = ExecuteReplace(person.LastName, key);
            person.JobTitle = ExecuteReplace(person.JobTitle, key);
        }

        private static string ExecuteReplace(string original, string key)
        {
            if (!original.ToLower().Contains(key)) return original;

            var indexBegin = original.ToLower().IndexOf(key, StringComparison.Ordinal);

            var substring = original.Substring(indexBegin, key.Length);

            return original.Replace(substring, "<mark>" + substring + "</mark>");
        }
    }
}

