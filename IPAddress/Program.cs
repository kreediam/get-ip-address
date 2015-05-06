using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace IPAddresss
{
    class Program
    {
        static void Main(string[] args)
        {
            //string networkInterfaceName = "Wireless Network Connection";
            string networkInterfaceName = "Local Area Connection";
            string ip = new Program().GetIpAddress(networkInterfaceName);

            Console.WriteLine("{0}: {1}", networkInterfaceName, ip);
            Console.WriteLine("Press enter to exit.");
            Console.ReadLine();
        }

        public string GetIpAddress(string interfaceName)
        {
            NetworkInterface networkInterface = NetworkInterface.GetAllNetworkInterfaces().Where(x => x.Name == interfaceName).FirstOrDefault();
            if (networkInterface == null)
                return null;

            var properties = networkInterface.GetIPProperties();
            var ipAddressInfo = properties.UnicastAddresses.Where(x => x.PrefixLength == 22).FirstOrDefault();
            if (ipAddressInfo == null)
                return null;

            return ipAddressInfo.Address.ToString();
        }
    }
}
