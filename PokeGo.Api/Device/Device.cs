using System;
using PokemonGo.RocketAPI.Enums;

namespace PokeGo.Api.Device
{
    public interface IDevice
    {
        string AndroidBoardName { get; }
        string AndroidBootloader { get; }
        string DeviceBrand { get; }
        string DeviceId { get; }
        string DeviceModel { get; }
        string DeviceModelBoot { get; }
        string DeviceModelIdentifier { get; }
        string FirmwareBrand { get; }
        string FirmwareFingerprint { get; }
        string FirmwareTags { get; }
        string FirmwareType { get; }
        string HardwareManufacturer { get; }
        string HardwareModel { get; }
    }

    public class Device : IDevice
    {
        public string AndroidBoardName { get; set; }
        public string AndroidBootloader { get; set; }
        public string DeviceBrand { get; set; }
        public string DeviceId { get; set; }
        public string DeviceModel { get; set; }
        public string DeviceModelBoot { get; set; }
        public string DeviceModelIdentifier { get; set; }
        public string FirmwareBrand { get; set; }
        public string FirmwareFingerprint { get; set; }
        public string FirmwareTags { get; set; }
        public string FirmwareType { get; set; }
        public string HardwareManufacturer { get; set; }
        public string HardwareModel { get; set; }
    }
}
