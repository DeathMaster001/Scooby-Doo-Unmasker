using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DolphinComm;
using DolphinComm.DolphinProcess;
using System.Diagnostics;

namespace ScoobyNET
{
    public partial class Form1 : Form
    {
        private Timer watchTimer;

        public Form1()
        {
            InitializeComponent();
            watchTimer = new Timer();
            watchTimer.Interval = 100;
            watchTimer.Tick += WatchTimer_Tick;
            DolphinAccessor.init();
            firstHookAttempt();
        }

        private void hook_button_Click(object sender, EventArgs e)
        {
            if (DolphinAccessor.getStatus() == DolphinAccessor.DolphinStatus.hooked)
            {
                onUnHookAttempt();
            }
            else
            {
                onHookAttempt();
            }
        }

        //Test button (delete later)
        private void button1_Click(object sender, EventArgs e)
        {
            byte[] buff = new byte[6];
            DolphinAccessor.readFromRAM(0x0,ref buff,6,true);
            MessageBox.Show(Encoding.UTF8.GetString(buff,0,buff.Length));
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            settings.ShowDialog();
            settings.Dispose();
        }

        private void updateDolphinHookingStatus()
        {
            switch(DolphinAccessor.getStatus())
            {
                case DolphinAccessor.DolphinStatus.hooked:
                    hooked_lbl.Text = "Hooked successfully to Dolphin, current start address: " + DolphinAccessor.getEmuRAMAddressStart().ToString("X");
                    hook_button.Text = "Unhook";
                    break;
                case DolphinAccessor.DolphinStatus.notRunning:
                    hooked_lbl.Text = "Cannot hook to Dolphin, process is not running";
                    hook_button.Text = "Hook";
                    break;
                case DolphinAccessor.DolphinStatus.noEmu:
                    hooked_lbl.Text = "Cannot hook to Dolphin, the process is running, but no emulation has been started";
                    hook_button.Text = "Hook";
                    break;
                case DolphinAccessor.DolphinStatus.unHooked:
                    hooked_lbl.Text = "Unhooked, press \"Hook\" to hook to Dolphin again";
                    hook_button.Text = "Hook";
                    break;
            }
        }

        private void onHookAttempt()
        {
            DolphinAccessor.hook();
            updateDolphinHookingStatus();
            byte[] buff = new byte[6];
            DolphinAccessor.readFromRAM(0x0, ref buff, 6, true);
            if(Encoding.UTF8.GetString(buff, 0, buff.Length) != "G5DE78")
            {
                MessageBox.Show("Unsupported game has been detected.");
                onUnHookAttempt();
                return;
            }
            watchTimer.Start();
        }

        private void firstHookAttempt()
        {
            onHookAttempt();
        }

        private void onUnHookAttempt()
        {
            watchTimer.Stop();
            DolphinAccessor.unHook();
            updateDolphinHookingStatus();
        }
        private void WatchTimer_Tick(object sender, EventArgs e)
        {
            byte[] buff = new byte[6];
            DolphinAccessor.readFromRAM(0x0, ref buff, 6, true);
            Debug.WriteLine(Encoding.UTF8.GetString(buff, 0, buff.Length));
        }
    }
}
