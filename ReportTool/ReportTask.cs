using Gecko;
using ReportTool.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ReportTool
{
    class ReportTask
    {
        public Task AsyncStart(GeckoWebBrowser Browser, IntPtr Handle, string URL, CancellationToken CancellationToken = default(CancellationToken))
        {
            return Task.Run(() => Start(Browser, Handle, URL, CancellationToken), CancellationToken);
        }

        private async void Start(GeckoWebBrowser Browser, IntPtr Handle, string URL, CancellationToken CancellationToken)
        {
            try
            {
                Random random = new Random();
                while (true)
                {
                    IntPtr Handule = WindowAPI.FindWindowEx(Handle, IntPtr.Zero, "MozillaWindowClass", "");
                    Handule = WindowAPI.FindWindowEx(Handule, IntPtr.Zero, "MozillaWindowClass", "");
                    Mouse.MouseLeftClick(Handule, new POINT(477, 190));

                    await Task.Delay(random.Next(1000, 3000), CancellationToken);
                    Handule = WindowAPI.FindWindowEx(Handle, IntPtr.Zero, "MozillaWindowClass", "");
                    Handule = WindowAPI.FindWindowEx(Handule, IntPtr.Zero, "MozillaWindowClass", "");
                    Mouse.MouseLeftClick(Handule, new POINT(15, 124));

                    await Task.Delay(random.Next(1000, 3000), CancellationToken);
                    Handule = WindowAPI.FindWindowEx(Handle, IntPtr.Zero, "MozillaWindowClass", "");
                    Handule = WindowAPI.FindWindowEx(Handule, IntPtr.Zero, "MozillaWindowClass", "");
                    Mouse.MouseLeftClick(Handule, new POINT(15, 126));

                    await Task.Delay(random.Next(1000, 3000), CancellationToken);
                    Handule = WindowAPI.FindWindowEx(Handle, IntPtr.Zero, "MozillaWindowClass", "");
                    Handule = WindowAPI.FindWindowEx(Handule, IntPtr.Zero, "MozillaWindowClass", "");
                    Mouse.MouseLeftClick(Handule, new POINT(39, 285));

                    await Task.Delay(random.Next(1000, 3000), CancellationToken);
                    Handule = WindowAPI.FindWindowEx(Handle, IntPtr.Zero, "MozillaWindowClass", "");
                    Handule = WindowAPI.FindWindowEx(Handule, IntPtr.Zero, "MozillaWindowClass", "");
                    Mouse.MouseLeftClick(Handule, new POINT(34, 279));

                    await Task.Delay(random.Next(1000, 3000), CancellationToken);
                    Handule = WindowAPI.FindWindowEx(Handle, IntPtr.Zero, "MozillaWindowClass", "");
                    Handule = WindowAPI.FindWindowEx(Handule, IntPtr.Zero, "MozillaWindowClass", "");
                    Mouse.MouseLeftClick(Handule, new POINT(17, 110));


                    await Task.Delay(random.Next(1000, 3000), CancellationToken);
                    Handule = WindowAPI.FindWindowEx(Handle, IntPtr.Zero, "MozillaWindowClass", "");
                    Handule = WindowAPI.FindWindowEx(Handule, IntPtr.Zero, "MozillaWindowClass", "");
                    Mouse.MouseLeftClick(Handule, new POINT(46, 333));

                    await Task.Delay(random.Next(1000, 3000), CancellationToken);
                    Browser.Navigate(URL);

                    await Task.Delay(random.Next(15 * 60 * 1000, 30 * 60 * 1000), CancellationToken);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
        }
    }
}
