namespace backend.Models
{
    public class Notification
    {
        public int id { get; set; }
        public string? etat { get; set; }
        public string? titre  { get; set; }
        public int user_id { get; set; }
        public int demande_id { get; set; }
        public int societe_id { get; set; }
    }
}
