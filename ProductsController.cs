using _210940520098.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _210940520098.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        //public ActionResult Index()
        //{
            
            
        //   return View();

           
        //}

        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            SqlConnection connect = new SqlConnection();
            connect.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ExamDotNet;Integrated Security=True";
            connect.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select * from Table where ProductId=";
            Products products;
            try
            {
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                products = new Products
                {
                    ProductId = (int)dr["Product Id"],
                    ProductName = dr["Product Name"].ToString(),
                    Description = dr["Description"].ToString(),
                    CategoryName = dr["Category"].ToString(),
                    Rate = (decimal)dr["Rate"]
                };
                connect.Close();
                return View(products);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                connect.Close();
                return View();
            }
            

        }

        public ActionResult Index()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ExamDotNet;Integrated Security=True";
            cn.Open();
            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "select * from Table";
            List<Products> products = new List<Products>();
            SqlDataReader dr = command.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    products.Add(new Products
                    {
                        ProductId = dr.GetInt32(0),
                        ProductName = dr.GetString(1),
                        Rate = dr.GetDecimal(3),
                        Description = dr.GetString(4),
                        CategoryName = dr.GetString(5)
                    });

                }
                dr.Close();
                return View(products);
            }
            catch(Exception ex)
            {
                cn.Close();
                return View(products);
            }
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int id)
        {
            SqlConnection connect = new SqlConnection();
            connect.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ExamDotNet;Integrated Security=True";
            connect.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select * from Table where ProductId=" + id;
            Products products;
            try
            {
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                products = new Products
                {
                    ProductId = (int)dr["Product Id"],
                    ProductName = dr["Product Name"].ToString(),
                    Description = dr["Description"].ToString(),
                    CategoryName = dr["Category"].ToString(),
                    Rate = (decimal)dr["Rate"]
                };
                connect.Close();
                return View(products);

            }
           
              catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                connect.Close();
                return View();
            }

        }
            
        

        // POST: Products/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    ActionResult RedirectToAction(string v)
    {
        throw new NotImplementedException();
    }

    // GET: Products/Delete/5
    public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Products/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
