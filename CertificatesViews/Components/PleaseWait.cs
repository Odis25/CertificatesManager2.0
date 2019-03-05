using CertificatesViews.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace CertificatesViews.Components
{

    public class PleaseWait : IDisposable
    {
        private Form mSplash;

        public PleaseWait()
        {
            Thread t = new Thread(new ThreadStart(workerThread));
            t.IsBackground = true;
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
        }
        public void Dispose()
        {
            mSplash.Invoke(new MethodInvoker(stopThread));
        }
        private void stopThread()
        {
            mSplash.Close();
        }
        private void workerThread()
        {
            mSplash = new WaitingForm();   // Substitute this with your own
            mSplash.StartPosition = FormStartPosition.CenterScreen;
            mSplash.TopMost = true;
            Application.Run(mSplash);
        }
    }
}
