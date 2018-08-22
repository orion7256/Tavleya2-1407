using System;

namespace Tavleya2
{
    [Serializable]
    public class game
    {
        public int id;
        public static int lastid = 0;
        public int first;
        public int second;
        public double pt1 = -1;
        public double pt2 = -1;
        public string result;
        public int round;
        public int win { get; set; }
        public game(int f = 0, int s = 0, int w = -1, int r = 0)
        {
            if ((f >= 0) && (s >= 0) && (r >= 0) && (f != s) && (f <= tvlData.players.Count) && (s <= tvlData.players.Count))//checking
            {
                id = lastid + 1;
                lastid++;
                first = f;
                second = s;
                win = w;
                round = r;
                tvlData.players[MainForm.search_by_id(first)].games.Add(id);
                tvlData.players[MainForm.search_by_id(second)].games.Add(id);
            }
            else result = "add error";
        }
        public void setwin(double a = 0, double b = 0, int pluses = 0)
        {
            if ((pt1!=-1)||(pt2!=-1))//remove points and opponents for edit
            {
                tvlData.players[MainForm.search_by_id(first)].points -= pt1;
                tvlData.players[MainForm.search_by_id(second)].points -= pt2;
                win = -1;
                if ((pt1 == 2) && (pt2 == 0))
                {
                    tvlData.players[MainForm.search_by_id(first)].wins.Remove(second);
                    tvlData.players[MainForm.search_by_id(second)].lost.Remove(first);
                }
                if ((pt1 == 1) && (pt2 == 1))
                {
                    tvlData.players[MainForm.search_by_id(first)].mid.Remove(second);
                    tvlData.players[MainForm.search_by_id(second)].mid.Remove(first);
                }
                if ((pt1 == 0) && (pt2 == 2))
                {
                    tvlData.players[MainForm.search_by_id(second)].wins.Remove(first);
                    tvlData.players[MainForm.search_by_id(first)].lost.Remove(second);
                }
            }
            if ((a > 2) || (a < 0) || (b > 2) || (b < 0))//checking
                return;
            if ((a != 0) && (b == 0))//setting 1st win
            {
                win = first;
                tvlData.players[MainForm.search_by_id(first)].wins.Add(second);
                tvlData.players[MainForm.search_by_id(second)].lost.Add(first);
                tvlData.players[MainForm.search_by_id(first)].points += a;
            }
            if ((a == b))//setting mid win
            {
                //mid
                win = 0;
                tvlData.players[MainForm.search_by_id(first)].mid.Add(second);
                tvlData.players[MainForm.search_by_id(second)].mid.Add(first);
                tvlData.players[MainForm.search_by_id(first)].points += a;
                tvlData.players[MainForm.search_by_id(second)].points += b;
            }
            if ((a == 0) && (b != 0))//setting 2nd win
            {
                //2
                win = second;
                tvlData.players[MainForm.search_by_id(second)].wins.Add(first);
                tvlData.players[MainForm.search_by_id(first)].lost.Add(second);
                tvlData.players[MainForm.search_by_id(second)].points += b;
            }
            if ((a == 0) && (b == 0))//setting nobody win
            {
                win = 0;
                if (pluses != 0)
                {
                    if ((pluses == 1) || (pluses == -2))
                    {
                        tvlData.players[MainForm.search_by_id(first)].pluses += "+" +  "[" + id + "]";
                        tvlData.players[MainForm.search_by_id(second)].pluses += "-" + "[" + id + "]";
                        tvlData.players[MainForm.search_by_id(first)].wins.Add(second*(-1));
                        if(tvlData.gametype != 1)
                            tvlData.players[MainForm.search_by_id(first)].points += 2;
                    }
                    if ((pluses == 2) || (pluses == -1))
                    {
                        tvlData.players[MainForm.search_by_id(second)].pluses += "+" + "[" + id + "]";
                        tvlData.players[MainForm.search_by_id(first)].pluses += "-" + "[" + id + "]";
                        tvlData.players[MainForm.search_by_id(second)].wins.Add(first*(-1));
                        if (tvlData.gametype != 1)
                            tvlData.players[MainForm.search_by_id(second)].points += 2;
                    }
                }
            }
            form_result();
            pt1 = a;
            pt2 = b;
        }
        public void swap()
        {
            int tmp;
            tmp = first;
            first = second;
        }
        public string form_result()
        {
            string ap = "";
            string bp = "";
            string apt = "";
            string bpt = "";
            if (tvlData.players[MainForm.search_by_id(first)].pluses != "")
                ap = "[" + tvlData.players[MainForm.search_by_id(first)].pluses + "]";
            if (tvlData.players[MainForm.search_by_id(second)].pluses != "")
                bp = "[" + tvlData.players[MainForm.search_by_id(second)].pluses + "]";
            if (pt1 == -1)
                apt = "_";
            else apt = pt1.ToString();
            if (pt2 == -1)
                bpt = "_";
            else bpt = pt2.ToString();
            result = ap + apt + " - " + bpt + bp;

            return result;
        }
        public string[] str()//string array for listbox
        {
            string[] ss = new string[6];
            ss[0] = id.ToString();
            ss[1] = round.ToString();
            ss[2] = first.ToString();
            ss[3] = second.ToString();
            ss[4] = win.ToString();
            ss[5] = form_result();
            return ss;
        }
    }
}
