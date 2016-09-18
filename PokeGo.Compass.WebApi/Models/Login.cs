using PokeGo.Compass.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace PokeGo.Compass.WebApi.Models
{
    public class Login : ILogin
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}