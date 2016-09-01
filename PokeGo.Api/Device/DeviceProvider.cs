using PokeGo.Api.CSV;
using System;
using System.Collections.Generic;
using System.IO;

namespace PokeGo.Api.Device
{
    public interface IDeviceProvider
    {
        IDevice GetAny();
    }

    public class DeviceProvider : IDeviceProvider
    {
        private readonly string DEVICE_SOURCE_PATH = Directory.GetCurrentDirectory() + @"../../../Resources/device info.csv";

        private IList<Device> _devices;
        private ICsvReader _csvReader;
        private IDeviceUniqueIdGenerator _uniqueIdGenerator;

        public DeviceProvider(ICsvReader csvReader, IDeviceUniqueIdGenerator uniqueIdGenerator)
        {
            _csvReader = csvReader;
            _uniqueIdGenerator = uniqueIdGenerator;

            LoadDevices();
        }

        public IDevice GetAny()
        {
            var random = new Random(DateTime.Now.Millisecond);
            var randomNumber = random.Next(0, _devices.Count - 1);
            var device = _devices[randomNumber];
            device.DeviceId = _uniqueIdGenerator.Generate();
            return device;
        }

        private void LoadDevices()
        {
            _devices = new List<Device>();

            _csvReader.ReadLinesFrom(DEVICE_SOURCE_PATH, columns => _devices.Add(BuildDeviceFromColumns(columns)));
        }
        
        private Device BuildDeviceFromColumns(string[] columns)
        {
            return new Device
            {
                DeviceId = _uniqueIdGenerator.Generate(),
                AndroidBoardName = columns[1],
                AndroidBootloader = columns[2],
                DeviceBrand = columns[3],
                DeviceModel = columns[4],
                DeviceModelIdentifier = columns[5],
                DeviceModelBoot = columns[6],
                HardwareManufacturer = columns[7],
                HardwareModel = columns[8],
                FirmwareBrand = columns[9],
                FirmwareTags = columns[10],
                FirmwareType = columns[11],
                FirmwareFingerprint = columns[12]
            };
        }
    }
}
