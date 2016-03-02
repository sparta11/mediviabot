using MediviaBot.bot;
using MediviaBot.util;
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
    public partial class HotkeysForm : Form
    {

        private Bot bot = BotImpl.Instance;

        public HotkeysForm()
        {
            InitializeComponent();

            setHotkeyTypesList();
            setLocationOptions();

            //loadHotkeySettings();

        }

        private void setLocationOptions()
        {
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.Items.Add("Left hand");
            comboBox2.SelectedItem = comboBox2.Items[0];
            comboBox2.Items.Add("Right hand");
            comboBox2.Items.Add("Finger (ring)");
            comboBox2.Items.Add("Neck");
            comboBox2.Items.Add("Belt (arrow)");
        }

        private void setHotkeyTypesList()
        {
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            foreach (HotkeyType hType in Enum.GetValues(typeof(HotkeyType)))
            {
                switch (hType)
                {
                    case HotkeyType.UseOnYourself:
                        comboBox1.Items.Add("Use item on yourself");
                        comboBox1.SelectedItem = comboBox1.Items[0];
                        break;
                    case HotkeyType.UseOnTarget:
                        comboBox1.Items.Add("Use item on target");
                        break;
                    case HotkeyType.UseWithCrosshairs:
                        comboBox1.Items.Add("Use with crosshairs");
                        break;
                    case HotkeyType.UseItem:
                        comboBox1.Items.Add("Use item");
                        break;
                    case HotkeyType.EquipItem:
                        comboBox1.Items.Add("Equip item");
                        break;
                    case HotkeyType.UnequipItem:
                        comboBox1.Items.Add("Unequip item");
                        break;
                }
            }

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            e.SuppressKeyPress = true;
            e.KeyCode.ToString();
            textBox1.Text = e.KeyCode.ToString();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void HotkeysForm_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            string item = comboBox1.SelectedItem.ToString();
            switch (item)
            {
                case "Use item on yourself":
                    textBox2.Enabled = true;
                    comboBox2.Enabled = false;
                    break;
                case "Use item on target":
                    textBox2.Enabled = true;
                    comboBox2.Enabled = false;
                    break;
                case "Use with crosshairs":
                    textBox2.Enabled = true;
                    comboBox2.Enabled = false;
                    break;
                case "Use item":
                    textBox2.Enabled = true;
                    comboBox2.Enabled = false;
                    break;
                case "Equip item":
                    textBox2.Enabled = true;
                    comboBox2.Enabled = true;
                    break;
                case "Unequip item":
                    textBox2.Enabled = false;
                    comboBox2.Enabled = true;
                    break;
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
            if (checkBox1.Checked)
            {
                panel3.Enabled = false;
                panel4.Enabled = false;
                bot.SetSetting("/hotkeys/enabled", "true");
            }
            else
            {
                panel3.Enabled = true;
                panel4.Enabled = true;
                bot.SetSetting("/hotkeys/enabled", "false");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            //get the key
            if (String.IsNullOrEmpty(textBox1.Text))
                return;
            KeyConverter k = new KeyConverter();
            Key key = (Key)k.ConvertFromString(textBox1.Text);

            //hotkey type
            string sType = comboBox1.SelectedItem.ToString();
            int count = bot.GetHotkeys().Count;
            string hotkeyID = Convert.ToString(count + 1);
            Hotkey hotkey;
            string slot;

            switch (sType)
            {
                case "Use item on yourself":                                     
                    hotkey = new Hotkey(hotkeyID, textBox1.Text, HotkeyType.UseOnYourself);
                    hotkey.ItemId = BotUtil.Number(textBox2.Text);
                    if (hotkey.ItemId < 0)
                        return;

                    //add from grid
                    this.dataGridView1.Rows.Add(hotkeyID, textBox1.Text, "Use item on yourself", textBox2.Text, "");
                    bot.AddHotkey(hotkey);
                    break;
                case "Use item on target":
                    hotkey = new Hotkey(hotkeyID, textBox1.Text, HotkeyType.UseOnTarget);
                    hotkey.ItemId = BotUtil.Number(textBox2.Text);
                    if (hotkey.ItemId < 0)
                        return;
                    //add from grid
                    this.dataGridView1.Rows.Add(hotkeyID, textBox1.Text, "Use item on target", textBox2.Text, "");
                    bot.AddHotkey(hotkey);
                    break;

                case "Use with crosshairs":
                    hotkey = new Hotkey(hotkeyID, textBox1.Text, HotkeyType.UseWithCrosshairs);
                    hotkey.ItemId = BotUtil.Number(textBox2.Text);
                    if (hotkey.ItemId < 0)
                        return;
                    //add from grid
                    this.dataGridView1.Rows.Add(hotkeyID, textBox1.Text, "Use with crosshairs", textBox2.Text, "");
                    bot.AddHotkey(hotkey);
                    break;
                case "Use item":
                    hotkey = new Hotkey(hotkeyID, textBox1.Text, HotkeyType.UseItem);
                    hotkey.ItemId = BotUtil.Number(textBox2.Text);
                    if (hotkey.ItemId < 0)
                        return;
                    //add from grid
                    this.dataGridView1.Rows.Add(hotkeyID, textBox1.Text, "Use item", textBox2.Text, "");
                    bot.AddHotkey(hotkey);
                    break;
                case "Equip item":
                    hotkey = new Hotkey(hotkeyID, textBox1.Text, HotkeyType.EquipItem);
                    hotkey.ItemId = BotUtil.Number(textBox2.Text);
                    if (hotkey.ItemId < 0)
                        return;
                    //add from grid
                    slot = comboBox2.SelectedItem.ToString();
                    this.dataGridView1.Rows.Add(hotkeyID, textBox1.Text, "Equip item", textBox2.Text, slot);
                    hotkey.InventoryLocation = getInventoryLocationByString(slot);
                    bot.AddHotkey(hotkey);
                    break;
                case "Unequip item":
                    hotkey = new Hotkey(hotkeyID, textBox1.Text, HotkeyType.UnequipItem);
                    //add from grid
                    slot = comboBox2.SelectedItem.ToString();
                    this.dataGridView1.Rows.Add(hotkeyID, textBox1.Text, "Unequip item", "", slot);
                    hotkey.InventoryLocation = getInventoryLocationByString(slot);
                    bot.AddHotkey(hotkey);
                    break;
            }

            textBox1.Clear();


        }

        private string getInventoryLocationByString(string slot)
        {

            switch (slot)
            {
                case "Left hand":
                    return "lhand";
                case "Right hand":
                    return "rhand";
                case "Finger (ring)":
                    return "finger";
                case "Neck":
                    return "neck";
                case "Belt (arrow)":
                    return "belt";
            }
            throw new ArgumentException("No inventory location found with name: " + slot);

        }

        private void button2_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
            {
                string id = "";

                //item.Index
                foreach (DataGridViewCell cell in item.Cells)
                {
                    id = cell.Value.ToString();
                    break;

                }

                bot.RemoveHotkeyById(id);
                dataGridView1.Rows.RemoveAt(item.Index);
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void HotkeysForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }
    }
}
