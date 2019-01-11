using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace CertificatesModel.Authorization
{
    public static class Validate
    {
        public static bool ImpersonateUser(string username, string domain, string password)
        {
            IntPtr token;

            bool success = NativeMethods.LogonUser(
                username,
                domain,
                password,
                NativeMethods.LogonType.NewCredentials,
                NativeMethods.LogonProvider.Default,
                out token);

            var res = Marshal.GetLastWin32Error();

            if (token != IntPtr.Zero)
            {
                WindowsIdentity identity = new WindowsIdentity(token);
                var _scontext = identity.Impersonate();
            }
            
            return success;
        }
    }
}
