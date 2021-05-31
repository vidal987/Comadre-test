namespace teste_comadre.Models
{
    public class User : BaseEntity
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public Account Account { get; set; }
    }
}