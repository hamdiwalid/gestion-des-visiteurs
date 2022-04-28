namespace backend.Models
{
    public class Demande
    {
        public int id { get; set; }
        public string? description { get; set; } = string.Empty;
        public string? motive { get; set; } = string.Empty;
        public virtual User? User { get; set; }
        public int? UserId { get; set; }
        public virtual Societe? Societe { get; set; }
        public int? SocieteId { get; set; }



    }
}
