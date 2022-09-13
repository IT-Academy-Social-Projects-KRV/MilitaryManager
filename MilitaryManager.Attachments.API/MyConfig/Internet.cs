using System;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;

namespace MilitaryManager.Attachments.API.MyConfig
{
    public static class Internet
    {
        [DllImport("wininet.dll")]
        static extern bool InternetGetConnectedState(ref InternetConnectionState lpdwFlags, int dwReserved);

        [Flags]
        enum InternetConnectionState : int
        {
            INTERNET_CONNECTION_MODEM = 0x1,
            INTERNET_CONNECTION_LAN = 0x2,
            INTERNET_CONNECTION_PROXY = 0x4,
            INTERNET_RAS_INSTALLED = 0x10,
            INTERNET_CONNECTION_OFFLINE = 0x20,
            INTERNET_CONNECTION_CONFIGURED = 0x40
        }

        static object _syncObj = new object();

        public static Boolean CheckConnection()
        {
            lock (_syncObj)
            {
                try
                {
                    InternetConnectionState flags = InternetConnectionState.INTERNET_CONNECTION_CONFIGURED | 0;
                    bool checkStatus = InternetGetConnectedState(ref flags, 0);

                    if (checkStatus)
                        return PingServer(new string[]
                                            {
                                                @"google.com",
                                                @"microsoft.com",
                                                @"ibm.com"
                                            });

                    return checkStatus;
                }
                catch
                {
                    return false;
                }
            }
        }

        public static bool PingServer(string[] serverList)
        {
            bool haveAnInternetConnection = false;
            Ping ping = new Ping();
            for (int i = 0; i < serverList.Length; i++)
            {
                PingReply pingReply = ping.Send(serverList[i]);
                haveAnInternetConnection = (pingReply.Status == IPStatus.Success);
                if (haveAnInternetConnection)
                    break;
            }

            return haveAnInternetConnection;
        }
    }
}