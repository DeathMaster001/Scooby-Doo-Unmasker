using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;
using DolphinComm;

namespace ScoobyNET.UI
{
    public class Display : ThreadedComponent
    {
        public Form Window { get; private set; }
        protected override TimeSpan ThreadFrameSleep { get; set; } = new TimeSpan(0, 0, 0, 0, 200);

        public Display(Form frm)
        {
            Window = frm;

            Window.Text = "Overlay Window";
            Window.MinimizeBox = false;
            Window.MaximizeBox = false;
            Window.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Window.TopMost = true;
            Window.Width = 16;
            Window.Height = 16;
            Window.Left = -32000;
            Window.Top = -32000;
            Window.StartPosition = System.Windows.Forms.FormStartPosition.Manual;


            Window.SizeChanged += (sender, args) => ExtendFrameIntoClientArea();
            Window.LocationChanged += (sender, args) => ExtendFrameIntoClientArea();
            Window.Show();
        }

        public override void Dispose()
        {
            base.Dispose();

            Window.Close();
            Window.Dispose();
            Window = default;
        }

        private void ExtendFrameIntoClientArea()
        {
            var margins = new Data.Margins
            {
                Left = -1,
                Right = -1,
                Top = -1,
                Bottom = -1,
            };
        }

        protected override void FrameAction()
        {

            IntPtr gameWindow = (IntPtr)null;

            foreach (var handle in Imports.EnumerateProcessWindowHandles(
            Process.GetProcessesByName("Dolphin").First().Id))
            {
                StringBuilder message = new StringBuilder(1000);
                Imports.SendMessage(handle, Imports.WM_GETTEXT, message.Capacity, message);
                if (message.ToString().Contains("G5DE78"))
                {
                    gameWindow = handle;
                    break;
                }
            }

            Update(Imports.GetClientRectangle(gameWindow));
        }

        private void Update(Rectangle windowRectangleClient)
        {
            //System.Windows.Application.Current.Dispatcher.Invoke(() =>
            // {

            if (Window.InvokeRequired)
            {
                Action safe = delegate
                {

                    var exStyle = Imports.GetWindowLong(Window.Handle, -20);
                    exStyle |= Imports.WS_EX_LAYERED;
                    exStyle |= Imports.WS_EX_TRANSPARENT;

                    Imports.SetWindowLong(Window.Handle, Imports.GWL_EXSTYLE, (IntPtr)exStyle);

                    Imports.SetLayeredWindowAttributes(Window.Handle, 0, 255, Imports.LWA_ALPHA);

                    Window.BackColor = Color.Brown; // TODO: temporary
                    Window.TransparencyKey = Color.Brown;

                    if (Window.Location != windowRectangleClient.Location || Window.Size != windowRectangleClient.Size)
                    {
                        if (windowRectangleClient.Width > 0 && windowRectangleClient.Height > 0)
                        {
                            // valid
                            Window.Location = windowRectangleClient.Location;
                            Window.Size = windowRectangleClient.Size;
                        }
                        else
                        {
                            // invalid
                            Window.Location = new Point(-32000, -32000);
                            Window.Size = new Size(16, 16);
                        }
                    }
                };
                Window.Invoke(safe);
            }
        }

    }
}