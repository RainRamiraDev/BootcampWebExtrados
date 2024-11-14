using System;
using System.Collections.Generic;
using Dapper;
using MySqlConnector;
using UserDao.Entity;

namespace UserDao.Dao
{
    public class UsuarioDao
    {
        //Reemplazar los datos de la Bd segun Corresponda!
        private readonly string connectionString = "Server=127.0.0.1;Database=tarea3back;Uid=root;Password=1234";

        private readonly string QueryGetById = "SELECT * FROM Usuarios WHERE Id = @id";
        private readonly string QueryGetAll = "SELECT * FROM Usuarios";
        private readonly string QueryInsert = "INSERT INTO Usuarios (Nombre, Edad) VALUES (@Nombre, @Edad)";
        private readonly string QueryUpdate = "UPDATE Usuarios SET Nombre = @Nombre, Edad = @Edad WHERE Id = @Id";
        private readonly string QueryDelete = "UPDATE Usuarios SET Activo = 0 WHERE Id = @id";

        public Usuario GetById(int id)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var usuario = connection.QueryFirstOrDefault<Usuario>(QueryGetById, new { id });

                if (usuario == null || usuario.Activo == false)
                {
                    return null; // Retorna null si el usuario no existe o está inactivo
                }

                return usuario;
            }
        }
        // Método para obtener todos los usuarios
        public IEnumerable<Usuario> GetAll()
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var usuarios = connection.Query<Usuario>(QueryGetAll);
                return usuarios;
            }
        }

        // Método para insertar un nuevo usuario
        public int Insert(Usuario usuario)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var affectedRows = connection.Execute(QueryInsert, new { usuario.Nombre, usuario.Edad });
                return affectedRows; // Devuelve el número de filas afectadas
            }
        }


        // Método para actualizar un usuario existente
        public int Update(Usuario usuario)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var affectedRows = connection.Execute(QueryUpdate, new { usuario.Nombre, usuario.Edad, usuario.Id });
                return affectedRows; // Devuelve el número de filas afectadas
            }
        }

        // Método para "eliminar" un usuario por Id (eliminación lógica)
        public int Delete(int id)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var affectedRows = connection.Execute(QueryDelete, new { id });
                return affectedRows; // Devuelve el número de filas afectadas (usuarios marcados como eliminados)
            }
        }

    }
}
