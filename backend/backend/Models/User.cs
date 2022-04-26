namespace backend.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Password { get; set; }
        public string? role { get; set; }
        public string? CIN { get; set; }
        public int? societe_id { get; set; }
    }
}
