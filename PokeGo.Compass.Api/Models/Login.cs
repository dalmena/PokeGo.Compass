using System;
using PokeGo.Compass.Core.Models;

namespace PokeGo.Compass.Api.Models
{
    public class Login : ILogin
    {
        public string Password { get; set; }
        public string Username { get; set; }
    }
}
