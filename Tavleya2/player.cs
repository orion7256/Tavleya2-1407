using System;
using System.Collections.Generic;

namespace Tavleya2
{
    [Serializable]
    public class player
    {
        public static int lastid = 0;
        public int id { get; }
        public string mark;
        public string surname;
        public string name;
        public string patronymic;
        public string group;
        public int year;
        public string gender;
        public string city;
        public string rank;
        public int rank_INDEX;
        public int rank_UP = -2;
        public double point_norm = 0;
        public double rank_coeft = 0;
        public string new_rank;
        public double Adam { get; set; }
        public double adam_new { get; set; }
        public double Adam_new { get { return adam_new; } set { adam_new = value; Adam_list.Add(new KeyValuePair<DateTime, double> (DateTime.Now, value)); } }
        public double points;
        public string pluses;
        public int place;
        public string[] ss { get { return str(); } }

        public List<KeyValuePair<DateTime, double>> Adam_list = new List<KeyValuePair<DateTime, double>>();
        public double[] coef = new double[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
        public List<int> games = new List<int>();
        public List<int> opponents = new List<int>();
        public List<int> wins = new List<int>();
        public List<int> lost = new List<int>();
        public List<int> mid = new List<int>();
        public static string[] ranks = new string[] { "ГМ", "МС", "КМС", "I", "II", "III", "Нет", "I юн", "II юн", "III юн", "Нет (юн)" };
        public player(string s = "", string n = "", string p = "", string gen = "", string com = "", int y = 0, string cit = "", string r = "", double adm = 0, string mk = "")
        {
            id = lastid + 1;
            lastid++;
            surname = s;
            name = n;
            patronymic = p;
            gender = gen;
            group = com;
            year = y;
            city = cit;
            rank = r;
            mark = mk;
            if (Adam_list.Count==0)
                Adam_list.Add(new KeyValuePair<DateTime, double>(DateTime.Now, adm));
            Adam = adm;
            //Adam_new = adm;
            place = 0;
            pluses = "";
            new_rank = "";

            switch (r)
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
        }
        public override string ToString()
        {
            string mrk = "";
            if (mark != "")
                mrk = " [" + mark + "]";
            return id.ToString() + "  " + surname + "  " + name + "  " + patronymic + " (" + year + ", " + city + ")" + mrk;
        }
        public string fio()
        {
            return surname + " " + name[0] + "." + patronymic[0] + ".";
        }
        public string[] str()
        {
            string[] ss = new string[12];
            ss[0] = id.ToString();
            ss[1] = surname;
            ss[2] = name;
            ss[3] = year.ToString();
            ss[4] = points.ToString();
            ss[5] = Adam.ToString() + " / " + Adam_new.ToString();
            ss[6] = coef[3].ToString();
            ss[7] = rank;
            ss[8] = mark;
            ss[9] = group;
            ss[10] = new_rank;
            ss[11] = place.ToString();
            return ss;
        }
        public void coefts_count()
        {
            opponents.Clear();
            opponents.AddRange(wins);
            opponents.AddRange(mid);
            opponents.AddRange(lost);
            int j;
            if (opponents.Count == 0)
                return;
            //points = wins.Count * 2 + mid.Count;
            //adam
            double SR = 0;
            int adamN = 0;
            int adamM = 0;
            foreach (int i in opponents)
                if (i>0)
                    SR += tvlData.players[MainForm.search_by_id(i)].Adam;

            adamN = wins.Count + lost.Count + mid.Count;
            adamM = adamN;
            Adam_new = Math.Round((((Adam * 20) + SR + (5000 / 15) * (points - adamN)) / (20 + adamM)), 3);
            //buholz
            double sr2 = 0;
            if (opponents[0] < 0)
                j = opponents[0] * (-1);
            else j = opponents[0];
            double max = tvlData.players[MainForm.search_by_id(j)].points;
            double min = tvlData.players[MainForm.search_by_id(j)].points;

            foreach (int i in opponents)
            {
                if (i < 0)
                    j = i * (-1);
                else j = i;
                sr2 += tvlData.players[MainForm.search_by_id(j)].points;
                if (tvlData.players[MainForm.search_by_id(j)].points > max)
                    max = tvlData.players[MainForm.search_by_id(j)].points;
                if (tvlData.players[MainForm.search_by_id(j)].points < min)
                    min = tvlData.players[MainForm.search_by_id(j)].points;
            }
            coef[1] = Math.Round(sr2, 3);
            //rijsk
            double sw = 0;
            double sl = 0;
            double sm = 0;
            foreach (int i in wins)
            {
                if (i < 0)
                    j = i * (-1);
                else j = i;
                sw += tvlData.players[MainForm.search_by_id(j)].points;
            }
            foreach (int i in lost)
            {
                if (i < 0)
                    j = i * (-1);
                else j = i;
                sl += tvlData.players[MainForm.search_by_id(i)].points;
            }
            foreach (int i in mid)
            {
                if (i < 0)
                    j = i * (-1);
                else j = i;
                sm += tvlData.players[MainForm.search_by_id(i)].points;
            }
            coef[2] = Math.Round((2 * sw + 1.5 * sm + sl), 3);
            //gorin
            coef[3] = Math.Round((4 * sw + 2 * sm + sl), 3);
            //smulyan dvorkovich
            coef[4] = Math.Round(Math.Abs(sw - sl), 3);
            //zonneborn berger
            coef[5] = Math.Round((2 * sw + sm), 3);
            //solkof
            coef[6] = Math.Round((sr2 - max - min), 3);
            //solkof cut
            coef[7] = Math.Round((sr2 - min), 3);
        }
        public void rank_count()
        {
            double RoundToFraction(double value, double fraction)
            {
                return Math.Round(value / fraction) * fraction;
            }

            int[,] evsk = new int[,]
                {
                    {-3, 0, 1,  2,  3,  3,  4,  5},
                    {-2,20, 5,  0,  0,  0,  0,  0},
                    {-1,35, 20, 5,  0,  0,  0,  0},
                    {0, 50, 35, 20, 5,  5,  0,  0},
                    {1, 65, 50, 35, 20, 20, 5,  0},
                    {2, 80, 65, 50, 35, 35, 20, 5},
                    {3, 95, 80, 65, 50, 50, 35, 20},
                    {4, 0,  95, 80, 65, 65, 50, 35},
                    {5, 0,  0,  95, 80, 80, 65, 50},
                    {6, 0,  0,  0,  95, 95, 75, 60},
                    {0, 1,  2,  3,  4,  4,  5,  6}
                };

            rank_coeft = 0;
            point_norm = 0;

            foreach (int i in opponents)
            {
                if(i>0)
                    rank_coeft += tvlData.players[MainForm.search_by_id(i)].rank_INDEX;
            }
            rank_coeft = Math.Ceiling(rank_coeft / opponents.Count);//Результат и будет необходимым турнирным коэффициентом

            if ((rank_coeft - (rank_INDEX + 1)) > 0)//Если результат больше 0, то подсчитывается разряд на ступеньку ниже
            {
                rank_coeft++;
                rank_UP = 0;
            }

            int column = (Int32)rank_coeft;
            int row = 0;
            if ((column == 4) && (rank != "III"))
                column++;
            foreach (int i in opponents)
            {
                row = (tvlData.players[MainForm.search_by_id(i)].rank_INDEX + 3);
                point_norm += (double)evsk[row, column] / 100;
            }
            point_norm = RoundToFraction(point_norm, 0.5) * 2;//Сумма этих вычислений и есть разрядная норма

            if ((points >= point_norm) && (rank_UP == -2))//Если набранные очки больше или равны разрядной норме, то считается, что участник соревнования выполнил норму 
                rank_UP = 1;// 1 green // 0 black // -1 red
            if ((points <= point_norm) && (rank_UP == 0))
                rank_UP = -1;//////////////////////////////////////////////СОХРАНЯТЬ
            if (rank_UP == -1)
                new_rank = ranks[Array.IndexOf(ranks, rank) + 1];
            else new_rank = rank;
        }
    }

    [Serializable]
    public class Short_player
    {

        public string mark;
        public string surname;
        public string name;
        public string patronymic;
        public string group;
        public int year;
        public string gender;
        public string city;
        public string rank;
        public int rank_INDEX;
        public string[] ss { get { return str(); } }

        public List<KeyValuePair<DateTime, double>> Adam_list = new List<KeyValuePair<DateTime, double>>();
        public Short_player(string s = "", string n = "", string p = "", string gen = "", string com = "", int y = 0, string cit = "", string r = "", int ri = 0, List<KeyValuePair<DateTime, double>> adm = null, string mk = "")
        {
            surname = s;
            name = n;
            patronymic = p;
            gender = gen;
            group = com;
            year = y;
            city = cit;
            rank = r;
            rank_INDEX = ri;
            mark = mk;
            foreach (KeyValuePair<DateTime, double> av in adm)
                Adam_list.Add(new KeyValuePair<DateTime, double> (av.Key, av.Value));
        }
        public string[] str()
        {
            string[] ss = new string[12];
            ss[0] = "";
            ss[1] = surname;
            ss[2] = name;
            ss[3] = patronymic;
            ss[4] = gender;
            ss[5] = year.ToString();
            ss[6] = Adam_list[Adam_list.Count -1].Value.ToString();
            ss[7] = group;
            ss[8] = city;
            ss[9] = rank;
            ss[10] = rank_INDEX.ToString();
            ss[11] = mark;
            return ss;
        }        
    }
}


