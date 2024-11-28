namespace UserDaoLib.Dto
{
    public class UserDbReadDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Contrasenia { get; set; }

        public UserDbReadDto(int id, string nombre, string email, string contrasenia)
        {
            Id = id;
            Nombre = nombre;
            Email = email;
            Contrasenia = contrasenia;
        }

        public UserDbReadDto()
        {
        }
    }
}
