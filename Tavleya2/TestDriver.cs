using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Tavleya2
{
    public partial class TestDriver : Form
    {
        public static int playerscount = 10;
        public static int system = 3;
        public delegate void MethodContainer();
        public event MethodContainer onOK_Click;
        public event MethodContainer onCLR_Click;
        public TestDriver()
        {
            InitializeComponent();
            numericUpDown1.Value = playerscount;
            numericUpDown2.Value = system;
            this.Show();
        }
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public static void playersinit()
        {
            string[] surn = new string[] { "Медведев", "Ершов", "Никитин", "Соболев", "Рябов", "Поляков", "Цветков", "Данилов", "Жуков", "Фролов", "Журавлёв", "Николаев", "Крылов", "Максимов", "Сидоров" };
            string[] nam = new string[] { "Александр", "Артем", "Максим", "Михаил", "Иван", "Даниил", "Дмитрий", "Матвей", "Андрей", "Кирилл" };
            string[] patr = new string[] { "Александрович", "Артемович", "Максимович", "Михаилович", "Иванович", "Даниилович", "Дмитриевич", "Матвеевич", "Андреевич", "Кириллович" };
            for (int i = tvlData.players.Count + 1; i <= playerscount; i++)
                tvlData.players.Add(new player(surn[random.Next(0, 15)], nam[random.Next(0, 10)], patr[random.Next(0, 10)], "М", "команда" + (i % 2 + 1), 1999, "Севастополь", "III", (random.Next(500, 1000) + 0.123)));
        }
        private void button1_Click(object sender, EventArgs e)
        {
            tvlData.tournir_name = "Финал Чемпионата Севастополя 2018 года по русским шашкам";
            tvlData.tournir_place = " г. Севастополь";
            tvlData.tournir_start_date = DateTime.Today.ToShortDateString();
            tvlData.tournir_finish_date = DateTime.Today.ToShortDateString();
            tvlData.tournir_judges = "Главный судья турнира: спортивный судья третьей категории Синявский Андрей Станиславович. \nГлавный секретарь турнира: спортивный судья третьей категории Саватеев Николай Владимирович. \nЗаместитель главного судьи турнира: спортивный судья первой категории Нижейко Ольга Аркадьевна. \nСудья турнира: спортивный судья первой категории Жолондковский Владимир Николаевич.";
            tvlData.tournir_main_judge = "Синявский А.С.";
            tvlData.tournir_secretary = "Саватеев Н.В.";


            playerscount = (Int32)numericUpDown1.Value;
            if ((Int32)numericUpDown2.Value > 0)
                tvlData.gametype = (Int32)numericUpDown2.Value;
            playersinit();
            listBox1.Items.Add("Added " + playerscount + "players. Game type is " + tvlData.gametype);
            if (onOK_Click != null)
                onOK_Click();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (onCLR_Click != null)
                onCLR_Click();
            listBox1.Items.Clear();
            listBox1.Items.Add("All data cleared");
        }
    }
}
