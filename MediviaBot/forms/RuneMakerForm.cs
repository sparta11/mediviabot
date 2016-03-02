using MediviaBot.bot;
using MediviaBot.game;
using MediviaBot.game.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace MediviaBot.forms
{
    public partial class RuneMakerForm : Form
    {

        private Game game = GameImpl.Instance;
        private Bot bot = BotImpl.Instance;

        public RuneMakerForm()
        {
            InitializeComponent();

            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

            List<Spell> runes = game.GetAllSpells();
            foreach (Spell s in runes)
            {
                if (s.IsRune)
                    this.comboBox1.Items.Add(s.Name);
            }
            this.comboBox1.SelectedItem = this.comboBox1.Items[0];
            this.radioButton1.Checked = true;

            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.Items.Add("Mana percent above");
            comboBox2.Items.Add("Mana above");
            this.comboBox2.SelectedItem = this.comboBox2.Items[0];

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {


            if (string.IsNullOrEmpty(textBox1.Text))
            {
                checkBox1.Checked = false;
                return;
            }

            if (checkBox1.Checked)
            {
                this.panel3.Enabled = false;
                if (radioButton1.Checked)              
                    bot.SetSetting("/runemaker/hand", "lhand");
                
                else               
                    bot.SetSetting("/runemaker/hand", "rhand");
                
                bot.SetSetting("/runemaker/spell", comboBox1.Text);
                bot.SetSetting("/runemaker/condition", comboBox2.Text);
                bot.SetSetting("/runemaker/value", textBox1.Text);

                if (checkBox2.Checked)
                    bot.SetSetting("/eatfood/enabled", "true");
                else
                    bot.SetSetting("/eatfood/enabled", "false");

                if (checkBox3.Checked)
                    bot.SetSetting("/runemaker/logout", "true");
                else
                    bot.SetSetting("/runemaker/logout", "false");

                bot.SetSetting("/runemaker/enabled", "true");
            }
            else
            {
                this.panel3.Enabled = true;
                bot.SetSetting("/runemaker/enabled", "false");
            }
        }

        private void RuneMakerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
