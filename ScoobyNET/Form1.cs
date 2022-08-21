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
        private Timer updateVariablesTimer1;
        private Timer updateVariablesTimer2;

        public Form1()
        {
            InitializeComponent();
            watchTimer = new Timer();
            watchTimer.Interval = 100;
            watchTimer.Tick += WatchTimer_Tick;
            updateVariablesTimer1 = new Timer();
            updateVariablesTimer2 = new Timer();
            updateVariablesTimer1.Interval = 100;
            updateVariablesTimer2.Interval = 100;
            updateVariablesTimer1.Tick += checkBox1_CheckedStateChanged;
            updateVariablesTimer2.Tick += checkBox2_CheckStateChanged;
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
            MessageBox.Show(Unmasked.getHealth().ToString());
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            settings.ShowDialog();
            settings.Dispose();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
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
            onUnhookShow();
            DolphinAccessor.hook();
            updateDolphinHookingStatus();
            watchTimer.Start();
            updateVariablesTimer1.Start();
            updateVariablesTimer2.Start();
            byte[] buff = new byte[6];
            DolphinAccessor.readFromRAM(0x0, ref buff, 6, true);
            if(Encoding.UTF8.GetString(buff, 0, buff.Length) != "G5DE78")
            {
                MessageBox.Show("Unsupported game has been detected. Only Scooby-Doo Unmasked! (USA) is supported.");
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
            onUnhookHide();
            watchTimer.Stop();
            DolphinAccessor.unHook();
            updateDolphinHookingStatus();
        }

        private void onUnhookHide()
        {
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                button1.Enabled = false;
                checkBox1.Enabled = false;
                checkBox2.Enabled = false;
        }
        private void onUnhookShow()
        {
            button1.Enabled = true;
            checkBox1.Enabled = true;
            checkBox2.Enabled = true;
        }

        private void WatchTimer_Tick(object sender, EventArgs e)
        {
            //byte[] buff = new byte[6];
            //DolphinAccessor.readFromRAM(0x0, ref buff, 6, true);
            //Debug.WriteLine(Encoding.UTF8.GetString(buff, 0, buff.Length));
        }
        //remove later
        private void VariablesTimer_Tick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }
        private void VariablesTimer2_Tick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }
        private void checkBox1_CheckedStateChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked != true)
            {
                checkBox1.Text = "Scooby's Health: ";
            }
            else
            {
                checkBox1.Text = "Scooby's Health: " + Unmasked.getHealth().ToString();
            }
        }
        private void checkBox2_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked != true)
            {
                checkBox2.Text = "Scooby's Total Health: ";
            }
            else
            {
                checkBox2.Text = "Scooby's Total Health: " + Unmasked.getTotalHealth().ToString();
            }
        }
    }
}