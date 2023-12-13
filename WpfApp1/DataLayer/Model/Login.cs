using DataLayer.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Model
{
    [Table("login")]
    public class login
    {
        [Key]
        [MaxLength(50)]
        public string Username { get; set; }
        [MaxLength(50)]
        public string Password { get; set; }

        public string Role { get; set; }

        public static string? GetRole(string username, string password)
        {
            using var context = new TMSDBContext();
            var login = context.Login.FirstOrDefault(l => l.Username == username);
            if (login != null)
            {
                if (login.Password == password)
                {
                    string role = login.Role;
                    return role;
                }
            }
            return null;
        }
    }
}
