using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Tavleya2
{
    [Serializable]
    public class tvlData
    {
        public static string tournir_name = "";
        public static string tournir_place = "";
        public static string tournir_start_date = DateTime.Today.ToShortDateString();
        public static string tournir_finish_date = DateTime.Today.ToShortDateString();
        public static string tournir_judges = "";
        public static string tournir_main_judge = "";
        public static string tournir_secretary = "";
        public static int gametype = 0; //1Круговая, 2Олимпийская, 3Швейцарская, 4Смешанная

        public static List<player> players = new List<player>();
        public static List<Short_player> short_players = new List<Short_player>();
        public static List<game> games = new List<game>();
        public static List<string> zipped = new List<string>();
        public static List<string> counted = new List<string>();
        public static void zipdata()
        {
            zipped = new List<string> { tournir_name, tournir_place, tournir_start_date, tournir_finish_date, tournir_main_judge, tournir_secretary, tournir_judges, gametype.ToString() };
            //MessageBox.Show(String.Join("\n", counted.ToArray()));
        }
        public static void unzipdata()
        {
            tournir_name = zipped[0];
            tournir_place = zipped[1];
            tournir_start_date = zipped[2];
            tournir_finish_date = zipped[3];
            tournir_main_judge = zipped[4];
            tournir_secretary = zipped[5];
            tournir_judges = zipped[6];
            Int32.TryParse(zipped[7], out gametype);
        }
        public delegate void MethodContainer();
        public static event MethodContainer onSort;
        public static void main_sort(int column = 0)
        {

            switch (column)
            {
                case 0:
                    tvlData.players.Sort((a, b) => a.id.CompareTo(b.id)); break;
                case 3:
                    tvlData.players.Sort((a, b) => a.year.CompareTo(b.year)); break;
                case 4:
                    tvlData.players.Sort((a, b) => b.points.CompareTo(a.points)); break;
                case 5:
                    tvlData.players.Sort((a, b) => b.Adam.CompareTo(a.Adam)); break;
                default:
                    tvlData.players.Sort((a, b) => a.ss[column].CompareTo(b.ss[column])); break;
            }

            MainForm.sort = column;
            plus_sort();
            if (onSort != null)
                onSort();
        }
        public static void plus_sort()//additional sort
        {
            if (MainForm.additional_sort != 0)
                for (int j = 0; j < 5; j++)
                {
                    for (int i = 0; i < tvlData.players.Count - 1; i++)
                    {
                        if (tvlData.players[i].ss[MainForm.sort] == tvlData.players[i + 1].ss[MainForm.sort])
                            switch (MainForm.additional_sort)
                            {
                                case 1:
                                    {
                                        if (tvlData.players[i].points < tvlData.players[i + 1].points)
                                            swap_players(i, i + 1);
                                        break;
                                    }
                                case 2:
                                    {
                                        if (tvlData.players[i].wins.Count < tvlData.players[i + 1].wins.Count)
                                            swap_players(i, i + 1);
                                        break;
                                    }
                                case 3:
                                    {
                                        if (tvlData.players[i].coef[3] < tvlData.players[i + 1].coef[3])//gorin
                                            swap_players(i, i + 1);
                                        break;
                                    }
                            }
                    }
                }
        }
        public static void swap_players(int first, int second)
        {
            player tmp;
            if (first != second)
            {
                tmp = tvlData.players[first];
                tvlData.players[first] = tvlData.players[second];
                tvlData.players[second] = tmp;
            }
        }
    }
}

