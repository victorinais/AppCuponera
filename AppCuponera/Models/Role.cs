using System.Text.Json.Serialization;

namespace AppCuponera.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        [JsonIgnore]
        public List<UserRole>? UserRoles { get; set; }
    }
}