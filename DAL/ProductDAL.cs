using CURDUsingADO.Models;
using System;
using System.Data.SqlClient;
using System.Collections.Generic;
namespace CURDUsingADO.DAL

{
    public class ProductDAL
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public ProductDAL()
        {
            con = new SqlConnection(Startup.ConnectionString);
        }

        public List<Product> GetAllProducts()
        {
            List<Product> plist = new List<Product>();
            string qry = "select * from Product";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Product p = new Product();
                    p.Pid = Convert.ToInt32(dr["Pid"]);
                    p.Pname = dr["Pname"].ToString();
                    p.Price = Convert.ToDouble(dr["Price"]);
                    plist.Add(p);
                }
            }
            con.Close();
            return plist;
        }
        public Product GetProductById(int id)
        {
            Product p = new Product();
            string qry = "select * from Product where Pid=@pid";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@pid", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    p.Pid = Convert.ToInt32(dr["Pid"]);
                    p.Pname = dr["Pname"].ToString();
                    p.Price = Convert.ToDouble(dr["Price"]);
                }
            }
            con.Close();
            return p;
        }

        public int AddProduct(Product prod)
        {
            string qry = "insert into Product values(@pname,@price)";
            cmd = new SqlCommand(qry, con);

            cmd.Parameters.AddWithValue("@pname", prod.Pname);
            cmd.Parameters.AddWithValue("@price", prod.Price);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int UpdateProduct(Product prod)
        {
            string qry = "update Product set Pname=@pname , Price=@price where Pid=@pid";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@pid", prod.Pid);
            cmd.Parameters.AddWithValue("@pname", prod.Pname);
            cmd.Parameters.AddWithValue("@price", prod.Price);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int DeleteProduct(int id)
        {
            string qry = "delete from Product where Pid=@pid";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@pid", id);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
    }
}
