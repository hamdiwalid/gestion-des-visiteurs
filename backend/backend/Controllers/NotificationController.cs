using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using backend.Models;
namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationController : Controller
    {
        private readonly IConfiguration? _configuration;
        public NotificationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                             Select * from 
                            dbo.[Notifications]
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
        public JsonResult Post(Notification notification)
        {
            string query = @"
                             Insert into dbo.[Notifications]
                             values(@etat,@titre,@user_id,@demande_id,@societe_id)
                            ";
            DataTable dt = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("AppCon");
            SqlDataReader sqlDataReader;
            using (SqlConnection Con = new SqlConnection(sqlDataSource))
            {
                Con.Open();
                using (SqlCommand cmd = new SqlCommand(query, Con))
                {
                    cmd.Parameters.AddWithValue("@etat", notification.etat);
                    cmd.Parameters.AddWithValue("@titre", notification.titre);
                    cmd.Parameters.AddWithValue("@user_id", notification.UserId);
                    cmd.Parameters.AddWithValue("@demande_id", notification.Demandeid);
                    cmd.Parameters.AddWithValue("@societe_id", notification.Societeid);

                    sqlDataReader = cmd.ExecuteReader();
                    dt.Load(sqlDataReader);
                    sqlDataReader.Close();
                    Con.Close();
                }

            }
            return new JsonResult("Ajoute avec succès");
        }
        [HttpPut]
        public JsonResult Put(Notification notification, int id)
        {
            string query = @"
                             Update dbo.[Notifications]
                             set etat=@etat,titre=@titre,user_id=@user_id,demande_id=@demande_id,societe_id=@societe_id
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
                    cmd.Parameters.AddWithValue("@id", notification.id);
                    cmd.Parameters.AddWithValue("@etat", notification.etat);
                    cmd.Parameters.AddWithValue("@titre", notification.titre);
                    cmd.Parameters.AddWithValue("@user_id", notification.User);
                    cmd.Parameters.AddWithValue("@demande_id", notification.Demande);
                    cmd.Parameters.AddWithValue("@societe_id", notification.Societe);
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
                             Delete dbo.[Notifications]
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
