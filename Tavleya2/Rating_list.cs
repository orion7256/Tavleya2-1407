using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Tavleya2
{
    public partial class Rating_list : Form
    {
        public delegate void MethodContainer();
        public event MethodContainer onOK_Click;
        List<Short_player> Rlist = null;
        public Rating_list()
        {
            InitializeComponent();
            reLoad_data();
            Show();
            if (MainForm.system_active)
                Add_to_pl_btn.Enabled = false;
        }
        public void reLoad_data()
        {
            listView1.Items.Clear();
            if (listView1.Columns.Count == 0)
            {
                listView1.Columns.Add("№", 35);
                listView1.Columns.Add("Фамилия", 100);
                listView1.Columns.Add("Имя", 70);
                listView1.Columns.Add("отчество", 100);
                listView1.Columns.Add("Пол", 40);
                listView1.Columns.Add("Год", 40);
                listView1.Columns.Add("Рейт. Адам.", 80);
                listView1.Columns.Add("Команда", 70);
                listView1.Columns.Add("Город", 70);
                listView1.Columns.Add("Разряд", 55);
                listView1.Columns.Add("Разр. коэф", 45);
                listView1.Columns.Add("Метка", 60);
            }
            if (Rlist != null)
            {
                Rlist.Sort((a, b) => a.surname.CompareTo(b.surname));
                foreach (Short_player sp in Rlist)
                    listView1.Items.Add(new ListViewItem(sp.str()));
            }
        }
        public void convert_pl()
        {
            tvlData.short_players.Clear();
            foreach (player p in tvlData.players)
                tvlData.short_players.Add(new Short_player(p.surname, p.name, p.patronymic, p.gender, p.group, p.year, p.city, p.rank, p.rank_INDEX, p.Adam_list));
        }
        private void save_data(string file = "")
        {
            if (file == "")
            {
                file = $"{AppDomain.CurrentDomain.BaseDirectory}Отчеты" + Path.DirectorySeparatorChar + "Турнир " + DateTime.Now.ToString("dd-MM-yyyy hh.mm") + " Рейтинг-лист.tvrl";
            }
            Data2 d2 = new Data2();
            if (Rlist != null)
                d2.players = Rlist;
            SerializableObject obj = new SerializableObject();
            obj.Data2 = d2;
            MySerializer serializer = new MySerializer();
            serializer.SerializeObject(file, obj);
        }
        private void load_data(string file = "")
        {
            if (file == "")
                return;
            MySerializer serializer = new MySerializer();
            Data2 d2 = serializer.DeserializeObject(file).Data2;
            Rlist = d2.players;
            reLoad_data();
        }
        private void append_data(string file = "")
        {
            if (file == "")
                return;
            MySerializer serializer = new MySerializer();
            Data2 d2 = serializer.DeserializeObject(file).Data2;
            Rlist = new List<Short_player>(tvlData.short_players.Union(d2.players, new PlComparer()));
            reLoad_data();
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Tavleya files|*.tvrl";
            saveFileDialog1.Title = "Сохранить рейтинг-лист";
            saveFileDialog1.FileName = "Рейтинг-лист " + DateTime.Now.ToString("dd-MM-yyyy hh.mm");
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            if (saveFileDialog1.FileName != "")
                save_data(saveFileDialog1.FileName);
        }

        private void concat_btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Tavleya rating list|*.tvrl";
            openFileDialog1.Title = "Открыть рейтинг-лист";
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                append_data(openFileDialog1.FileName);
        }

        private void open_btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Tavleya rating list|*.tvrl";
            openFileDialog1.Title = "Открыть рейтинг-лист";
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                load_data(openFileDialog1.FileName);
        }

        private void Add_btn_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lit in listView1.Items)
            {
                if (lit.Checked)
                {
                    Short_player sp = Rlist[lit.Index];
                    player p = new player(sp.surname, sp.name, sp.patronymic, sp.gender, sp.group, sp.year, sp.city, sp.rank, sp.Adam_list[sp.Adam_list.Count - 1].Value);
                    p.Adam_list = sp.Adam_list;
                    tvlData.players.Add(p);
                }
            }
            if (onOK_Click != null)
                onOK_Click();
            this.Close();
        }

        private void search_btn_Click(object sender, EventArgs e)
        {
            string mask = "";
            mask = search_textBox.Text;
            if (mask == "")
                reLoad_data();
            else
            {
                foreach (ListViewItem lvi in listView1.Items)
                    if (lvi.BackColor != System.Drawing.Color.White)
                        lvi.BackColor = System.Drawing.Color.White;
                int startindex = 0;
                while (startindex != listView1.Items.Count)
                {
                    if (listView1.FindItemWithText(mask, true, startindex) != null)
                        listView1.FindItemWithText(mask, true, startindex).BackColor = System.Drawing.Color.Green;
                    startindex++;
                }
            }
        }

        private void Add_pl_btn_Click(object sender, EventArgs e)
        {
            Rlist = new List<Short_player>();
            convert_pl();
            Rlist.AddRange(tvlData.short_players);
            reLoad_data();
        }
    }
    class PlComparer : IEqualityComparer<Short_player>
    {
        public bool Equals(Short_player x, Short_player y)
        {
            //Check whether the compared objects reference the same data.
            if (Object.ReferenceEquals(x, y)) return true;

            //Check whether any of the compared objects is null.
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                return false;

            //Check whether the Short_players' properties are equal.
            return x.surname == y.surname && x.name == y.name && x.patronymic == y.patronymic && x.year == y.year;
        }
        public int GetHashCode(Short_player product)
        {
            //Check whether the object is null
            if (Object.ReferenceEquals(product, null)) return 0;

            //Get hash code for the Name field if it is not null.
            int hashSurn = product.surname == null ? 0 : product.surname.GetHashCode();
            int hashNam = product.name.GetHashCode();
            int hashPatr = product.patronymic.GetHashCode();
            int hashYr = product.year.GetHashCode();
            //Calculate the hash code for the product.
            return hashSurn ^ hashNam ^ hashPatr ^ hashYr;
        }

    }
}
