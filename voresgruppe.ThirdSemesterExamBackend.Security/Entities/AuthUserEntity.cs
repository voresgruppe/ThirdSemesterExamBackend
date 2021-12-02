namespace voresgruppe.ThirdSemesterExamBackend.Security.Models
{
    public class AuthUserEntity
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string HashedPassword { get; set; }
        public string Salt { get; set; }
    }
}