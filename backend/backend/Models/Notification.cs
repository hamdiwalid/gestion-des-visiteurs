namespace backend.Models
{
    public class Notification
    {
        public int id { get; set; }
        public string? etat { get; set; } = string.Empty;
        public string? titre  { get; set; } = string.Empty;
        public virtual User? User { get; set; }
        public int UserId { get; set; }
        public virtual Societe? Societe { get; set; }
        public int Societeid { get; set; }


    }
}
