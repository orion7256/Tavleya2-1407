using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Tavleya2
{
    public partial class Round_table
    {
        int players;
        List<string> res;
        int[] flags ;

        public Round_table(int playersget =0)
        {
            if (playersget % 2 == 0)
                players = playersget;
            else
            {

                tvlData.players.Add(new player("Свободный", "Имя", "Отчествао", "F", "команда", 2000, "Севастополь", "Нет", 0, "фикт"));
                MessageBox.Show("Добавлен фиктивный игрок ID:" + player.lastid);
                players = tvlData.players.Count;
            }
            flags = new int[players+1];
            for (int i = 0; i< players+1; i++)
                flags[i] = 0;

            res = new List<string>();
            if(players >1)
                count();
        }
        public void count()
        {
            if (players % 2 != 0) return;

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
            string tempstr = "";
            int tour_n = 0;
            bool swap = true;
            for (int i = players - 2; i >= 0; i--)
            {
                tour_n++;
                if ((i-1) % 3 == 0)
                    swap = !swap;
                
                for (int j = 0; j < players / 2; ++j)
                {
                    ++flags[tour[i, j].first];
                    if(swap)
                    {
                        int tmp = tour[i, j].first;
                        tour[i, j].first = tour[i, j].second;
                        tour[i, j].second = tmp;
                    }
                    if (flags[tour[i, j].first] == 6)
                        flags[tour[i, j].first] = 0;
                    tvlData.games.Add(new game(tvlData.players[tour[i, j].first - 1].id, tvlData.players[tour[i, j].second - 1].id, r: tour_n));                   
                    tempstr += tvlData.players[tour[i, j].first - 1].id  + ":" + tvlData.players[tour[i, j].second - 1].id + "   ";
                }
                if(tour_n<10)
                    tempstr = "  " + tour_n + " тур: " + tempstr;
                else
                    tempstr = tour_n + " тур: " + tempstr;
                tvlData.counted.Add(tempstr);
                tempstr = "";
            }
        }  
    }
    class RoundPair
    {
        public int first;
        public int second;
        public static int getFirst(int i, int j, int players_n)
        {
            if (i == 0) return j + 1;
            if (i < j) return (j + 1) - i;
            if (i == j) return players_n;
            else return players_n - (i - j);
        }

        public static int getSecond(int i, int j, int players_n)
        {
            if (i == 0) return players_n - j;
            if (i <= j) return players_n - (i + j);
            if (i + j == players_n - 1) return players_n;
            if (i + j >= players_n) return 2 * players_n - (i + j + 1);
            else return players_n - (i + j);
        }
    }
}