using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using backend.Models;
namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DemandeController : Controller
    {
        private readonly IConfiguration? _configuration;
        public DemandeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                             Select * from 
                            dbo.[Demandes]
                            ";
            DataTable dt = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("AppCon");
            SqlDataReader sqlDataReader;
            using (SqlConnection Con = new SqlConnection(sqlDataSource))
            {
                Con.Open();
                using (SqlCommand cmd = new SqlCommand(query, Con))
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
        public JsonResult Post(Demande demande)
        {
            string query = @"
                             Insert into dbo.[Demandes]
                             values(@description,@motive,@user_id,@societe_id)
                            ";
            DataTable dt = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("AppCon");
            SqlDataReader sqlDataReader;
            using (SqlConnection Con = new SqlConnection(sqlDataSource))
            {
                Con.Open();
                using (SqlCommand cmd = new SqlCommand(query, Con))
                {
                    cmd.Parameters.AddWithValue("@description", demande.description);
                    cmd.Parameters.AddWithValue("@motive", demande.motive);
                    cmd.Parameters.AddWithValue("@user_id", demande.UserId);
                    cmd.Parameters.AddWithValue("@societe_id", demande.SocieteId);

                    sqlDataReader = cmd.ExecuteReader();
                    dt.Load(sqlDataReader);
                    sqlDataReader.Close();
                    Con.Close();
                }

            }
            return new JsonResult("Ajoute avec succès");
        }
        [HttpPut]
        public JsonResult Put(Demande demande, int id)
        {
            string query = @"
                             Update dbo.[Demandes]
                             set description=@description,motive=@motive,user_id=@user_id,societe_id=@societe_id
                             where id = @id
                            ";
            DataTable dt = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("AppCon");
            SqlDataReader sqlDataReader;
            using (SqlConnection Con = new SqlConnection(sqlDataSource))
            {
                Con.Open();
                using (SqlCommand cmd = new SqlCommand(query, Con))
                {
                    cmd.Parameters.AddWithValue("@id", demande.id);
                    cmd.Parameters.AddWithValue("@description", demande.description);
                    cmd.Parameters.AddWithValue("@motive", demande.motive);
                    cmd.Parameters.AddWithValue("@user_id", demande.User);
                    cmd.Parameters.AddWithValue("@societe_id", demande.Societe);
                    sqlDataReader = cmd.ExecuteReader();
                    dt.Load(sqlDataReader);
                    sqlDataReader.Close();
                    Con.Close();
                }

            }
            return new JsonResult("Modifier avec succès");
        }
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            string query = @"
                             Delete dbo.[Demandes]
                             where id=@id
                            ";
            DataTable dt = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("AppCon");
            SqlDataReader sqlDataReader;
            using (SqlConnection Con = new SqlConnection(sqlDataSource))
            {
                Con.Open();
                using (SqlCommand cmd = new SqlCommand(query, Con))
                {
                    cmd.Parameters.AddWithValue("@id", id);
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
