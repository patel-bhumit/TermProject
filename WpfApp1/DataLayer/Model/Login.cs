using DataLayer.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Model
{
    [Table("Login")]
    public class Login: ILogin
    {
        [Key]
        [MaxLength(50)]
        public string Username { get; set; }
        [MaxLength(50)]
        public string Password { get; set; }

        public string Role { get; set; }

        public string? GetRole(string username, string password)
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
