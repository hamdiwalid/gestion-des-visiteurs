namespace backend.Models
{
    public class Demande
    {
        public int id { get; set; }
        public string? description { get; set; }
        public string? motive { get; set; }
        public int user_id { get; set; }
        public int societe_id  { get; set; }

    }
}
