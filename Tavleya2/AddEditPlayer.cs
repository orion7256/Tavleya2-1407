using System;
using System.Linq;
using System.Windows.Forms;

namespace Tavleya2
{
    public partial class AddEditPlayer : Form
    {
        bool success = false;
        private player pl;
        private int mode;
        private int id;
        public AddEditPlayer(int mmode = 1, int iid = 0)
        {
            if (((tvlData.players.Count < iid + 1)&&((mmode == 2)||(mmode ==3)))||(iid<0)||(mmode>3)||(mmode<1))
                return;

            mode = mmode;
            id = iid;
            InitializeComponent();
            RankcomboBox.Items.AddRange(new string[] { "Нет", "Нет (юн)", "I", "II", "III", "I юн", "II юн", "III юн", "КМС", "МС", "ГМ" });
            SexcomboBox.Items.AddRange(new string[] { "М", "Ж"});
            this.Height = 211;
            init();
            this.Show();
        }

        public delegate void MethodContainer();
        public event MethodContainer onAddbutton_Click;

        public void init()
        {
            if (mode == 1)//add
            {
                if (tvlData.players.Count == 0)
                    this.Text = "Добавление участника ID: " + (0 + 1);
                else
                    this.Text = "Добавление участника ID: " + (tvlData.players.Last().id + 1);
                Addbutton.Text = "Добавить";
                CitytextBox.Text = "Севастополь";
                RankcomboBox.SelectedIndex = 0;
                SexcomboBox.SelectedIndex = 0;
                Plusbutton.Enabled = false;
                button_next.Enabled = false;
                button_prev.Enabled = false;
            }
            if (mode == 2 || mode == 3)//edit or view (data load)
            {
                this.Text = "Редактирование данных участника ID: " + (tvlData.players[id].id);
                Addbutton.Text = "Сохранить";
                pl = tvlData.players[id];
                SNtextBox.Text = pl.surname;
                NtextBox.Text = pl.name;
                PtextBox.Text = pl.patronymic;
                CommandtextBox.Text = pl.group;
                YeartextBox.Text = pl.year.ToString();
                CitytextBox.Text = pl.city.ToString();
                RankcomboBox.Text = pl.rank;
                SexcomboBox.Text = pl.gender;
                Adam1textBox.Text = pl.Adam.ToString();
                Adam2textBox.Text = pl.Adam_new.ToString();
                //coefts
                Bcoef.Text = pl.coef[1].ToString();
                Rcoef.Text = pl.coef[2].ToString();
                Gcoef.Text = pl.coef[3].ToString();
                SDcoef.Text = pl.coef[4].ToString();
                ZBcoef.Text = pl.coef[5].ToString();
                Scoef.Text = pl.coef[6].ToString();
                cScoef.Text = pl.coef[7].ToString();
                //adv
                points_textBox.Text = pl.points.ToString();
                Pluses_textBox.Text = pl.pluses;
                games_textBox.Text = String.Join(", ", pl.games.ToArray());
                win_textBox.Text = String.Join(", ", pl.wins.ToArray());
                mid_textBox.Text = String.Join(", ", pl.mid.ToArray());
                lost_textBox.Text = String.Join(", ", pl.lost.ToArray());
                mark_textBox.Text = pl.mark;
            }
            if (mode == 3)//view
            {
                this.Height = 375;
                Addbutton.Text = "Закрыть";
                this.Text = "Просмотр данных участника ID: " + (tvlData.players[id].id);
                SNtextBox.ReadOnly = true;
                NtextBox.ReadOnly = true;
                PtextBox.ReadOnly = true;
                SexcomboBox.Enabled = false;
                RankcomboBox.Enabled = false;
                YeartextBox.ReadOnly = true;
                CommandtextBox.ReadOnly = true;
                CitytextBox.ReadOnly = true;
                Adam1textBox.ReadOnly = true;
                Adam2textBox.ReadOnly = true;
            }
        }
        public void clear_data()
        {
            SNtextBox.Text = "";
            NtextBox.Text = "";
            PtextBox.Text = "";
            CommandtextBox.Text = "";
            YeartextBox.Text = "";
            CitytextBox.Text = "";
            Adam1textBox.Text = "";
            Adam2textBox.Text = "";
            success = false;
        }
        private string check_double(string s)
        {
            char[] a = new char[100];
            string ss = "";
            a = s.ToCharArray();
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (a[i].ToString() == j.ToString())
                        ss += a[i];
                }
                if (a[i] == '.')
                    ss += ',';
                if (a[i] == ',')
                    ss += a[i];
            }
            if (s!=ss)
                MessageBox.Show("Ошибка вводимых данных: " + s + " приведено к " + ss);
            return ss;
        }
        private void Add()
        {
            try
            {
                if (SNtextBox.Text == "" || NtextBox.Text == "" || PtextBox.Text == "")
                    throw new Exception("ФИО");
                int year = 0;
                Int32.TryParse(YeartextBox.Text, out year);
                if (year < 1935 || year > 2050)
                    throw new Exception("год");
                if (CitytextBox.Text == "")
                    throw new Exception("город");
                double adam;
                Double.TryParse(Adam1textBox.Text, out adam);
                tvlData.players.Add(new player(SNtextBox.Text, NtextBox.Text, PtextBox.Text, SexcomboBox.SelectedItem.ToString(), CommandtextBox.Text, year, CitytextBox.Text, RankcomboBox.SelectedItem.ToString(), adam));
                success = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка вводимых данных: " + ex.Message);
            }
        }
        private void Edit()
        {
            try
            {
                if (SNtextBox.Text == "" || NtextBox.Text == "" || PtextBox.Text == "")
                    throw new Exception("ФИО");
                int year = 0;
                Int32.TryParse(YeartextBox.Text, out year);
                if (year < 1935 || year > 2050)
                    throw new Exception("год");
                if (CitytextBox.Text == "")
                    throw new Exception("город");
                double adam;
                Double.TryParse(Adam1textBox.Text, out adam);

                pl.surname = SNtextBox.Text;
                pl.name = NtextBox.Text;
                pl.patronymic = PtextBox.Text;
                pl.gender = SexcomboBox.SelectedItem.ToString();
                pl.group = CommandtextBox.Text;
                pl.year = year;
                pl.city = CitytextBox.Text;
                pl.rank = RankcomboBox.SelectedItem.ToString();
                pl.Adam_new = adam;
                int rank_INDEX =0;
                switch (RankcomboBox.SelectedItem.ToString())
                {
                    case "ГМ": rank_INDEX = -2; break;
                    case "МС": rank_INDEX = -1; break;
                    case "КМС": rank_INDEX = 0; break;
                    case "I": rank_INDEX = 1; break;
                    case "II": rank_INDEX = 2; break;
                    case "III": rank_INDEX = 3; break;
                    case "Нет": rank_INDEX = 4; break;
                    case "I юн": rank_INDEX = 3; break;
                    case "II юн": rank_INDEX = 4; break;
                    case "III юн": rank_INDEX = 5; break;
                    case "Нет (юн)": rank_INDEX = 6; break;
                }
                pl.rank_INDEX = rank_INDEX;
                tvlData.players[id] = pl;
                success = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка вводимых данных: " + ex.Message);
            }
        }
        private void Addbutton_Click(object sender, EventArgs e)
        {
            if (mode == 1)           
                Add();
            
            if (mode == 2)            
                Edit();
            
            if (success)
            {
                if (onAddbutton_Click!=null)
                    onAddbutton_Click();
                if (mode != 3)
                {
                    clear_data();
                    init();
                }
                    init();
            }
            if (mode == 3)
            {
                this.Close();
            }
        }
        private void Plusbutton_Click(object sender, EventArgs e)
        {
            if (this.Height == 211)
                this.Height = 375;
            else
                this.Height = 211;
        }
        private void button_next_Click(object sender, EventArgs e)
        {
            if ((id + 2) == tvlData.players.Count)
                button_next.Enabled = false;
            if (button_prev.Enabled == false)
                button_prev.Enabled = true;
            {
                id++;
                init();
            }
        }
        private void button_prev_Click(object sender, EventArgs e)
        {
            if ((id - 1) == 0)
                button_prev.Enabled = false;
            if(button_next.Enabled == false)
                button_next.Enabled = true;
            {
                id--;
                init();
            }
        }


    }
}
