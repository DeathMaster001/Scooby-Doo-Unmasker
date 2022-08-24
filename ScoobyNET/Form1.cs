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

        private Form testing;

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


        DXUI.Overlay overlay;

        //Test button (delete later)
        private void button1_Click(object sender, EventArgs e)
        {
            if (overlay == null)
            {
                overlay = new DXUI.Overlay();
                overlay.Run();
            }
            else
            {
                overlay.Dispose();
                overlay = null;
            }
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

            // if game is the wrong game and is hooked

            if(Encoding.UTF8.GetString(buff, 0, buff.Length) != "G5DE78" && DolphinAccessor.getStatus() == DolphinAccessor.DolphinStatus.hooked)
            {
                MessageBox.Show("Unsupported game has been detected. Only Scooby-Doo Unmasked! (USA) is supported.");
                onUnHookAttempt();
                return;
            }

            // enable controls

            onUnhookShow();

            // start timers

            watchTimer.Start();
        }

        private void firstHookAttempt()
        {
            onHookAttempt();
        }

        private void onUnHookAttempt()
        {
            onUnhookHide();
            watchTimer.Stop();
            DolphinAccessor.unHook();
            updateDolphinHookingStatus();
            if (overlay != null)
            {
                overlay.Dispose();
                overlay = null;
            }
        }

        private void onUnhookHide()
        {
            Settings_grp.Enabled = false;
        }
        private void onUnhookShow()
        {
            Settings_grp.Enabled = true;
        }

        private void WatchTimer_Tick(object sender, EventArgs e)
        {

            // abort if not hooked

            if (DolphinAccessor.getStatus() != DolphinAccessor.DolphinStatus.hooked)
                onUnHookAttempt();

            if (overlay == null)
                return;

            overlay.Screentext = "";

            if (Health_chkbx.Checked)
            {
                 overlay.Screentext = "Health: " + Unmasked.Memory.getHealth().ToString();
            }

        }
    }
}