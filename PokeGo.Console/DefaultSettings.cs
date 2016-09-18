﻿using System;
using PokemonGo.RocketAPI;
using PokemonGo.RocketAPI.Enums;

namespace PokeGo.Console
{
    public class DefaultSettings : ISettings
    {
        public string AndroidBoardName { get; set; }
        public string AndroidBootloader { get; set; }
        public AuthType AuthType { get; set; }
        public double DefaultAltitude { get; set; }
        public double DefaultLatitude { get; set; }
        public double DefaultLongitude { get; set; }
        public string DeviceBrand { get; set; }
        public string DeviceId { get; set; }
        public string DeviceModel { get; set; }
        public string DeviceModelBoot { get; set; }
        public string DeviceModelIdentifier { get; set; }
        public string FirmwareBrand { get; set; }
        public string FirmwareFingerprint { get; set; }
        public string FirmwareTags { get; set; }
        public string FirmwareType { get; set; }
        public string GooglePassword { get; set; }
        public string GoogleRefreshToken { get; set; }
        public string GoogleUsername { get; set; }
        public string HardwareManufacturer { get; set; }
        public string HardwareModel { get; set; }
        public string PtcPassword { get; set; }
        public string PtcUsername { get; set; }
    }
}
