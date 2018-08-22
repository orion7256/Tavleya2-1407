using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Tavleya2
{
    public partial class Olympic_table
    {
        int players;
        int playersleft;
        int[] currentplayers;
        public static bool allow_next = true;


        //public static List<game> games = new List<game>();
        public bool finish_flag = false;

        static int tour;
        public Olympic_table(int tourget = 1)
        {
            int[] allowed = new int[] { 2, 4, 8, 16, 32, 64, 128 };
            tour = tourget;
            if (Array.BinarySearch(allowed, tvlData.players.Count) >0)
            {
                players = tvlData.players.Count;
                playersleft = players;
                currentplayers = new int[players + 1];
                for (int i = 0; i < players + 1; i++)
                    currentplayers[i] = i;
                count();
            }
            else
            {
                MessageBox.Show("Несоответствие числа игроков требуемому");
            }
        }

        public void count()
        {
            if (!finish_flag)
            {
                string tempstr = "";
                if (playersleft > 1)
                {
                    if (tvlData.games.Count == 0)
                        for (int i = 0; i < (playersleft ); i += 2)//1st tour
                        {
                            tempstr += tvlData.players[i].id + ":" + tvlData.players[(i + 1)].id + " ";
                            tvlData.games.Add(new game(tvlData.players[i].id, tvlData.players[i + 1].id, r: tour));
                        }
                    else
                    {
                        int h = 0;
                        for (int i = 0; i < tvlData.games.Count; i++)
                        {
                            if (tvlData.games[i].round == (tour-1))
                            {
                                currentplayers[h] = tvlData.games[i].win;
                                h++;
                            }
                        }
                        for (int i = 0; i < (playersleft ); i += 2)//2+tours
                        {
                            tempstr += currentplayers[i] + ":" + currentplayers[i + 1] + " ";
                            tvlData.games.Add(new game(currentplayers[i], currentplayers[i + 1], r: tour));
                        }
                    }
                }
                else//winner
                {
                    tempstr += tvlData.games.Last().win;
                    finish_flag = true;
                }
                tempstr = tour + " тур: " + tempstr;
                tvlData.counted.Add(tempstr);
                tempstr = "";
                playersleft /= 2;
                tour++;
            }
        }
        public void next()
        {
            if (MainForm.allowed_next)
                count();
        }
    }
}
