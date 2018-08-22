using System.Collections.Generic;
using System.Windows.Forms;

namespace Tavleya2
{
    public partial class Swiss_table
    {
        int playerscount = tvlData.players.Count;
        public int tourscount = 0;
        public int tour_n = 0;
        int last_type = 0;
        public bool finish = false;
        string tempstr = "";
        public Swiss_table(int lasttyperest = 0)
        {
            if ((tvlData.players.Count % 2) != 0)
                tvlData.players.Add(new player("Свободный", "Имя", "Отчествао", "F", "команда", 2000, "Севастополь", "Нет", 0, "фикт"));
            get_rounds_count(playerscount);
            last_type = lasttyperest;
            tour_n = lasttyperest;
            if (tourscount != 0)
                next();
        }
        private void get_rounds_count(int playerscount)
        {
            if (playerscount < 10)
            {
                tourscount = 0;
                MessageBox.Show("Недостаточно игроков для данной системы");
            }
            if (playerscount == 10)
                tourscount = 6;
            if ((playerscount > 10) && (playerscount <= 20))
            {
                if (playerscount % 2 == 1)
                    MessageBox.Show("необходимо добавить 1 тур дополнительно\n чтобы все участники имели возможность выполнить разрядную норму");
                tourscount = 7; //+1
            }
            if ((playerscount > 20) && (playerscount <= 30))
                tourscount = 8;
            if ((playerscount > 30) && (playerscount <= 40))
                tourscount = 9;
            if ((playerscount > 40) && (playerscount <= 50))
                tourscount = 10;
            if (playerscount > 50)
                tourscount = 11;
        }
        private void check_pair(int a, int b)//swap if exist
        {
            foreach (game g in tvlData.games)
                if (((g.first == a) && (g.second == b)) || ((g.first == b) && (g.second == a)))
                {
                    if (b != tvlData.players.Count - 1)
                    {
                        int p_num = MainForm.search_by_id(b);
                        player temp = tvlData.players[p_num];
                        tvlData.players[p_num] = tvlData.players[p_num + 1];
                        tvlData.players[p_num + 1] = temp;
                    }
                    else
                    {
                        int p_num = MainForm.search_by_id(a);// zero sometimes
                        player temp = tvlData.players[p_num];
                        tvlData.players[p_num] = tvlData.players[p_num - 1];
                        tvlData.players[p_num - 1] = temp;
                    }
                }
        }
        public bool allow_next()
        {
            foreach (game g in tvlData.games)
                if (g.win == -1)
                    return false;
            return true;
        }
        public void next()
        {
            if ((!finish) && (tourscount != 0))
            {
                if (MainForm.allowed_next)
                {
                    switch (last_type)
                    {
                        case 0: first_round(); break;
                        case 1: second_round(); break;
                        default: oneplus_round(); break;
                    }
                    MainForm.allowed_next = false;
                }
                if (tour_n == tourscount)
                    finish = true;
            }
        }
        public void first_round()
        {
            tour_n = 1;
            tvlData.main_sort(5);
            int sixes = playerscount / 6;
            int remain = playerscount - sixes * 6;
            for (int shift = 0; shift <= sixes * 6; shift += 6)
            {
                if (shift < sixes * 6)
                {
                    add(tvlData.players[1 - 1 + shift].id, tvlData.players[4 - 1 + shift].id, tour_n);
                    add(tvlData.players[2 - 1 + shift].id, tvlData.players[5 - 1 + shift].id, tour_n);
                    add(tvlData.players[3 - 1 + shift].id, tvlData.players[6 - 1 + shift].id, tour_n);
                    /*
                    tvlData.games.Add(new game(tvlData.players[1 - 1 + shift].id, tvlData.players[4 - 1 + shift].id, r: tour_n));
                    tempstr += tvlData.players[1 - 1 + shift].id + ":" + tvlData.players[4 - 1 + shift].id + "   ";
                    tvlData.games.Add(new game(tvlData.players[2 - 1 + shift].id, tvlData.players[5 - 1 + shift].id, r: tour_n));
                    tempstr += tvlData.players[2 - 1 + shift].id + ":" + tvlData.players[5 - 1 + shift].id + "   ";
                    tvlData.games.Add(new game(tvlData.players[3 - 1 + shift].id, tvlData.players[6 - 1 + shift].id, r: tour_n));
                    tempstr += tvlData.players[3 - 1 + shift].id + ":" + tvlData.players[6 - 1 + shift].id + "   ";
                    */
                }
                else
                {
                    if (remain % 2 == 1)
                    {
                        tvlData.players[playerscount - 1].pluses += "+";///WTF
                        tempstr += tvlData.players[playerscount - 1].id + "[+] ";
                        remain--;
                    }
                    if (remain == 4)
                    {
                        add(tvlData.players[1 - 1 + shift].id, tvlData.players[3 - 1 + shift].id, tour_n);
                        add(tvlData.players[2 - 1 + shift].id, tvlData.players[4 - 1 + shift].id, tour_n);
                        /*
                        tvlData.games.Add(new game(tvlData.players[1 - 1 + shift].id, tvlData.players[3 - 1 + shift].id, r: tour_n));
                        tempstr += tvlData.players[1 - 1 + shift].id + ":" + tvlData.players[3 - 1 + shift].id + "   ";
                        tvlData.games.Add(new game(tvlData.players[2 - 1 + shift].id, tvlData.players[4 - 1 + shift].id, r: tour_n));
                        tempstr += tvlData.players[2 - 1 + shift].id + ":" + tvlData.players[4 - 1 + shift].id + "   ";
                        */
                    }
                    if (remain == 2)
                    {
                        add(tvlData.players[1 - 1 + shift].id, tvlData.players[3 - 1 + shift].id, tour_n);
                        add(tvlData.players[2 - 1 + shift].id, tvlData.players[4 - 1 + shift].id, tour_n);
                        /*
                        tvlData.games.Add(new game(tvlData.players[1 - 1 + shift].id, tvlData.players[3 - 1 + shift].id, r: tour_n));
                        tempstr += tvlData.players[1 - 1 + shift].id + ":" + tvlData.players[3 - 1 + shift].id + "   ";
                        tvlData.games.Add(new game(tvlData.players[2 - 1 + shift].id, tvlData.players[4 - 1 + shift].id, r: tour_n));
                        tempstr += tvlData.players[2 - 1 + shift].id + ":" + tvlData.players[4 - 1 + shift].id + "   ";
                        */
                    }
                }
            }
            tempstr = "  " + tour_n + " тур: " + tempstr;
            tvlData.counted.Add(tempstr);
            tempstr = "";
            last_type = 1;
        }
        public void second_round()
        {
            tour_n = 2;
            MainForm.additional_sort = 3;
            tvlData.main_sort(5);

            int quards = playerscount / 4;
            int remain = playerscount - quards * 4;
            for (int shift = 0; shift <= quards*4; shift+=4)
            {
                if (shift < quards * 4)
                {
                    add(tvlData.players[1 - 1 + shift].id, tvlData.players[3 - 1 + shift].id, tour_n);
                    add(tvlData.players[2 - 1 + shift].id, tvlData.players[4 - 1 + shift].id, tour_n);
                    /*
                    tvlData.games.Add(new game(tvlData.players[1 - 1 + shift].id, tvlData.players[3 - 1 + shift].id, r: tour_n));
                    tempstr += tvlData.players[1 - 1 + shift].id + ":" + tvlData.players[3 - 1 + shift].id + "   ";
                    tvlData.games.Add(new game(tvlData.players[2 - 1 + shift].id, tvlData.players[4 - 1 + shift].id, r: tour_n));
                    tempstr += tvlData.players[2 - 1 + shift].id + ":" + tvlData.players[4 - 1 + shift].id + "   ";
                    */
                }
                else
                {
                    if (remain % 2 == 1)//
                    {
                        tvlData.players[playerscount - 1].pluses += "+";
                        tempstr += tvlData.players[playerscount - 1].id + "[+] ";
                        remain--;
                    }
                    if (remain == 2)
                    {
                        add(tvlData.players[1 - 1 + shift].id, tvlData.players[2 - 1 + shift].id, tour_n);
                        /*
                        tvlData.games.Add(new game(tvlData.players[1 - 1 + shift].id, tvlData.players[2 - 1 + shift].id, r: tour_n));
                        tempstr += tvlData.players[1 - 1 + shift].id + ":" + tvlData.players[2 - 1 + shift].id + "   ";
                        */
                    }
                }
            }
            tempstr = "  " + tour_n + " тур: " + tempstr;
            tvlData.counted.Add(tempstr);
            tempstr = "";
            last_type = 2;
        }
        public void oneplus_round()
        {
            tour_n++;

            MainForm.additional_sort = 3;
            tvlData.main_sort(4);

            for (int i = 0, j = tvlData.players.Count-1; ; )
            {
                add(tvlData.players[i].id, tvlData.players[i + 1].id, tour_n);
                i += 2;
                add(tvlData.players[j].id, tvlData.players[j - 1].id, tour_n);
                j -= 2;
                if ((i + 1) == j)
                {
                    add(tvlData.players[j].id, tvlData.players[j - 1].id, tour_n);
                    break;
                }
            }
            if (tour_n < 10)
                tempstr = "  " + tour_n + " тур: " + tempstr;
            else
                tempstr = tour_n + " тур: " + tempstr;
            tvlData.counted.Add(tempstr);
            tempstr = "";
        }
        private void add(int a, int b, int t)
        {
            check_pair(a, b);
            tvlData.games.Add(new game(a, b, r: t));
            tempstr += a + ":" + b + "   ";
        }
    }
}
