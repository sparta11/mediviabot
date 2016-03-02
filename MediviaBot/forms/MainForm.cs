using MediviaBot.bot;
using MediviaBot.game;
using MediviaBot.player;
using MediviaBot.util;
using System;
using System.Windows.Forms;

namespace MediviaBot.forms
{
    public partial class MainForm : Form
    {
        private HotkeysForm hotkeyForm = new HotkeysForm();
        private RuneMakerForm runeMakerForm = new RuneMakerForm();

        private Bot bot = BotImpl.Instance;
        private Player player = PlayerImpl.Instance;
        private Game game = GameImpl.Instance;
        private bool lastOnlineInfo;

        public MainForm()
        {
            InitializeComponent();
            this.lastOnlineInfo = game.IsConnected();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            hotkeyForm.Show();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            runeMakerForm.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bool isOnline = game.IsConnected();
            if (isOnline != lastOnlineInfo)
            {
                if (isOnline)
                {
                    this.lastOnlineInfo = isOnline;
                    this.Text = "MediviaBot - " + player.Name();
                }
                else
                {
                    this.Text = "MediviaBot - Disconnected";
                }
            }

            updateMenuItems();
        }

        private void updateMenuItems()
        {
            //antidle
            bool enabled = BotUtil.Bool(bot.GetSetting("/antidle/enabled"));
            antiidleToolStripMenuItem.Checked = enabled;

            //eat food
            enabled = BotUtil.Bool(bot.GetSetting("/eatfood/enabled"));
            eatFoodToolStripMenuItem.Checked = enabled;
        }

        private void lightHackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bot.SetSetting("/lighthack/enabled", "true");
            if (lightHackToolStripMenuItem.Checked)
            {
                this.antiidleToolStripMenuItem.Checked = false;
                //cant be turn off
            }
            else
            {
                this.lightHackToolStripMenuItem.Checked = true;
                bot.SetSetting("/lighthack/enabled", "true");
            }
        }

        private void antiidleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (antiidleToolStripMenuItem.Checked)
            {
                this.antiidleToolStripMenuItem.Checked = false;
                bot.SetSetting("/antidle/enabled", "false");
            }
            else
            {
                this.antiidleToolStripMenuItem.Checked = true;
                bot.SetSetting("/antidle/enabled", "true");
            }
        }

        private void antiidleToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void eatFoodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (eatFoodToolStripMenuItem.Checked)
            {
                this.eatFoodToolStripMenuItem.Checked = false;
                bot.SetSetting("/eatfood/enabled", "false");
            }
            else
            {
                this.eatFoodToolStripMenuItem.Checked = true;
                bot.SetSetting("/eatfood/enabled", "true");
            }
        }
    }
}
