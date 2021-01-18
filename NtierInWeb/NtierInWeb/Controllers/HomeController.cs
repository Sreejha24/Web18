using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NtierInWeb.Data;
using NtierInWeb.Models;

namespace NtierInWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration, ApplicationDbContext context)
        {
            _logger = logger;
            _configuration = configuration;
            _context = context;
        }

        public IActionResult Index()
        {

            EmployeeBAL employeeBAL = new EmployeeBAL();

            var details = employeeBAL.ReadEmployee();


            IList<Employee> employees = new List<Employee>();
            foreach (DataRow row in details.Tables[0].Rows)
            {
                Employee employee = new Employee()
                {
                    EmployeeID = int.Parse(row["EmployeeID"].ToString()),
                    FirstName = row["FirstName"].ToString(),
                    LastName  = row["LastName"].ToString(),
                    Email     = row["Email"].ToString(),
                    City      = row["City"].ToString(),
                    Mobile    = long.Parse(row["Mobile"].ToString())
                };
                employees.Add(employee);
            }
            return View(employees);
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
