namespace MovieRating.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public bool LoginSocialNetwork { get; set; }
    }
}
