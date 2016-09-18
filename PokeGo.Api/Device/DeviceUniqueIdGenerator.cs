﻿using System;
using System.Linq;
using System.Security.Cryptography;

namespace PokeGo.Api.Device
{
    public interface IDeviceUniqueIdGenerator
    {
        string Generate();
    }

    public class DeviceUniqueIdGenerator : IDeviceUniqueIdGenerator
    {
        public string Generate()
        {
            string alphabet = "0123456789abcdef";
            int length = 16;

            var outOfRange = byte.MaxValue + 1 - (byte.MaxValue + 1) % alphabet.Length;

            return string.Concat(
                Enumerable
                    .Repeat(0, int.MaxValue)
                    .Select(e => RandomByte())
                    .Where(randomByte => randomByte < outOfRange)
                    .Take(length)
                    .Select(randomByte => alphabet[randomByte % alphabet.Length])
                );
        }

        private static byte RandomByte()
        {
            using (var randomizationProvider = new RNGCryptoServiceProvider())
            {
                var randomBytes = new byte[1];
                randomizationProvider.GetBytes(randomBytes);
                return randomBytes.Single();
            }
        }
    }
}
