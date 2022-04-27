namespace backend.Models
{
    public class Societe
    {
        public int id { get; set; }
        public string? nom { get; set; } = string.Empty;
        public string? description { get; set; } = string.Empty;
        public string? matricule { get; set; } = string.Empty;
    }
}
