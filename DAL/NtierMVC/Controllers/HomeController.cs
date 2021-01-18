using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NtierMVC.Data;
using NtierMVC.Models;

namespace NtierMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger,IConfiguration configuration, ApplicationDbContext context)
        {
            _logger = logger;
            _configuration = configuration;
            _context = context;
        }

        public IActionResult Index()
        {
            PersonBAL BAL = new PersonBAL();
            var details = BAL.ReadPerson();
            IList<Person> list = new List<Person>();
            foreach (DataRow row in details.Tables[0].Rows)
            {
                Person person = new Person()
                {
                    PersonID = int.Parse(row["PersonId"].ToString()),
                    FirstName = row["FirstName"].ToString(),
                    LastName = row["LastName"].ToString(),
                    Email = row["Email"].ToString(),
                    Mobile = long.Parse(row["Mobile"].ToString())
                };
                list.Add(person);
            }
            return View(list);
        }
        [HttpGet]
        public async Task<IActionResult> Index(string PersonSearch)
        {
            ViewData["GetPersonDetails"] = PersonSearch;
            var sql = from a in _context.Person select a;
            if(!string.IsNullOrEmpty(PersonSearch))
            {
                sql = sql.Where(a => a.FirstName.Contains(PersonSearch)||a.LastName.Contains(PersonSearch)|| a.Email.Contains(PersonSearch));
            }
            return View(await sql.AsNoTracking().ToListAsync()); 
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
