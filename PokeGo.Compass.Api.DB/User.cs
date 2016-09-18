namespace PokeGo.Compass.Api.DB
{
    using Core.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using PokemonGo.RocketAPI.Enums;

    [Table("User")]
    public partial class User : IUser
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Username { get; set; }

        [Required]
        [StringLength(32)]
        public string Password { get; set; }

        [StringLength(2000)]
        public string LastPokeGoAuthKey { get; set; }

        [Required]
        [StringLength(32)]
        public string AuthKey { get; set; }

        public int DeviceId { get; set; }

        [Required]
        [StringLength(50)]
        public string PokeGoUsername { get; set; }

        [Required]
        [StringLength(50)]
        public string PokeGoPassword { get; set; }

        public int PokeGoAuthTypeId { get; set; }

        public virtual Device Device { get; set; }

        public AuthType PokeGoAuthType
        {
            get
            {
                return (AuthType)Enum.ToObject(typeof(AuthType), PokeGoAuthTypeId);
            }
        }

        IDevice IUser.Device
        {
            get
            {
                return Device;
            }
        }
    }
}
