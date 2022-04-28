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
        public virtual Societe? Societe { get; set; }
        public int? SocieteId { get; set; }

        public static implicit operator User(DataRow v)
        {
            throw new NotImplementedException();
        }
    }
}
