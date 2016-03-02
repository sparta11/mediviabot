using MediviaBot.bot;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediviaBot.forms
{
    public partial class ClientChooserForm : Form
    {

        //private Bot bot = BotImpl.Instance;
        private ClientChooser chooser = new ClientChooser();

        public ClientChooserForm()
        {
            InitializeComponent();
            MaximizeBox = false;

            dataGridView1.Columns[0].Width = 50;
            dataGridView1.MultiSelect = false;
            populateClientList();
        }

        private void populateClientList()
        {


            List<ClientOption> clients = chooser.GetAllClients();         
            foreach (ClientOption c in clients)
            {
                this.dataGridView1.Rows.Add(c.Id, c.CharName);
            }

        }

        private void updateClients()
        {

            string selectedName = "";
            foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
            {
                selectedName = item.Cells[1].Value.ToString();
                break;
            }

            clearClientList();
            populateClientList();

            if (!selectedName.Equals(""))
            {
                selectRow(selectedName);
            }
        }

        private void selectRow(string selectedName)
        {
            foreach (DataGridViewRow row in this.dataGridView1.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value.ToString().Equals(selectedName))
                        row.Selected = true;

                }
            }
        }

        private void clearClientList()
        {
            int count = this.dataGridView1.Rows.Count;
            for (int i = (count - 1); i >= 0; i--)
            {
                DataGridViewRow row = dataGridView1.Rows[i];
                dataGridView1.Rows.Remove(row);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.updateClients();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ////
            if (this.dataGridView1.SelectedRows.Count == 0)
            {
                return;
            }

            string id = this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            ClientOption client = chooser.GetClientOptionById(id);
            if (client == null)
            {
                Console.WriteLine("ClienChoose null");
                return;
            }

            PreLoader pre = new PreLoader();
            pre.Initialize(client.Process);

            this.timer1.Enabled = false;

            this.Hide();
            var MainForm = new MainForm();

            MainForm.Closed += (s, args) => this.Close();
            MainForm.Text = "MediviaBot - " + client.CharName;
            MainForm.Show();
        }

        private void ClientChooserForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Application.Exit();
            Application.Exit();
        }
    }
}
