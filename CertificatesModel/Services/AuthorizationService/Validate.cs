using System;
using System.Diagnostics;
using System.Security.Permissions;
using System.Security.Principal;

namespace CertificatesModel.Authorization
{
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
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
                NativeMethods.LogonProvider.WinNT50,
                out token);

            if (token != IntPtr.Zero)
            {
                var identity = new WindowsIdentity(token);
                _scontext = identity.Impersonate();

                ProcessStartInfo pi = new ProcessStartInfo();
                pi.FileName = "net.exe";                
                pi.Arguments = $@"use \\fileserver.incomsystem.ru {password} /USER:{domain}\{username}";
                pi.UseShellExecute = true;
                Process.Start(pi);
            }

            return success;
        }
    }
}
