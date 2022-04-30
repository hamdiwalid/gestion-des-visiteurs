using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using backend.Models;
namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssistantController : Controller
    {
        private readonly IConfiguration? _configuration;
        public AssistantController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                             Select * from 
                            dbo.[User]
                            where role = 'assistant'
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
    }
}
