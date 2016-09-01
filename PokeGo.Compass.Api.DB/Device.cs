namespace PokeGo.Compass.Api.DB
{
    using Core.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Device")]
    public partial class Device : IDevice
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string AndroidBoardName { get; set; }

        [StringLength(50)]
        public string AndroidBootLoader { get; set; }

        [StringLength(50)]
        public string DeviceBrand { get; set; }

        [StringLength(50)]
        public string DeviceId { get; set; }

        [StringLength(50)]
        public string DeviceModel { get; set; }

        [StringLength(50)]
        public string DeviceModelBoot { get; set; }

        [StringLength(50)]
        public string DeviceModelIdentifier { get; set; }

        [StringLength(50)]
        public string FirmwareBrand { get; set; }

        [StringLength(50)]
        public string FirmwareFingerprint { get; set; }

        [StringLength(50)]
        public string FirmwareTags { get; set; }

        [StringLength(50)]
        public string FirmwareType { get; set; }

        [StringLength(50)]
        public string HardwareManufacturer { get; set; }

        [StringLength(50)]
        public string HardwareModel { get; set; }

        public virtual User User { get; set; }
    }
}
