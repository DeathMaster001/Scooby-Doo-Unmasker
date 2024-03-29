﻿using System;
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
using static DolphinComm.DolphinAccessor;
using ScoobyNET.Unmasked;

namespace ScoobyNET
{
    public partial class MainWindow : Form
    {
        private Timer watchTimer;
        private Timer writeTimer;

        public MainWindow()
        {
            InitializeComponent();
            watchTimer = new Timer();
            watchTimer.Interval = 100;
            watchTimer.Tick += WatchTimer_Tick;
            writeTimer = new Timer();
            writeTimer.Interval = 10;
            writeTimer.Tick += WriteTimer_Tick;
            writeTimer.Start();
            DolphinAccessor.init();
            firstHookAttempt();
        }

        private void hook_button_Click(object sender, EventArgs e)
        {
            if (DolphinAccessor.getStatus() == DolphinAccessor.DolphinStatus.hooked)
            {
                OnUnHookAttempt();
            }
            else
            {
                OnHookAttempt();
            }
        }

        DXUI.Overlay overlay;

#if DEBUG 
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
                OnHookAttempt();
            }
        }
#else
        private void button1_Click(object sender, EventArgs e)
        {
        }
#endif
        private void clicktoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("What... you expected something?\nJust cause it says Click doesn't mean you should Click it.\nNow click down below and get out of here.", "Nice you clicked something");
        }
        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("A memory value viewer made for Scooby-Doo Unmasked! Made for use with the emulator Dolphin. " +
                "Lets you view various in game values normally hidden from the player" +
                "\n\nThis program is licensed under the MIT License. " +
                "You should have recieved a copy of the MIT license along with this program." +
                "\n\nCredits:\nDeathMaster001 for coding and window design." +
                "\nHDBSD for the majority of the coding." +
                "\nClimbingCoder for finding the majority of the memory values." +
                "\nSchnert for finding the Position Data/Pointer for Scooby." +
                "\nGhabulous Ghoti for the name of the program.", "About Scooby Doo Unmasker", MessageBoxButtons.OK);
        }

        private void updateDolphinHookingStatus()
        {
            switch (DolphinAccessor.getStatus())
            {
                case DolphinAccessor.DolphinStatus.hooked:
                    hooked_lbl.Text = "Hooked successfully to Dolphin, current start address: " + DolphinAccessor.getEmuRAMAddressStart().ToString("X");
                    hook_button.Text = "Unhook";
                    break;
                case DolphinAccessor.DolphinStatus.notRunning:
                    hooked_lbl.Text = "Cannot hook to Dolphin, the process is not running.";
                    hook_button.Text = "Hook";
                    break;
                case DolphinAccessor.DolphinStatus.noEmu:
                    hooked_lbl.Text = "Cannot hook to Dolphin, the process is running, but no emulation has been started.";
                    hook_button.Text = "Hook";
                    break;
                case DolphinAccessor.DolphinStatus.unHooked:
                    hooked_lbl.Text = "Unhooked, press \"Hook\" to hook to Dolphin again.";
                    hook_button.Text = "Hook";
                    break;
            }
        }

        private void OnHookAttempt()
        {
#if DEBUG
            button1.Visible = true;
#else
            button1.Visible = false;
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
#endif
            DolphinAccessor.hook();
            updateDolphinHookingStatus();

            byte[] buff = new byte[6];
            DolphinAccessor.readFromRAM(0x0, ref buff, 6, true);

            // if game is the wrong game and is hooked
            if ((Encoding.UTF8.GetString(buff, 0, buff.Length) != "G5DE78" && Encoding.UTF8.GetString(buff, 0, buff.Length) != "G5DP78") && DolphinAccessor.getStatus() == DolphinAccessor.DolphinStatus.hooked)
            {
                OnUnHookAttempt();

                // Pause for half a second asynchronously and show MessageBox explaining to the user that the program only works with Scooby-Doo Unmasked!
                Task.Run(async () =>
                {
                    await Task.Delay(500);
                    MessageBox.Show("An unsupported game has been detected. This program only supports the following games:\n\nScooby-Doo Unmasked! (NTSC) (G5DE78)\nScooby-Doo Unmasked! (PAL) (G5DP78)\n\nPlease rehook with the above game running instead.", "Unsupported Game");
                });

                return;
            }
            else if (DolphinAccessor.getStatus() == DolphinAccessor.DolphinStatus.noEmu)
            {
                OnUnhookHide();
                return;
            }
            else if (DolphinAccessor.getStatus() == DolphinAccessor.DolphinStatus.notRunning)
            {
                OnUnhookHide();
                return;
            }

            // enable controls
            OnUnhookShow();

            if (Encoding.UTF8.GetString(buff, 0, buff.Length) == "G5DE78")
            {
                Unmasked.Memory.gametype = 0;
            }
            else if (Encoding.UTF8.GetString(buff, 0, buff.Length) == "G5DP78")
            {
                Unmasked.Memory.gametype = 1;
            }

            // start timers
            watchTimer.Start();
        }

        private void firstHookAttempt()
        {
            OnHookAttempt();
        }

        private void OnUnHookAttempt()
        {
            OnUnhookHide();
            watchTimer.Stop();
            DolphinAccessor.unHook();
            updateDolphinHookingStatus();
            if (overlay != null)
            {
                overlay.Dispose();
                overlay = null;
            }
        }

        private void OnUnhookHide()
        {
            Stats_grp.Enabled = false;
            HealthDisplay_chkbx.Checked = false;
            MubberDisplay_chkbx.Checked = false;
            LevelDisplay_chkbx.Checked = false;
            POSDisplay_chkbx.Checked = false;
            InputDisplay_chkbx.Checked = false;
            FoodDisplay_chkbx.Checked = false;
            FoodMubber_chkbx.Checked = false;
            ClueDisplay_chkbx.Checked = false;
            TrapDisplay_chkbx.Checked = false;
            CostumeDisplay_chkbx.Checked = false;
            WriteFile_chkbx.Checked = false;
        }
        private void OnUnhookShow()
        {
            Stats_grp.Enabled = true;
        }

        private void WriteTimer_Tick(object sender, EventArgs e)
        {

        }

        private void WatchTimer_Tick(object sender, EventArgs e)
        {
            // abort if not hooked
            if (DolphinAccessor.getStatus() != DolphinAccessor.DolphinStatus.hooked)
                OnUnHookAttempt();

            if (overlay == null)
                return;

            overlay.Screentext = "\n";

            //Shows Health on screen when the "Scooby's Health" checkbox is checked
            if (HealthDisplay_chkbx.Checked)
            {
                overlay.Screentext += "\nHealth: " + Unmasked.Memory.getHealth().ToString();
            }

            //Shows Mubber on screen when the "Scooby's Mubber" checkbox is checked
            if (MubberDisplay_chkbx.Checked)
            {
                overlay.Screentext += "\nMubber: " + Unmasked.Memory.getMubber().ToString();
            }

            //Shows Current Level on screen when the "Level Display" checkbox is checked.
            if (LevelDisplay_chkbx.Checked)
            {
                overlay.Screentext += "\nLevel: " + Unmasked.Level.getLevelName();
            }

            //Shows Scooby's X,Y,Z Position on screen when the position checkbox is checked
            if (POSDisplay_chkbx.Checked)
            {
                float[] posCoords = Unmasked.Memory.getPosition();
                if (posCoords != null)
                {
                    overlay.Screentext += $"\nPosition:\n\tX: {posCoords[0].ToString("0.000")}\n\tY: {posCoords[1].ToString("0.000")}\n\tZ: {posCoords[2].ToString("0.000")}";
                }
            }

            //Shows Player input on Screen.
            if (InputDisplay_chkbx.Checked)
            {
                Dictionary<string, int> inputDisplay = Unmasked.Input.processInputs();
                overlay.Screentext += "\nInput:";
                foreach (var input in inputDisplay)
                {
                    overlay.Screentext += "\n" + input.Key + " " + (input.Value);
                }
            }

            //Shows Food on screen when food checkbox is checked
            if (FoodDisplay_chkbx.Checked)
            {
                uint lvl = Unmasked.Memory.getLevel();
                Dictionary<string, bool> levelFoods = Unmasked.Collectibles.getLevelFoods();
                Dictionary<string, bool> levelmubberFoods = Unmasked.Collectibles.getLevelFoodsMubber();

                if (levelFoods.Count == 0)
                {
                    overlay.Screentext += "\n\nNo Foods";
                }
                else
                {
                    string foodmsg = "\n\nFood(s): ";
                    bool foodComplete = true;

                    //foreach loop writes each food to screen
                    foreach (string food in levelFoods.Keys)
                    {
                        foodmsg += "\n" + food + " " + (levelFoods[food] ? "[*]" : "[]");
                        if (!levelFoods[food])
                        {
                            foodComplete = false;
                        }
                        //if FoodMubber checkbox is checked, the required mubber for the respective mubber machine is shown.
                        if (FoodMubber_chkbx.Checked)
                        {
                            foreach (string mubberfood in levelmubberFoods.Keys)
                            {
                                if (foodComplete == false)
                                {
                                    //write code that does this if statement more effectively and efficiently
                                    if (lvl == 6 && food == "Chocolate Bar" || lvl == 8 && food == "Apple" || lvl == 9 && food == "Pepperoni" || lvl == 11 && food == "Carrot" || lvl == 14 && food == "Broccoli" || lvl == 17 && food == "Eggplant" || lvl == 20 && food == "Marshmallows" || lvl == 22 && food == "Cotton Candy")
                                    {
                                        foodmsg += " " + mubberfood + " Mubber";
                                    }
                                }
                            }
                        }
                    }
                    if (foodComplete)
                    {
                        overlay.Screentext += "\n\nAll Foods Collected";
                    }
                    else
                    {
                        overlay.Screentext += foodmsg;
                    }
                }

            }

            //Shows Clues on screen when Clue checkbox is checked
            if (ClueDisplay_chkbx.Checked)
            {
                Dictionary<string, bool> levelClues = Unmasked.Collectibles.getLevelClues();

                if (levelClues.Count == 0)
                {
                    overlay.Screentext += "\n\nNo Clues";
                }
                else
                {
                    string cluemsg = "\n\nClue(s): ";
                    bool clueComplete = true;


                    //foreach loop writes each clue to screen
                    foreach (string clue in levelClues.Keys)
                    {
                        cluemsg += "\n" + clue + " " + (levelClues[clue] ? "[*]" : "[]");
                        if (!levelClues[clue])
                        {
                            clueComplete = false;
                        }
                    }
                    if (clueComplete)
                    {
                        overlay.Screentext += "\n\nAll Clues Collected";
                    }
                    else
                    {
                        overlay.Screentext += cluemsg;
                    }
                }
            }

            //Shows Traps on screen when Trap checkbox is checked
            if (TrapDisplay_chkbx.Checked)
            {

                Dictionary<string, bool> levelTraps = Unmasked.Collectibles.getLevelTraps();

                if (levelTraps.Count == 0)
                {
                    overlay.Screentext += "\n\nNo Traps";
                }
                else
                {
                    string trapmsg = "\n\nTrap: ";
                    bool trapComplete = true;


                    //foreach loop writes each trap to screen
                    foreach (string trap in levelTraps.Keys)
                    {
                        trapmsg += "\n" + trap + " " + (levelTraps[trap] ? "[*]" : "[]");
                        if (!levelTraps[trap])
                        {
                            trapComplete = false;
                        }
                    }
                    if (trapComplete)
                    {
                        overlay.Screentext += "\n\nTrap Collected";
                    }
                    else
                    {
                        overlay.Screentext += trapmsg;
                    }
                }
            }

            //Shows Costume on screen when Costume checkbox is checked
            if (CostumeDisplay_chkbx.Checked)
            {
                Dictionary<string, bool> levelCostumes = Unmasked.Collectibles.getLevelCostumes();

                if (levelCostumes.Count == 0)
                {
                    overlay.Screentext += "\n\nNo Costumes";
                }
                else
                {
                    string costumemsg = "\n\nCostume(s): ";
                    bool costumeComplete = true;


                    //foreach loop writes each trap to screen
                    foreach (string costume in levelCostumes.Keys)
                    {
                        costumemsg += "\n" + costume + " " + (levelCostumes[costume] ? "[*]" : "[]");
                        if (!levelCostumes[costume])
                        {
                            costumeComplete = false;
                        }
                    }
                    if (costumeComplete)
                    {
                        overlay.Screentext += "\n\nCostume Tokens Collected";
                    }
                    else
                    {
                        overlay.Screentext += costumemsg;
                    }
                }
            }

            if (PercentageDisplay_chkbx.Checked)
            {
                uint lvl = Unmasked.Memory.getLevel();
                double completionpercentage;
                completionpercentage = 0;
                Dictionary<string, bool> levelFoods = Unmasked.Collectibles.getLevelFoods();
                Dictionary<string, bool> levelClues = Unmasked.Collectibles.getLevelClues();
                Dictionary<string, bool> levelTraps = Unmasked.Collectibles.getLevelTraps();
                overlay.Screentext += "\n\nGame Completion: ";

                if (lvl == 4)
                {
                    overlay.Screentext += completionpercentage + "%";
                }
                else if (lvl == 6)
                {
                    completionpercentage += 4;

                    //semi works only increments completion upon collecting all clues and doesn't work past MFM 1.
                    if (levelClues.Count != 0)
                    {
                        bool clueComplete = true;

                        foreach (string clue in levelClues.Keys)
                        {
                            if (!levelClues[clue])
                            {
                                clueComplete = false;
                            }
                        }
                        if (clueComplete)
                        {
                            completionpercentage += 1;
                        }
                    }

                    //semi works only increments completion upon collecting all foods and doesn't work past MFM 1.
                    if (levelFoods.Count != 0)
                    {
                        bool foodComplete = true;

                        foreach (string food in levelFoods.Keys)
                        {
                            if (!levelFoods[food])
                            {
                                foodComplete = false;
                            }
                        }
                        if (foodComplete)
                        {
                            completionpercentage += 1;
                        }
                    }
                    overlay.Screentext += completionpercentage + "%";
                }
                else
                {
                    overlay.Screentext += completionpercentage + "%";
                }
            }
            overlay.Screentext = overlay.Screentext.Remove(0, 1);
        }

        private void simplemode_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Size = new Size(535, 285);
            hook_button.Size = new Size(500, 19);
            hooked_lbl.Size = new Size(505, 16);
            Stats_grp.Size = new Size(500, 143);
            Collectibles_grp.Size = new Size(368, 143);
            Misc_grp.Size = new Size(272, 143);
            button1.Location = new Point(169, 118);
        }

        private void advancedModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Size = new Size(535, 400);
            hook_button.Size = new Size(500, 19);
            hooked_lbl.Size = new Size(505, 16);
            Stats_grp.Size = new Size(500, 261);
            Collectibles_grp.Size = new Size(368, 261);
            Misc_grp.Size = new Size(253, 261);
            button1.Location = new Point(169, 237);
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            MessageBox.Show(Level.getLevelIdByName(comboBox1.Text).ToString());
        }
    }
}