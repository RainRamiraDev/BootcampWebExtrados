namespace UserDaoLib.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public int Edad { get; set; }

        public UserModel(int id, string nombre, string email, int edad)
        {
            Id = id;
            Nombre = nombre;
            Email = email;
            Edad = edad;
        }
        public UserModel()
        {
            
        }
    }
}
