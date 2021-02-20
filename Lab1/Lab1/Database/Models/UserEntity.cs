namespace Lab1.Database.Models
{
    public class UserEntity
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string PasswordHash { get; set; }
    }
}
