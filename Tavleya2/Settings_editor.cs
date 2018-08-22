using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Windows.Forms;

namespace Tavleya2
{
    [Serializable]
    public partial class Settings_editor : Form
    {


        public delegate void MethodContainer();
        public event MethodContainer onOK_Click;
        public Settings_editor()
        {
            InitializeComponent();
            comboBox1.Items.AddRange(new string[]{ "Круговая", "Олимпийская", "Швейцарская", "Смешанная"});
            comboBox2.Items.AddRange(new string[] { "очки", "кол-во побед", "коэф. Горина" });
            comboBox1.SelectedIndex = tvlData.gametype-1;
            comboBox2.SelectedIndex = MainForm.additional_sort - 1;
            textBox1.Text = tvlData.tournir_name;
            textBox2.Text = tvlData.tournir_place;
            dateTimePicker1.Value = DateTime.Today;
            dateTimePicker2.Value = DateTime.Today;
            textBox3.Text = tvlData.tournir_judges;
            textBox4.Text = tvlData.tournir_main_judge;
            textBox5.Text = tvlData.tournir_secretary;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int[] olymp_allowed = new int[] { 2, 4, 8, 16, 32, 64, 128 };
            if ((comboBox1.SelectedIndex == 1) && !(Array.BinarySearch(olymp_allowed, tvlData.players.Count) > 0))
            {
                MessageBox.Show("Несоответствие числа игроков требуемому\n{ 2, 4, 8, 16, 32, 64, 128 }\nВыберана смешанная система");
                comboBox1.SelectedIndex = 3;
            }
        }
        private void buttonOK_Click(object sender, EventArgs e)
        {
            tvlData.tournir_name = textBox1.Text;
            tvlData.tournir_place = textBox2.Text;
            tvlData.tournir_start_date = dateTimePicker1.Value.ToShortDateString();
            tvlData.tournir_finish_date = dateTimePicker2.Value.ToShortDateString();
            tvlData.tournir_judges = textBox3.Text;
            tvlData.tournir_main_judge = textBox4.Text;
            tvlData.tournir_secretary = textBox5.Text;

            tvlData.gametype = (comboBox1.SelectedIndex + 1);
            MainForm.additional_sort = (comboBox2.SelectedIndex + 1);
            MainForm.comands = checkBox1.Checked;
            if (onOK_Click != null)
                onOK_Click();
            this.Close();
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Visible = false;
            }
            base.OnFormClosing(e);
        }
        public void block()
        {
            if (MainForm.system_active)
            {
                comboBox1.Enabled = false;
                checkBox1.Enabled = false;
            }
        }

        private void Settings_editor_Load(object sender, EventArgs e)
        {

        }
    }
}
