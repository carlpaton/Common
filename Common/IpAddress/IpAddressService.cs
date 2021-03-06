﻿using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace Common.IpAddress
{
    /// <summary>
    /// This was too hard to mock and test, use case for this service is a hack anyway!
    /// </summary>
    public class IpAddressService
    {
        public string GetLocalIPv4()
        {
            foreach (var networkInterface in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (networkInterface.NetworkInterfaceType.Equals(NetworkInterfaceType.Ethernet)
                    && networkInterface.OperationalStatus == OperationalStatus.Up)
                {
                    var unicastIPAddressInformation = networkInterface
                        .GetIPProperties()
                        .UnicastAddresses
                        .Where(x => x.Address.AddressFamily.Equals(AddressFamily.InterNetwork))
                        .FirstOrDefault();

                    if (unicastIPAddressInformation != null && unicastIPAddressInformation.Address != null)
                        return unicastIPAddressInformation.Address.ToString();
                }
            }
            return "";
        }

        /// <summary>
        /// Alternative : http://icanhazip.com/
        /// </summary>
        /// <returns></returns>
        public string GetPublicIP()
        {
            return new WebClient()
                .DownloadString("http://checkip.amazonaws.com")
                .Trim();
        }
    }
}
