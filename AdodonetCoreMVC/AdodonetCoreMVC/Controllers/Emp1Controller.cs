using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using AdodonetCoreMVC.Data;
using AdodonetCoreMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace AdodonetCoreMVC.Controllers
{
    public class Emp1Controller : Controller
    {

        private ApplicationDbContext _context;

        public Emp1Controller(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: Emp1Controller
        string connstring = "Data Source=192.168.50.95;Initial Catalog=sprathipati;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False ";
        [HttpGet]
        public ActionResult Index()
        {
            DataTable table = new DataTable();
            using (SqlConnection connection = new SqlConnection(connstring))
            {
                connection.Open();
                var sql = "select * from Emp1";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                //adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                adapter.Fill(table);
            }
            return View(table);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new Emp1());
        }

        // POST: Emp1Controller/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Emp1 emp1)
        {
            using (SqlConnection connection = new SqlConnection(connstring))
            {
                connection.Open();
                var sql2 = "insert into Emp1(Empname,gender)values(@empname,@gender)";
                SqlCommand command = new SqlCommand(sql2, connection);
                command.Parameters.AddWithValue("@empname", emp1.Empname);
                command.Parameters.AddWithValue("@gender", emp1.gender);
                command.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }

        // GET: Emp1Controller/Edit/5
        public ActionResult Edit(int id)
        {
            Emp1 emp1 = new Emp1();
            DataTable table = new DataTable();
            using (SqlConnection connection = new SqlConnection(connstring))
            {
                connection.Open();
                var sql3 = "select * from Emp1 where Empid = @Empid";
                SqlDataAdapter adapter = new SqlDataAdapter(sql3, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@Empid", id);
                adapter.Fill(table);
            }
            if (table.Rows.Count == 1)
            {
                emp1.Empid = Convert.ToInt32(table.Rows[0][0].ToString());
                emp1.Empname = table.Rows[0][1].ToString();
                emp1.gender = table.Rows[0][2].ToString();
                return View(emp1);
            }
            else
            {
                return RedirectToAction("Index");
            }

        }

        // POST: Emp1Controller/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Emp1 emp1)
        {
            using (SqlConnection connection = new SqlConnection(connstring))
            {
                connection.Open();
                var sql2 = "Update Emp1 set Empname=@empname,gender = @gender where Empid = @empid";
                SqlCommand command = new SqlCommand(sql2, connection);
                command.Parameters.AddWithValue("@empid", emp1.Empid);
                command.Parameters.AddWithValue("@empname", emp1.Empname);
                command.Parameters.AddWithValue("@gender", emp1.gender);
                command.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }

        // GET: Emp1Controller/Delete/5
        public ActionResult Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connstring))
            {
                connection.Open();
                var sql2 = "delete from Emp1 where Empid = @empid";
                SqlCommand command = new SqlCommand(sql2, connection);
                command.Parameters.AddWithValue("@empid", id);
                command.ExecuteNonQuery();
            }

            return RedirectToAction("Index");
        }


        public ActionResult Details(int id)
        {
            Emp1 emp1 = new Emp1();
            DataTable table = new DataTable();
            using (SqlConnection connection = new SqlConnection(connstring))
            {
                connection.Open();
                var sql3 = "select * from Emp1 where Empid = @Empid";
                SqlDataAdapter adapter = new SqlDataAdapter(sql3, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@Empid", id);
                adapter.Fill(table);
            }
            if (table.Rows.Count == 1)
            {
                emp1.Empid = Convert.ToInt32(table.Rows[0][0].ToString());
                emp1.Empname = table.Rows[0][1].ToString();
                emp1.gender = table.Rows[0][2].ToString();
                return View(emp1);
            }
            else
            {
                return RedirectToAction("Index");
            }

        }
    }
}
