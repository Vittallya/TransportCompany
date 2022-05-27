using Models;

namespace TransportCompany.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public UserGroup UserGroup { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
