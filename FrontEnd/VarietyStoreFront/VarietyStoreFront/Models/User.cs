using VarietyStoreFront.Enums;

namespace VarietyStoreFront.Models {
    public class User {
        public int id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public RoleUser Role { get; set; }

    }
}
