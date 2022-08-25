using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Ingenieros_Commerce_Manager_v2._0
{
    public class conexionsql
    {
        public MySqlConnection conexion = new MySqlConnection("Server=localhost; Database=regsitro; Uid=root; Pwd=;");
        public MySqlCommand comandos = new MySqlCommand();
        public MySqlDataReader datos;
    }
}
