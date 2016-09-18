namespace PokeGo.Compass.Core.Models
{
    public interface IDevice
    {
        string AndroidBoardName { get; }
        string AndroidBootLoader { get; }
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
}
