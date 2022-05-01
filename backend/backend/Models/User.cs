using System.Data;

namespace backend.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string? identifiant { get; set; } = string.Empty;
        public string? nom { get; set; } = string.Empty;
        public string? prenom { get; set; } = string.Empty;
        public string? motpasse { get; set; } = string.Empty;
        public string? role { get; set; } = string.Empty;
        public string? CIN { get; set; } = string.Empty;
        public int? SocieteId { get; set; } = null;

        public static implicit operator User(DataRow v)
        {
            throw new NotImplementedException();
        }
    }
}
