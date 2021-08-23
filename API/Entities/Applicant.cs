namespace API.Entities
{
    public class Applicant
    {
        public int Id { get; set; }
        public string UserName { get; set; }

        public string Email;

        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}