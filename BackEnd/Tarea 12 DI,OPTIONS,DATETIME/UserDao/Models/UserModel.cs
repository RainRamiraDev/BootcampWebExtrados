namespace UserDaoLib.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Contrasenia { get; set; }

        public UserModel(int id, string nombre, string email, string contrasenia)
        {
            Id = id;
            Nombre = nombre;
            Email = email;
            Contrasenia = contrasenia;
        }

        public UserModel()
        {
        }
    }
}
