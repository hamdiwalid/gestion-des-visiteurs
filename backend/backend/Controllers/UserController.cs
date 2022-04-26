using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using backend.Models;

namespace backend.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
       private readonly IConfiguration? _configuration;
        public UserController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        public JsonResult Get()
        {
            string query =@"
                             Select * from 
                            dbo.[User]
                            ";
            DataTable dt = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("AppCon");
            SqlDataReader sqlDataReader;
            using (SqlConnection Con = new SqlConnection(sqlDataSource))
            {
                Con.Open();
                using (SqlCommand cmd = new SqlCommand(query,Con))
                {
                    sqlDataReader = cmd.ExecuteReader();
                    dt.Load(sqlDataReader);
                    sqlDataReader.Close();
                    Con.Close();
                }

            }
            return new JsonResult(dt);
        }
        [HttpPost]
        public JsonResult Post(User user)
        {
            string query = @"
                             Insert into dbo.[User]
                             values(@userName,@firstName,@lastName,@password,@role,@cin,@societe_id)
                            ";
            DataTable dt = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("AppCon");
            SqlDataReader sqlDataReader;
            using (SqlConnection Con = new SqlConnection(sqlDataSource))
            {
                Con.Open();
                using (SqlCommand cmd = new SqlCommand(query, Con))
                {
                    cmd.Parameters.AddWithValue("@UserName", user.UserName);
                    cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", user.LastName);
                    cmd.Parameters.AddWithValue("@Password", user.Password);
                    cmd.Parameters.AddWithValue("@role", user.role);
                    cmd.Parameters.AddWithValue("@CIN", user.CIN);
                    cmd.Parameters.AddWithValue("@societe_id", user.societe_id);
                    sqlDataReader = cmd.ExecuteReader();
                    dt.Load(sqlDataReader);
                    sqlDataReader.Close();
                    Con.Close();
                }

            }
            return new JsonResult("Ajoute avec succès");
        }
        [HttpPut]
        public JsonResult Put(User user)
        {
            string query = @"
                             Update dbo.[User]
                             set userName = @userName, firstName = @firstName, lastName = @lastName,password = @password,role = @role,cin = @cin
                             where UserId=@UserId
                            ";
            DataTable dt = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("AppCon");
            SqlDataReader sqlDataReader;
            using (SqlConnection Con = new SqlConnection(sqlDataSource))
            {
                Con.Open();
                using (SqlCommand cmd = new SqlCommand(query, Con))
                {
                    cmd.Parameters.AddWithValue("@UserId", user.UserId);
                    cmd.Parameters.AddWithValue("@UserName", user.UserName);
                    cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", user.LastName);
                    cmd.Parameters.AddWithValue("@Password", user.Password);
                    cmd.Parameters.AddWithValue("@role", user.role);
                    cmd.Parameters.AddWithValue("@CIN", user.CIN);
                    sqlDataReader = cmd.ExecuteReader();
                    dt.Load(sqlDataReader);
                    sqlDataReader.Close();
                    Con.Close();
                }

            }
            return new JsonResult("Modifie avec succès");
        }
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            string query = @"
                             Delete dbo.[User]
                             where UserId=@UserId
                            ";
            DataTable dt = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("AppCon");
            SqlDataReader sqlDataReader;
            using (SqlConnection Con = new SqlConnection(sqlDataSource))
            {
                Con.Open();
                using (SqlCommand cmd = new SqlCommand(query, Con))
                {
                    cmd.Parameters.AddWithValue("@UserId", id);
                    sqlDataReader = cmd.ExecuteReader();
                    dt.Load(sqlDataReader);
                    sqlDataReader.Close();
                    Con.Close();
                }

            }
            return new JsonResult("Supprimer avec succès");
        }
    }
}
