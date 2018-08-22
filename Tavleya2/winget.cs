using System;
using System.Windows.Forms;

namespace Tavleya2
{
    public partial class winget : Form
    {
        int tour;
        int lastitem = 0;
        int topitem = 0;
        int first = 0;
        int second = 0;
        int start = 0;
        int finish = 0;
        public delegate void MethodContainer();
        public event MethodContainer onOK_Click;
        public event MethodContainer onSet_res;
        public winget(int tur = 0, bool read_only = false)
        {
            if ((tur < 0) || (tvlData.games.Count == 0) || (tvlData.games[tvlData.games.Count - 1].round < tur))
                return;
            InitializeComponent();
            tour = tur;
            if (tour == 0)
            {
                start = 0;
                finish = tvlData.games.Count;
            }
            else
                for (int i = 0; i < tvlData.games.Count; i++)
                {
                    if ((tvlData.games[i].round == tour) && (start == 0))
                        start = i;
                    if ((tvlData.games[i].round == tour + 1) && (finish == 0))
                        finish = i;
                }
            if (tour == 1)
                start = 0;
            if (tvlData.games[tvlData.games.Count - 1].round == tour)
                finish = tvlData.games.Count;

            this.Text = "Тур " + tour;
            if (read_only)
            {
                buttonOK.Enabled = false;
                groupBox2.Enabled = false;
            }

            KeyPreview = true;
            refreshtable();
            Show();
        }
        private void block(int mode = 1)
        {
            if (mode == 1)
            {
                button1.Enabled = false;
                button2.Enabled = false;
                button0.Enabled = false;
                Midbutton.Enabled = false;
                if (tvlData.players[first].mark != "")
                    groupBox1.BackColor = System.Drawing.Color.Yellow;
                if (tvlData.players[second].mark != "")
                    groupBox3.BackColor = System.Drawing.Color.Yellow;
            }
            if (mode == 2)
            {
                button1.Enabled = true;
                button2.Enabled = true;
                button0.Enabled = true;
                Midbutton.Enabled = true;
                groupBox1.BackColor = System.Drawing.SystemColors.Control;
                groupBox3.BackColor = System.Drawing.SystemColors.Control;
                if (tvlData.gametype == 2)//olympic
                    olymp_block();
            }
        }
        private void olymp_block()
        {
            Midbutton.Enabled = false;
            button0.Enabled = false;
        }
        private void setplus()
        {

            if ((tvlData.players[first].mark != "") && (tvlData.players[second].pluses == ""))
            {

                tvlData.players[second].pluses += "+";
                set_result(0, 0);
            }

            if ((tvlData.players[second].mark != "") && (tvlData.players[first].pluses == ""))
            {

                tvlData.players[first].pluses += "+";
                set_result(0, 0);
            }
        }
        private void refreshtable(bool next = false)
        {
            if (listView1.SelectedIndices.Count > 0)
                lastitem = listView1.SelectedIndices[0];

            if (listView1.Columns.Count == 0)
            {
                listView1.Columns.Add("GID", 40);
                listView1.Columns.Add("Тур", 40);
                listView1.Columns.Add("Первый", 67);
                listView1.Columns.Add("Второй", 67);
                listView1.Columns.Add("Поб", 35);
                listView1.Columns.Add("Результат", 85);
            }

            if (listView1.Items.Count == 0)//first time adding
                for (int i = start; i < finish; i++)
                {
                    game g = tvlData.games[i];
                    listView1.Items.Add(new ListViewItem(g.str()));
                    if (g.win != -1)
                        listView1.Items[i - start].BackColor = System.Drawing.Color.LightGreen;
                }

            for (int i = start; i < finish; i++)//updating
            {
                game g = tvlData.games[i];
                if (listView1.Items[i - start] != new ListViewItem(g.str()))
                {
                    listView1.Items[i - start] = new ListViewItem(g.str());
                    if (g.win != -1)
                        listView1.Items[i - start].BackColor = System.Drawing.Color.LightGreen;
                }
            }

            if (listView1.Items.Count > 0)//selected item switch
            {
                if (next)
                {
                    if (lastitem + 1 < listView1.Items.Count)
                    {
                        lastitem++;
                        if (lastitem % 10 == 9)
                            topitem = lastitem - 1;
                    }
                }
                listView1.TopItem = listView1.Items[topitem];
                listView1.Items[lastitem].Selected = true;
            }
            else
            {
                buttonOK.Enabled = false;
                groupBox2.Enabled = false;
            }
            listView1.Focus();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            set_result(2, 0);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            set_result(0, 2);
        }
        private void Midbutton_Click(object sender, EventArgs e)
        {
            set_result(1, 1);
        }
        private void button0_Click(object sender, EventArgs e)
        {
            set_result(0, 0);
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (tvlData.players.Count > 0)
            {
                AddEditPlayer aep = new AddEditPlayer(3, first);
                aep.Show();
            }
        }
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (tvlData.players.Count > 0)
            {
                AddEditPlayer aep = new AddEditPlayer(3, second);
                aep.Show();
            }
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count > 0)
            {
                lastitem = listView1.SelectedIndices[0];
                first = MainForm.search_by_id(Int32.Parse(listView1.SelectedItems[0].SubItems[2].Text));
                second = MainForm.search_by_id(Int32.Parse(listView1.SelectedItems[0].SubItems[3].Text));
                linkLabel1.Text = tvlData.players[first].ToString();
                linkLabel2.Text = tvlData.players[second].ToString();

                if ((tvlData.players[first].mark != "") || (tvlData.players[second].mark != ""))
                    block(1);
                else
                    block(2);
            }
        }
        private void buttonOK_Click(object sender, EventArgs e)
        {
            bool done_flag = true;
            for (int i = start; i < finish; i++)
            {
                if (tvlData.games[i].win == -1)
                    done_flag = false;
            }
            if (done_flag)
            {
                MainForm.allowed_next = true;
                if (onOK_Click != null)
                    onOK_Click();
                this.Close();
            }
        }
        private void winget_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.NumPad1) || (e.KeyCode == Keys.D1))
            {
                button1.PerformClick();// имитируем нажатие button1
            }
            if ((e.KeyCode == Keys.NumPad2) || (e.KeyCode == Keys.D2))
            {
                button2.PerformClick();// имитируем нажатие button2
            }
            if ((e.KeyCode == Keys.NumPad3) || (e.KeyCode == Keys.D3))
            {
                Midbutton.PerformClick();// имитируем нажатие Midbutton
            }
            if ((e.KeyCode == Keys.NumPad0) || (e.KeyCode == Keys.D0))
            {
                button0.PerformClick();// имитируем нажатие button0
            }
            if (e.KeyCode == Keys.Enter)
            {
                buttonOK.PerformClick();// имитируем нажатие OK
            }
            e.SuppressKeyPress = true;
        }
        private void set_result(int a = 0, int b = 0, int pluses = 0)
        {
            if (listView1.SelectedIndices.Count > 0)
            {
                tvlData.games[Int32.Parse(listView1.Items[lastitem].SubItems[0].Text) - 1].setwin(a, b, pluses);
                refreshtable(true);
                if (onSet_res != null)
                    onSet_res();
            }
        }

        private void pl1_button_Click(object sender, EventArgs e)
        {
            set_result(0, 0, 1);
        }

        private void minus1_button_Click(object sender, EventArgs e)
        {
            set_result(0, 0, -1);
        }

        private void pl2_button_Click(object sender, EventArgs e)
        {
            set_result(0, 0, 2);
        }

        private void minus2_button_Click(object sender, EventArgs e)
        {
            set_result(0, 0, -2);
        }
    }
}

