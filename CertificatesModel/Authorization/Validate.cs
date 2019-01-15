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
        public static WindowsImpersonationContext _scontext;

        public static bool ImpersonateUser(string username, string domain, string password)
        {
            IntPtr token;
            var _token = WindowsIdentity.GetCurrent().Token;
            bool success = NativeMethods.LogonUser(
                username,
                domain,
                password,
                NativeMethods.LogonType.NewCredentials,
                NativeMethods.LogonProvider.Default,
                out token);

            if (token != IntPtr.Zero)
            {
                WindowsIdentity identity = new WindowsIdentity(token);
                _scontext = identity.Impersonate();
                           
            }
            
            return success;
        }
    }
}
