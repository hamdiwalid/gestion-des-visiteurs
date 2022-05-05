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
                           where etat='nonpresent'
                            ";
            DataTable dt = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("AppCon");
            SqlDataReader sqlDataReader;
            using (SqlConnection Con = new SqlConnection(sqlDataSource))
            {
                Con.Open();
                using (SqlCommand cmd = new SqlCommand(query, Con))
                {
                    //cmd.Parameters.AddWithValue("@datenew", new DateTime());
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
                             values(@description,@motive,@user_id,@societe_id,@date,@etat)
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
                    cmd.Parameters.AddWithValue("@date", demande.date);
                    cmd.Parameters.AddWithValue("@etat", demande.etat);

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
                             set etat=@etat
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
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@etat", demande.etat);
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
        [HttpGet("{id}")]
        public JsonResult GetById(int id)
        {
            string query = @"
                             Select * from dbo.[Demandes]
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
            return new JsonResult(dt);
        }
        [HttpGet]
        [Route("historique")]
        public JsonResult GetAll()
        {
            string query = @"
                             Select * from 
                            dbo.[Demandes]
                           where etat='absent' or etat='present'
                            ";
            DataTable dt = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("AppCon");
            SqlDataReader sqlDataReader;
            using (SqlConnection Con = new SqlConnection(sqlDataSource))
            {
                Con.Open();
                using (SqlCommand cmd = new SqlCommand(query, Con))
                {
                    //cmd.Parameters.AddWithValue("@datenew", new DateTime());
                    sqlDataReader = cmd.ExecuteReader();
                    dt.Load(sqlDataReader);
                    sqlDataReader.Close();
                    Con.Close();
                }

            }
            return new JsonResult(dt);
        }
        [HttpGet]
        [Route("hsociete")]
        public JsonResult GetAllS(int id)
        {
            string query = @"
                             Select * from 
                            dbo.[Demandes]
                           where SocieteId=@id and etat='absent' or etat='present'
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
            return new JsonResult(dt);
        }
        [HttpGet]
        [Route("dsociete")]
        public JsonResult GetAllDS(int id)
        {
            string query = @"
                             Select * from 
                            dbo.[Demandes]
                           where SocieteId=@id and etat='nonpresent'
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
            return new JsonResult(dt);
        }
    }
}
