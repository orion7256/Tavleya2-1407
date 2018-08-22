using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Tavleya2
{
    public partial class Mixed_table
    {
        int players;
        int[] flags;
        int[] indeces;//wtf is this
        int shift;
        int tour_n = 0;
        string tempstr1 = "";
        string tempstr2 = "";
        string finalstr = "";

        int last_type = 0;
        bool finish = false;
        public Mixed_table(int lasttyperest = 0)
        {
            get_fict(tvlData.players.Count);
            players = tvlData.players.Count / 2;
            shift = players;
            flags = new int[players + 1];
            for (int i = 0; i < players + 1; i++)
                flags[i] = 0;
            if (players > 1)
                next();
            last_type = lasttyperest;
            tour_n = lasttyperest;
        }
        public void get_fict(int incoming)
        {
            int fict = 0;
            switch (incoming % 4)
            {
                case 1: fict = 3; break;
                case 2: fict = 2; break;
                case 3: fict = 1; break;
            }
            for (int i = 0; i < fict; i++)
            {
                tvlData.players.Add(new player("Свободный", "Имя", "Отчествао", "F",  "команда", 2000, "Севастополь", "Нет", 0, "фикт"));
            }
            MessageBox.Show("Добавлено фиктивных игроков:" + fict);
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
            if (!finish)
                switch (last_type)
                {
                    case 0: Round2_count(); break;
                    case 1: Mixed_count(); break;
                    case 2: last(); break;
                    default: very_last(); break;
                }
        }
        int[] get_indeces(int[] inmas)
        {
            int[] out1 = new int[inmas.Length / 2];
            int[] out2 = new int[inmas.Length / 2];
            List<int> l1 = new List<int>();
            List<int> l2 = new List<int>();
            for (int i = 0; i < inmas.Length; i++)
                if (i % 2 == 0)
                    l1.Add(inmas[i]);
                else
                    l2.Add(inmas[i]);
            out1 = l1.ToArray();
            out2 = l2.ToArray();
            return out1.Concat(out2).ToArray();
        }
        public void Round2_count()
        {
            tvlData.players.Sort((a, b) => b.coef[0].CompareTo(a.coef[0]));// sort by adam
            int[] ind = new int[tvlData.players.Count];

            for (int i = 0; i < tvlData.players.Count; i++)
                ind[i] = tvlData.players[i].id;
            indeces = new int[players];
            indeces = get_indeces(ind);

            int n = players / 2;

            RoundPair[,] tour = new RoundPair[players - 1, n];

            for (int i = 0; i < players - 1; i++)
                for (int j = 0; j < n; j++)
                {
                    tour[i, j] = new RoundPair();
                }

            for (int i = 0; i < players - 1; ++i)
            {
                tour[i, 0].first = 1;
                tour[i, 0].second = players - i;
            }

            for (int j = 1; j < players / 2; ++j)
            {
                for (int i = 0; i < players - 1; ++i)
                {
                    tour[i, j].first = RoundPair.getFirst(i, j, players);
                    tour[i, j].second = RoundPair.getSecond(i, j, players);
                }
            }

            bool swap = true;
            for (int i = players - 2; i >= 0; i--)
            {
                tour_n++;
                if ((i - 1) % 3 == 0)
                    swap = !swap;

                for (int j = 0; j < players / 2; ++j)
                {
                    ++flags[tour[i, j].first];
                    if (swap)
                    {
                        int tmp = tour[i, j].first;
                        tour[i, j].first = tour[i, j].second;
                        tour[i, j].second = tmp;
                    }
                    if (flags[tour[i, j].first] == 6)
                        flags[tour[i, j].first] = 0;

                    tvlData.games.Add(new game(indeces[tour[i, j].first - 1], indeces[tour[i, j].second - 1], r: tour_n));//1
                    tempstr1 += indeces[tour[i, j].first - 1] + ":" + indeces[tour[i, j].second - 1] + "   ";

                    tvlData.games.Add(new game(indeces[tour[i, j].first + shift - 1], indeces[tour[i, j].second + shift - 1], r: tour_n));//2
                    tempstr2 += indeces[tour[i, j].first + shift - 1] + ":" + indeces[tour[i, j].second + shift - 1] + "   ";
                }
                cat_str();
            }
            last_type = 1;
        }
        public void Mixed_count()
        {
            if (!allow_next())
                return;
            int f_p = 0;
            int s_p = 0;
            int f_pp = 1;
            int s_pp = 1;
            for (int i = 0; i < tvlData.players.Count; i++)
            {
                if (i % 2 == 0)// find winners for first group
                {
                    if (tvlData.players[i].points >= tvlData.players[f_p].points)
                    {
                        s_p = f_p;
                        f_p = i;
                    }
                }
                else// find winners for second group
                {
                    if (tvlData.players[i].points >= tvlData.players[f_pp].points)
                    {
                        s_pp = f_pp;
                        f_pp = i;
                    }
                }
            }
            tour_n++;
            tvlData.games.Add(new game(tvlData.players[f_p].id, tvlData.players[s_pp].id, r: tour_n));//1
            tempstr1 += tvlData.players[f_p].id + ":" + tvlData.players[s_pp].id + "   ";

            tvlData.games.Add(new game(tvlData.players[s_p].id, tvlData.players[f_pp].id, r: tour_n));//2
            tempstr2 += tvlData.players[s_p].id + ":" + tvlData.players[f_pp].id + "   ";
            last_type = 2;
            cat_str();
        }
        public void last()
        {
            if (!allow_next())
                return;
            tour_n++;
            tempstr1 += tvlData.games[tvlData.games.Count - 1].win + ":" + tvlData.games[tvlData.games.Count - 2].win + "   ";
            tvlData.games.Add(new game(tvlData.games[tvlData.games.Count - 1].win, tvlData.games[tvlData.games.Count - 2].win, r: tour_n));
            last_type = 3;
            cat_str();
        }
        public void very_last()
        {
            last_type = 4;
            MessageBox.Show("Турнир завершен. Победитель: " + tvlData.games[tvlData.games.Count - 1].win);
            finish = true;
        }
        private void cat_str()
        {
            if (tour_n < 10)
                finalstr = "  ";
            else
                finalstr = "";
            finalstr += tour_n + " тур: " + tempstr1;
            if (tempstr2 != "")
                finalstr += " / " + tempstr2;
            tvlData.counted.Add(finalstr);
            tempstr1 = "";
            tempstr2 = "";
            finalstr = "";
        }
    }
}
