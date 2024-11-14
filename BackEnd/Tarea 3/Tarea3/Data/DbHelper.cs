using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using UserDao.Dao;
using UserDao.Entity;

namespace Tarea3.Data
{
    public class DbHelper
    {
        UsuarioDao usuarioDao;
        Usuario usuario;

        public DbHelper()
        {
            usuarioDao = new UsuarioDao();
            usuario = new Usuario();
        }

        //Traer todos los usuarios
        public void GetAll()
        {
            var usuarios = usuarioDao.GetAll();
            foreach (var usuario in usuarios)
            {
                Console.WriteLine($"\nId:{usuario.Id}\nNombre: {usuario.Nombre}\nEdad: {usuario.Edad}\nActivo: {usuario.Activo}");
            }
        }

        //Traer por Id
        public void GetById(int idBuscado)
        {
            var usuarioPorId = usuarioDao.GetById(idBuscado);

            if (usuarioPorId == null)
            {
                Console.WriteLine("El usuario no existe o está inactivo.");
            }
            else
            {
                Console.WriteLine($"\nUsuario encontrado\nNombre: {usuarioPorId.Nombre}\nEdad: {usuarioPorId.Edad}");
            }
        }

        //Incercion
        public void Insert(string nombre, int edad)
        {
            var nuevoUsuario = new Usuario { Nombre = nombre, Edad = edad };
            var rowsAffected = usuarioDao.Insert(nuevoUsuario);
            Console.WriteLine($"Filas afectadas por la inserción: {rowsAffected}");

        }

        //Actualizacion
        public void Update(int id, string nombre, int edad)
        {
            var usuarioParaActualizar = new Usuario { Id = id, Nombre = nombre, Edad = edad };
            var updateRows = usuarioDao.Update(usuarioParaActualizar);
            Console.WriteLine($"Filas afectadas por la actualización: {updateRows}");

        }

        //Eliminacion Logica
        public void Delete(int id)
        {
            var deleteRows = usuarioDao.Delete(id); // Marcar usuario como inactivo
            Console.WriteLine($"Filas afectadas por la eliminación lógica: {deleteRows}");
        }
    }
}
