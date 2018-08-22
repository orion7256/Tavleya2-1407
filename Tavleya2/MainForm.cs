using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;


namespace Tavleya2
{
    public partial class MainForm : Form
    {
        public static int sort = 0; //параметр для сортировки (0 id)
        public static int additional_sort = 3; //доп параметр для сортировки
        public static bool comands = false; //отображение команд
        public static bool places_counted = false; //отображение разрядов и мест
        public static bool allowed_next = false; //разрешен след тур
        public static bool system_active = false; //проведена жеребьевка

        public static Settings_editor s;
        public static Reports rp;
        public static Round_table rt;
        public static Olympic_table ot;
        public static Swiss_table st;
        public static Mixed_table mt;

        public delegate void MethodContainer();
        public event MethodContainer onCount;   /// проведена жеребьевка

        public MainForm()
        {
            MinimumSize = new System.Drawing.Size(1100, 600);
            InitializeComponent();
            //тестированиеToolStripMenuItem.PerformClick();// убрать потом
            Refresh_playerstable();
            Chart_Init();
            refresh_game_table();
            rp = new Reports();
        }
        // files
        private void новыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Все данные будут стерты\nВы уверены?", "Внимание", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                tvlData.players = new List<player>();
                player.lastid = 0;
                game.lastid = 0;
                tvlData.games = new List<game>();
                refresh_game_table();
                SystemResults_listBox.Items.Clear();
                Chart_Init();
                Refresh_playerstable();
                Addbutton.Enabled = true;
                System_count_btn.Enabled = true;
            }
        }
        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Tavleya files|*.tvl";
            openFileDialog1.Title = "Открыть файл соревнований";
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                load_data(openFileDialog1.FileName);

        }
        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Tavleya files|*.tvl";
            saveFileDialog1.Title = "Сохранить файл соревнований";
            saveFileDialog1.FileName = "Турнир" + DateTime.Today.ToString("d");
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
                save_data(saveFileDialog1.FileName);
        }
        private void save_data(string file = "")
        {
            if (file == "")
            {
                file = $"{AppDomain.CurrentDomain.BaseDirectory}Отчеты" + Path.DirectorySeparatorChar + "Турнир " + DateTime.Today.ToString("d") + " autosave.tvl";
            }
            tvlData.zipdata();
            Data d = new Data();
            SerializableObject obj = new SerializableObject();
            obj.Data = d;
            MySerializer serializer = new MySerializer();
            serializer.SerializeObject(file, obj);
        }
        private void load_data(string file = "")
        {
            if (file == "")
                return;
            MySerializer serializer = new MySerializer();
            Data d = serializer.DeserializeObject(file).Data;
            tvlData.players = d.players;
            tvlData.games = d.games;
            tvlData.zipped = d.zipped;
            tvlData.unzipdata();
            tvlData.counted = d.counted;
            SystemResults_listBox.Items.AddRange(tvlData.counted.ToArray());

            System_count_btn.Enabled = false;
            Nextbutton.Enabled = false;
            Addbutton.Enabled = false;
            Editbutton.Enabled = false;
            Gone_button.Enabled = false;
            Tour_numericUpDown.Maximum = tvlData.counted.Count;
            MessageBox.Show(String.Join("\n", tvlData.zipped.ToArray()), file);
            places_counted = true;
            refresh_game_table();
            Refresh_playerstable();
            if (tvlData.gametype == 3)
                восстановлениеToolStripMenuItem.Enabled = true;
        }
        //end files
        //settings
        private void данныеТурнираToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (s == null)
                s = new Settings_editor();
            this.onCount += s.block;
            s.onOK_Click += Refresh_playerstable;
            s.Show();
        }
        //playerstable
        public void Refresh_playerstable()
        {
            if (PlayerslistView.Columns.Count == 0)
            {
                PlayerslistView.Columns.Add("ID", 35);
                PlayerslistView.Columns.Add("Фамилия", 100);
                PlayerslistView.Columns.Add("Имя", 70);
                PlayerslistView.Columns.Add("Год", 40);
                PlayerslistView.Columns.Add("Очки", 40);
                PlayerslistView.Columns.Add("Рейт. Адам.", 100);
                PlayerslistView.Columns.Add("К-т. Горина", 60);
                PlayerslistView.Columns.Add("Разряд", 55);
                PlayerslistView.Columns.Add("Метка", 45);
                PlayerslistView.Columns.Add("Команда", 70);
                PlayerslistView.Columns.Add("Нов. разряд", 80);
                PlayerslistView.Columns.Add("Место", 50);
            }
            if (PlayerslistView.Items.Count != tvlData.players.Count)
            {
                PlayerslistView.Items.Clear();
                for (int i = 0; i < tvlData.players.Count; i++)
                {
                    PlayerslistView.Items.Add(new ListViewItem(tvlData.players[i].str()));
                    if (tvlData.players[i].mark != "")
                        PlayerslistView.Items[PlayerslistView.Items.Count - 1].BackColor = System.Drawing.Color.Yellow;
                }
            }
            else
            {
                for (int i = 0; i < tvlData.players.Count; i++)
                {
                    if (PlayerslistView.Items[i] != new ListViewItem(tvlData.players[i].str()))
                    {
                        PlayerslistView.Items[i] = new ListViewItem(tvlData.players[i].str());
                        if (tvlData.players[i].mark != "")
                            PlayerslistView.Items[i].BackColor = System.Drawing.Color.Yellow;
                    }
                }
            }

            if (tvlData.players.Count > 0)
            {
                Draw_Chart1();
                Draw_Chart2(0);
            }
        }
        private void Addbutton_Click(object sender, EventArgs e)
        {
            AddEditPlayer aep = new AddEditPlayer(1);
            aep.onAddbutton_Click += this.Refresh_playerstable;
            Refresh_playerstable();
        }
        private void Editbutton_Click(object sender, EventArgs e)
        {
            if (PlayerslistView.SelectedIndices.Count > 0)
            {
                AddEditPlayer aep = new AddEditPlayer(2, PlayerslistView.SelectedIndices[0]);
                Refresh_playerstable();
                aep.onAddbutton_Click += this.Refresh_playerstable;
            }
        }
        private void Gone_button_Click(object sender, EventArgs e)
        {
            if (PlayerslistView.SelectedIndices.Count > 0)
            {
                int player = PlayerslistView.SelectedIndices[0];
                if (tvlData.players[player].mark != "фикт")
                {
                    if (tvlData.players[player].mark != "отс")
                        tvlData.players[player].mark = "отс";
                    else
                        tvlData.players[player].mark = "";
                }
                Refresh_playerstable();

            }
        }
        private void PlayerslistView_DoubleClick(object sender, EventArgs e)
        {
            if (PlayerslistView.SelectedIndices.Count > 0)
            {
                AddEditPlayer aep = new AddEditPlayer(3, PlayerslistView.SelectedIndices[0]);
            }
        }
        private void PlayerslistView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PlayerslistView.SelectedIndices.Count > 0)
                Draw_Chart1(PlayerslistView.SelectedIndices[0]);
        }
        private void PlayerslistView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            tvlData.main_sort(e.Column);
            tvlData.onSort += Refresh_playerstable;
            //Refresh_playerstable();
        }//sort table
        //end playerstable
        // charts
        public void Chart_Init()
        {
            if (tvlData.players.Count > 0)
            {
                Draw_Chart1();
                Draw_Chart2(0);
            }
            if (comboBox1.Items.Count == 0)
                comboBox1.Items.AddRange(new string[]
                    { "Адамовича", "Бухольца", "Рижский", "Горина", "Шмульяна-Дворковича", "Зоннеборна-Бергера", "Солкофа", "Усеченн. система Солкофа" });
            comboBox1.SelectedIndex = 0;
        }
        public void Draw_Chart1(int player_num = 1)
        {
            int player = MainForm.search_by_id(player_num);
            linkLabel1.Text = tvlData.players[player].ToString();// "Игрок 
            chart1.Series[0].Points.Clear();
            chart1.Show();
            foreach (KeyValuePair<DateTime, double> dd in tvlData.players[player].Adam_list)
            {
                chart1.Series[0].Points.AddXY(dd.Key.ToShortDateString(), dd.Value);
            }
        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (tvlData.players.Count > 0)
            {
                numericUpDown1.Maximum = tvlData.players.Count;
                Draw_Chart1((Int32)numericUpDown1.Value);
            }
        }
        public void Draw_Chart2(int coef_num)
        {
            chart2.Series[0].Points.Clear();
            chart2.ChartAreas[0].AxisX.Interval = 1;
            chart2.ChartAreas[0].AxisY.Interval = 100;
            chart2.Show();
            foreach (player p in tvlData.players)
            {
                if(coef_num!=0)
                    chart2.Series[0].Points.AddXY(p.id + " " + p.fio(), p.coef[coef_num]);
                else
                    chart2.Series[0].Points.AddXY(p.id + " " + p.fio(), p.Adam_new);
            }
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (tvlData.players.Count > 0)
            {
                AddEditPlayer aep = new AddEditPlayer(3, search_by_id((Int32)numericUpDown1.Value));
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Draw_Chart2(comboBox1.SelectedIndex);
        }
        // end charts
        //game table
        public void refresh_game_table()
        {
            int tour = (Int32)Tour_numericUpDown.Value;

            if (game_table.Columns.Count == 0)
            {
                game_table.Columns.Add("GID", 35);
                game_table.Columns.Add("Тур", 30);
                game_table.Columns.Add("Первый", 52);
                game_table.Columns.Add("Второй", 52);
                game_table.Columns.Add("Поб", 35);
                game_table.Columns.Add("Результат", 70);
            }

            game_table.Items.Clear();
            foreach (game g in tvlData.games)
                if ((g.round == tour) || (tour == 0))
                {
                    game_table.Items.Add(new ListViewItem(g.str()));
                    if (g.win != -1)
                        game_table.Items[game_table.Items.Count - 1].BackColor = System.Drawing.Color.LightGreen;
                }
        }
        private void winget_button_Click(object sender, EventArgs e)
        {
            winget wg = new winget((Int32)Tour_numericUpDown.Value);
            wg.onOK_Click += this.refresh_game_table;
            wg.onOK_Click += this.Coeff_count;
            wg.onSet_res += this.refresh_game_table;
        }
        private void Tour_numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            refresh_game_table();
        }
        private void Xbutton_Click(object sender, EventArgs e)
        {
            Tour_numericUpDown.Value = 0;
        }
        private void System_count_Click(object sender, EventArgs e)
        {
            if (onCount != null)
                onCount();
            if ((!system_active) && (tvlData.gametype != 0) && (tvlData.players.Count >= 2))
            {
                system_active = true;
                allowed_next = true;
                Addbutton.Enabled = false;
                switch (tvlData.gametype)
                {
                    case 1:
                        rt = new Round_table(tvlData.players.Count);
                        Nextbutton.Visible = false;
                        winget_button.Width = 238;
                        break;
                    case 2:
                        ot = new Olympic_table(tvlData.players.Count);
                        break;
                    case 3:
                        st = new Swiss_table();
                        break;
                    case 4:
                        mt = new Mixed_table();
                        break;
                }
                SystemResults_listBox.Items.AddRange(tvlData.counted.ToArray());
                if (tvlData.gametype!=1)
                    Tour_numericUpDown.Value = 1;
                Refresh_playerstable();
                System_count_btn.Enabled = false;
                System_count_btn.Visible = false;
                save_data();
                refresh_game_table();
            }
            else
                данныеТурнираToolStripMenuItem.PerformClick();
        }
        private void Nextbutton_Click(object sender, EventArgs e)
        {
            if (tvlData.gametype != 0)
            {
                switch (tvlData.gametype)
                {
                    case 1:
                        break;
                    case 2:
                        ot.next();
                        break;
                    case 3:
                        st.next();
                        break;
                    case 4:
                        mt.next();
                        break;
                }
                for (int i = SystemResults_listBox.Items.Count; i< tvlData.counted.Count; i++)
                    SystemResults_listBox.Items.Add(tvlData.counted[i]);
                SystemResults_listBox.SelectedIndex = tvlData.counted.Count - 1;
                Tour_numericUpDown.Maximum = tvlData.counted.Count+1;
                if (allowed_next)
                    Tour_numericUpDown.Value++;
                allowed_next = false;
                refresh_game_table();
                Refresh_playerstable();

            }
        }
        private void game_table_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (game_table.SelectedIndices.Count > 0)
            {
                for (int i = 0; i < PlayerslistView.Items.Count; i++)
                    PlayerslistView.Items[i].SubItems[0].Text = PlayerslistView.Items[i].SubItems[0].Text.Replace("*", "");
                foreach (int i in PlayerslistView.SelectedIndices)
                    PlayerslistView.Items[i].Selected = false;
                int first = search_by_id(Int32.Parse(game_table.SelectedItems[0].SubItems[2].Text));
                int second = search_by_id(Int32.Parse(game_table.SelectedItems[0].SubItems[3].Text));
                PlayerslistView.Items[first].SubItems[0].Text += "*";
                PlayerslistView.Items[second].SubItems[0].Text += "*";
                PlayerslistView.Items[first].Selected = true;
                PlayerslistView.Items[second].Selected = true;
                PlayerslistView.Focus();
            }
        }
        //end game table
        private void SystemResults_listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SystemResults_listBox.SelectedIndices.Count > 0)
                Tour_numericUpDown.Value = (Int32)SystemResults_listBox.SelectedIndex + 1;
        }
        private void SystemResults_listBox_DoubleClick(object sender, EventArgs e)
        {
            if (SystemResults_listBox.SelectedIndices.Count > 0)
                winget_button.PerformClick();
        }
        public void Coeff_count()
        {
            foreach (player p in tvlData.players)
                p.coefts_count();
            Refresh_playerstable();
            save_data();
        }
        public void Rank_count()
        {
            foreach (player p in tvlData.players)
                p.rank_count();
            save_data();
        }
        public void Places_count()
        {
            tvlData.players.Sort((a, b) => b.points.CompareTo(a.points));
            for (int j = 0; j < 3; j++)//sort by gorin
            {
                for (int i = 0; i < tvlData.players.Count - 1; i++)
                {
                    if (tvlData.players[i].points == tvlData.players[i + 1].points)
                    {
                        if (tvlData.players[i].coef[3] < tvlData.players[i + 1].coef[3])
                            tvlData.swap_players(i, i + 1);
                    }
                }
            }
            for (int i = 0; i < tvlData.players.Count; i++)
                tvlData.players[i].place = i + 1;
            save_data();
        }
        public static int search_by_id(int id)
        {
            for (int i = 0; i < tvlData.players.Count; i++)
                if (tvlData.players[i].id == id)
                    return i;
            return 0;
        }
        private void тестированиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TestDriver td = new TestDriver();
            td.onOK_Click += refresh_game_table;
            td.onOK_Click += Chart_Init;
            td.onOK_Click += Refresh_playerstable;
            td.onOK_Click += System_count_btn.PerformClick;
            td.onCLR_Click += новыйToolStripMenuItem.PerformClick;
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Тавлея 2\nV0.85b\nАндрей Коротков\n07.2018", "О программе");
        }

        private void посчитатьМестаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Places_count();
            Rank_count();
            places_counted = true;
            Refresh_playerstable();
        }

        private void генерироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rp.get_final_report();
        }

        private void справкиОРазрядахToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rp.Ref_report();
        }

        private void протоколТураToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rp.get_mid_report((Int32)Tour_numericUpDown.Value);
        }

        private void итоговыйПротоколToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tvlData.players.Sort((a, b) => a.place.CompareTo(b.place));
            rp.Protocol();
        }

        private void выполненияподтвержденияРазрядныхНормToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rp.Ranks();
        }

        private void рейтингЛистToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rating_list rl = new Rating_list();
            rl.onOK_Click += Refresh_playerstable;
        }

        private void дополнитьГодовойОтчетToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rp.Year_report();
        }

        private void восстановлениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            restore();
        }
        public void restore()
        {
            switch (tvlData.gametype)
            {
                case 1:
                    break;
                case 2:
                    ot = new Olympic_table(SystemResults_listBox.Items.Count);
                    break;
                case 3:
                    st = new Swiss_table(SystemResults_listBox.Items.Count);
                    break;
                case 4:
                    mt = new Mixed_table(SystemResults_listBox.Items.Count);
                    break;
            }
            game.lastid = tvlData.games.Last().id;
            allowed_next = true;
            System_count_btn.Visible = false;
            Nextbutton.Enabled = true;
        }
    }
}
