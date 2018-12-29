using System;
using System.Collections;
using System.ComponentModel;
using System.Net;
using System.Runtime.InteropServices;

namespace CertificatesModel.Authorization
{
    internal class NetworkConnection : IDisposable
    {
        string _networkName;

        public NetworkConnection(string networkName, NetworkCredential credentials)
        {
            // Получаем существующий перечень открытых соединений
            ServerEnum shareList = new ServerEnum(ResourceScope.Connected, ResourceType.Disk, ResourceUsage.RESOURCEUSAGE_ALL, ResourceDisplayType.Share);

            //закрываем их все, чтобы не было конфликта
            foreach (var item in shareList)
            {
                var result2 = WNetCancelConnection2(item.ToString(), 0, true);
            }

            _networkName = networkName;

            var netResource = new NetResource()
            {
                Scope = ResourceScope.GlobalNetwork,
                ResourceType = ResourceType.Disk,
                DisplayType = ResourceDisplayType.Share,
                RemoteName = networkName
            };

            var userName = string.IsNullOrEmpty(credentials.Domain)
                ? credentials.UserName
                : string.Format(@"{0}\{1}", credentials.Domain, credentials.UserName);

            var result = WNetAddConnection2(
                netResource,
                credentials.Password,
                userName,
                0);

            if (result == 1219)
            {
                result = WNetCancelConnection2(networkName, 0, true);
                result = WNetAddConnection2(
                netResource,
                credentials.Password,
                userName,
                0);
            }

            switch (result)
            {
                case 0:
                    // Все прошло гладко
                    break;
                case 1219:
                    // Соединение к сетевому ресурсу уже открыто
                    throw new Win32Exception(result, "Соединение с сетевым ресурсом уже существует.");

                case 1326:
                    // Пароль или логин не верны
                    throw new Win32Exception(result, "Некорректный логин или пароль.");

                case 2202:
                    // логин не верны
                    throw new Win32Exception(result, "Некорректное имя пользователя.");

                default:
                    // Все прочие варианты
                    throw new Win32Exception(result, "Ошибка подключения к сетевому ресурсу.");

            }
        }

        ~NetworkConnection()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            WNetCancelConnection2(_networkName, 0, true);
        }

        [DllImport("mpr.dll")]
        private static extern int WNetAddConnection2(NetResource netResource,
            string password, string username, int flags);

        [DllImport("mpr.dll")]
        private static extern int WNetCancelConnection2(string name, int flags,
            bool force);

    }

    [StructLayout(LayoutKind.Sequential)]
    public class NetResource
    {
        public ResourceScope Scope;
        public ResourceType ResourceType;
        public ResourceDisplayType DisplayType;
        public int Usage;
        public string LocalName;
        public string RemoteName;
        public string Comment;
        public string Provider;
    }

    public enum ResourceScope : int
    {
        Connected = 1,
        GlobalNetwork,
        Remembered,
        Recent,
        Context
    };

    public enum ResourceType : int
    {
        Any = 0,
        Disk = 1,
        Print = 2,
        Reserved = 8,
    }

    public enum ResourceDisplayType : int
    {
        Generic = 0x0,
        Domain = 0x01,
        Server = 0x02,
        Share = 0x03,
        File = 0x04,
        Group = 0x05,
        Network = 0x06,
        Root = 0x07,
        Shareadmin = 0x08,
        Directory = 0x09,
        Tree = 0x0a,
        Ndscontainer = 0x0b
    }

    //========================================================================//

    public enum ResourceUsage
    {
        RESOURCEUSAGE_CONNECTABLE = 0x00000001,
        RESOURCEUSAGE_CONTAINER = 0x00000002,
        RESOURCEUSAGE_NOLOCALDEVICE = 0x00000004,
        RESOURCEUSAGE_SIBLING = 0x00000008,
        RESOURCEUSAGE_ATTACHED = 0x00000010,
        RESOURCEUSAGE_ALL = (RESOURCEUSAGE_CONNECTABLE | RESOURCEUSAGE_CONTAINER | RESOURCEUSAGE_ATTACHED),
    };

    public class ServerEnum : IEnumerable
    {
        enum ErrorCodes
        {
            NO_ERROR = 0,
            ERROR_NO_MORE_ITEMS = 259
        };

        [StructLayout(LayoutKind.Sequential)]
        private class NETRESOURCE
        {
            public ResourceScope dwScope = 0;
            public ResourceType dwType = 0;
            public ResourceDisplayType dwDisplayType = 0;
            public ResourceUsage dwUsage = 0;
            public string lpLocalName = null;
            public string lpRemoteName = null;
            public string lpComment = null;
            public string lpProvider = null;
        };

        private ArrayList aData = new ArrayList();

        public int Count
        {
            get { return aData.Count; }
        }

        [DllImport("Mpr.dll", EntryPoint = "WNetOpenEnumA", CallingConvention = CallingConvention.Winapi)]
        private static extern ErrorCodes WNetOpenEnum(ResourceScope dwScope, ResourceType dwType, ResourceUsage dwUsage, NETRESOURCE p, out IntPtr lphEnum);

        [DllImport("Mpr.dll", EntryPoint = "WNetCloseEnum", CallingConvention = CallingConvention.Winapi)]
        private static extern ErrorCodes WNetCloseEnum(IntPtr hEnum);

        [DllImport("Mpr.dll", EntryPoint = "WNetEnumResourceA", CallingConvention = CallingConvention.Winapi)]
        private static extern ErrorCodes WNetEnumResource(IntPtr hEnum, ref uint lpcCount, IntPtr buffer, ref uint lpBufferSize);

        private void EnumerateServers(NETRESOURCE pRsrc, ResourceScope scope, ResourceType type, ResourceUsage usage, ResourceDisplayType displayType)
        {
            uint bufferSize = 16384;
            IntPtr buffer = Marshal.AllocHGlobal((int)bufferSize);
            IntPtr handle = IntPtr.Zero;
            ErrorCodes result;
            uint cEntries = 1;

            result = WNetOpenEnum(scope, type, usage, pRsrc, out handle);

            if (result == ErrorCodes.NO_ERROR)
            {
                do
                {
                    result = WNetEnumResource(handle, ref cEntries, buffer, ref bufferSize);

                    if (result == ErrorCodes.NO_ERROR)
                    {
                        Marshal.PtrToStructure(buffer, pRsrc);

                        if (pRsrc.dwDisplayType == displayType)
                            aData.Add(pRsrc.lpRemoteName);

                        if ((pRsrc.dwUsage & ResourceUsage.RESOURCEUSAGE_CONTAINER) == ResourceUsage.RESOURCEUSAGE_CONTAINER)
                            EnumerateServers(pRsrc, scope, type, usage, displayType);
                    }
                    else if (result != ErrorCodes.ERROR_NO_MORE_ITEMS)
                        break;
                } while (result != ErrorCodes.ERROR_NO_MORE_ITEMS);

                WNetCloseEnum(handle);
            }

            Marshal.FreeHGlobal((IntPtr)buffer);
        }

        public ServerEnum(ResourceScope scope, ResourceType type, ResourceUsage usage, ResourceDisplayType displayType)
        {
            NETRESOURCE pRsrc = new NETRESOURCE();

            EnumerateServers(pRsrc, scope, type, usage, displayType);
        }
        #region IEnumerable Members

        public IEnumerator GetEnumerator()
        {
            return aData.GetEnumerator();
        }

        #endregion
    }
}
