using System;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using OfficeOpenXml;
using Xceed.Words.NET;
using System.Linq;

namespace Tavleya2
{
    public class Reports
    {
        public Reports()
        {
            Utils.OutputDir = new DirectoryInfo($"{AppDomain.CurrentDomain.BaseDirectory}Отчеты");
            Utils.RefOutputDir = new DirectoryInfo($"{AppDomain.CurrentDomain.BaseDirectory}Отчеты/справки");
        }

        public void get_mid_report(int tour = 0)
        {
            string file_out = "Тур " + tour + ".xlsx";
            string file_in = "протокол тура.xlsx";
            FileInfo newFile = Utils.GetFileInfo(file_out);
            FileInfo templateFile = new FileInfo($"{AppDomain.CurrentDomain.BaseDirectory}шаблоны" + Path.DirectorySeparatorChar + file_in);

            using (ExcelPackage package = new ExcelPackage(newFile, templateFile))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[1];
                worksheet.Name = "Тур " + tour;
                package.Workbook.Properties.Author = "Тавлея";
                package.Workbook.Properties.LastModifiedBy = "Тавлея";

                worksheet.Cells["A1"].Value = " ''" + tvlData.tournir_name + "'' ";
                worksheet.Cells["A2"].Value = tvlData.tournir_start_date + " - " + tvlData.tournir_finish_date + tvlData.tournir_place;
                worksheet.Cells["A3"].Value = "Тур " + tour;

                int up_shift = 6;

                foreach (game g in tvlData.games)
                {
                    if ((g.round == tour) || (tour == 0))
                    {
                        worksheet.Cells[up_shift, 1].Value = g.id;
                        worksheet.Cells[up_shift, 2].Value = g.first + " - " + g.second;
                        worksheet.Cells[up_shift, 3].Value = "";
                        worksheet.Cells[up_shift, 4].Value = tvlData.players[MainForm.search_by_id(g.first)].fio();
                        worksheet.Cells[up_shift, 5].Value = tvlData.players[MainForm.search_by_id(g.first)].rank;
                        worksheet.Cells[up_shift, 6].Value = tvlData.players[MainForm.search_by_id(g.first)].points;
                        worksheet.Cells[up_shift, 7].Value = tvlData.players[MainForm.search_by_id(g.second)].fio();
                        worksheet.Cells[up_shift, 8].Value = tvlData.players[MainForm.search_by_id(g.second)].rank;
                        worksheet.Cells[up_shift, 9].Value = tvlData.players[MainForm.search_by_id(g.second)].points;
                        worksheet.Cells[up_shift, 10].Value = g.result;
                        if (g.id != tvlData.games.Count)
                            worksheet.InsertRow(up_shift + 1, 1, up_shift);//insert frmatted rows for players
                        up_shift++;
                    }
                }
                if (tour != 0)
                    worksheet.DeleteRow(up_shift);

                worksheet.Cells[up_shift + 2, 5].Value = tvlData.tournir_main_judge;
                worksheet.Cells[up_shift + 4, 5].Value = tvlData.tournir_secretary;

                // save our new workbook and we are done!
                package.Save();
                Process.Start(Utils.OutputDir.FullName + Path.DirectorySeparatorChar + file_out);
            }
        }
        public void get_final_report()
        {
            if (tvlData.gametype == 1)
            {
                Round_report();
                Round_report2();
            }
            if (tvlData.gametype == 3)
            {
                Swiss_report();
            }

        }

        public void Ref_report()
        {
            // Load a document.
            using (DocX document = DocX.Load(@"шаблоны\справка.docx"))
            {

                foreach (player p in tvlData.players)
                {
                    document.ReplaceText("<игрок>", p.surname + " " + p.name + " " + p.patronymic);
                    document.ReplaceText("<турнир>", tvlData.tournir_name);
                    document.ReplaceText("<дата начала>", tvlData.tournir_start_date);
                    document.ReplaceText("<дата окончания>", tvlData.tournir_finish_date);
                    document.ReplaceText("<очки>", p.points.ToString());
                    document.ReplaceText("<разряд>", p.new_rank);
                    document.ReplaceText("<судья>", tvlData.tournir_main_judge);
                    document.ReplaceText("<секретарь>", tvlData.tournir_secretary);
                    document.ReplaceText("<дата справки>", DateTime.Today.ToLongDateString());
                    document.ReplaceText("<рейтинг>",p.coef[0].ToString());
                    // Save this document to disk.
                    document.SaveAs(Utils.RefOutputDir.FullName + Path.DirectorySeparatorChar + @"Справка " + p.fio() + @".docx");
                }
            }
            Process.Start(Utils.OutputDir.FullName + Path.DirectorySeparatorChar + @"справки");
        }
        public string Protocol()
        {
            string file_out = "Протокол " + DateTime.Today.ToShortDateString() + " .xlsx";
            string file_in = "протокол.xlsx";
            FileInfo newFile = Utils.GetFileInfo(file_out);
            FileInfo templateFile = new FileInfo($"{AppDomain.CurrentDomain.BaseDirectory}шаблоны" + Path.DirectorySeparatorChar + file_in); //Utils.GetFileInfo(file_in, false);

            using (ExcelPackage package = new ExcelPackage(newFile, templateFile))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[1];
                worksheet.Name = "Протокол";
                package.Workbook.Properties.Author = "Тавлея";
                package.Workbook.Properties.LastModifiedBy = "Тавлея";
                worksheet.Cells["A2"].Value = tvlData.tournir_name;
                worksheet.Cells["A3"].Value = tvlData.tournir_start_date + " - " + tvlData.tournir_finish_date + " " + tvlData.tournir_place;

                int up_shift = 5;
                worksheet.InsertRow(6, tvlData.players.Count - 1, 5);//insert frmatted rows for players


                foreach (player pl in tvlData.players)
                {
                    if (pl.gender != "F")
                    {
                        worksheet.Cells[up_shift, 1].Value = pl.place;
                        worksheet.Cells[up_shift, 2].Value = pl.id;
                        worksheet.Cells[up_shift, 3].Value = pl.surname + " " + pl.name + " " + pl.patronymic;
                        worksheet.Cells[up_shift, 4].Value = pl.group;
                        worksheet.Cells[up_shift, 5].Value = pl.rank;
                        worksheet.Cells[up_shift, 6].Value = pl.year;
                        worksheet.Cells[up_shift, 7].Value = pl.gender;
                        worksheet.Cells[up_shift, 8].Value = pl.points;
                        worksheet.Cells[up_shift, 9].Value = pl.coef[2];
                        up_shift++;
                    }
                }
                worksheet.Cells[up_shift + 2, 4].Value = tvlData.tournir_main_judge;
                worksheet.Cells[up_shift + 4, 4].Value = tvlData.tournir_secretary;
                // save our new workbook and we are done!
                package.Save();
                Process.Start(Utils.OutputDir.FullName + Path.DirectorySeparatorChar + file_out);
            }
            return newFile.FullName;
        }
        private string Round_report()
        {
            string file_out = "Турнир " + DateTime.Today.ToShortDateString() + " (КРУГОВАЯ - стар).xlsx";
            string file_in = "круговая.xlsx";
            FileInfo newFile = Utils.GetFileInfo(file_out);
            FileInfo templateFile = new FileInfo($"{AppDomain.CurrentDomain.BaseDirectory}шаблоны" + Path.DirectorySeparatorChar + file_in); //Utils.GetFileInfo(file_in, false);

            using (ExcelPackage package = new ExcelPackage(newFile, templateFile))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[1];
                worksheet.Name = "Тавлея (круговая)";
                package.Workbook.Properties.Author = "Тавлея";
                package.Workbook.Properties.LastModifiedBy = "Тавлея";
                worksheet.Cells["A2"].Value = tvlData.tournir_start_date + " - " + tvlData.tournir_finish_date + " ''" + tvlData.tournir_name + "'' " + tvlData.tournir_place;

                for (int i = 7; i < tvlData.players.Count - 1 + 7; i++)//add columns for opponents
                {
                    worksheet.InsertColumn(i, 1, i - 1);
                    worksheet.Cells[4, i].Value = i - 5;
                }

                for (int i = 6; i < tvlData.players.Count - 1 + 7; i++)//set optimal columns width
                    worksheet.Column(i).Width = 40 / tvlData.players.Count;

                worksheet.Cells[3, 6, 3, tvlData.players.Count + 5].Merge = true;//merge opponents header

                int up_shift = 4;
                worksheet.InsertRow(6, tvlData.players.Count - 1, 5);//insert frmatted rows for players
                for (int pl_num = 0; pl_num < tvlData.players.Count; pl_num++)
                {
                    player pl = tvlData.players[pl_num];

                    worksheet.Cells[pl_num + 1 + up_shift, 1].Value = pl.id;
                    worksheet.Cells[pl_num + 1 + up_shift, 2].Value = (pl.surname + " " + pl.name);
                    worksheet.Cells[pl_num + 1 + up_shift, 3].Value = pl.year;
                    worksheet.Cells[pl_num + 1 + up_shift, 4].Value = pl.Adam;
                    worksheet.Cells[pl_num + 1 + up_shift, 5].Value = pl.rank;
                    for (int i = 6; i < 6 + tvlData.players.Count; i++)//results (points)
                    {
                        foreach (int g in pl.games)
                        {
                            if ((tvlData.games[g - 1].first == pl.id) && (tvlData.games[g - 1].second == i - 5))
                                worksheet.Cells[pl_num + 1 + up_shift, i].Value = tvlData.games[g - 1].pt1;
                            if ((tvlData.games[g - 1].second == pl.id) && (tvlData.games[g - 1].first == i - 5))
                                worksheet.Cells[pl_num + 1 + up_shift, i].Value = tvlData.games[g - 1].pt2;
                        }
                    }
                    worksheet.Cells[pl_num + 1 + up_shift, tvlData.players.Count + 6].Value = pl.points;
                    worksheet.Cells[pl_num + 1 + up_shift, tvlData.players.Count + 7].Value = pl.coef[5];
                    worksheet.Cells[pl_num + 1 + up_shift, tvlData.players.Count + 8].Value = pl.coef[4];
                    worksheet.Cells[pl_num + 1 + up_shift, tvlData.players.Count + 9].Value = pl.coef[2];
                    worksheet.Cells[pl_num + 1 + up_shift, tvlData.players.Count + 10].Value = pl.coef[3];
                    worksheet.Cells[pl_num + 1 + up_shift, tvlData.players.Count + 11].Value = pl.Adam_new;
                    worksheet.Cells[pl_num + 1 + up_shift, tvlData.players.Count + 12].Value = (pl.Adam_new - pl.Adam);
                    worksheet.Cells[pl_num + 1 + up_shift, tvlData.players.Count + 13].Value = pl.place;
                    worksheet.Cells[pl_num + 1 + up_shift, tvlData.players.Count + 14].Value = pl.new_rank;
                }
                // save our new workbook and we are done!
                package.Save();
                Process.Start(Utils.OutputDir.FullName + Path.DirectorySeparatorChar + file_out);
            }
            return newFile.FullName;
        }
        private void Round_report2()
        {
            string file_out = "Турнир " + DateTime.Today.ToShortDateString() + " (КРУГОВАЯ).xlsx";
            string file_in = "круговая2.xlsx";
            FileInfo newFile = Utils.GetFileInfo(file_out);
            FileInfo templateFile = new FileInfo($"{AppDomain.CurrentDomain.BaseDirectory}шаблоны" + Path.DirectorySeparatorChar + file_in); //Utils.GetFileInfo(file_in, false);

            using (ExcelPackage package = new ExcelPackage(newFile, templateFile))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[1];
                worksheet.Name = "Тавлея (круговая)";
                package.Workbook.Properties.Author = "Тавлея";
                package.Workbook.Properties.LastModifiedBy = "Тавлея";
                worksheet.Cells["A2"].Value = tvlData.tournir_name;
                worksheet.Cells["A3"].Value = tvlData.tournir_start_date + " - " + tvlData.tournir_finish_date + " " + tvlData.tournir_place;
                for (int i = 6; i < tvlData.players.Count - 1 + 6; i++)//add columns for opponents
                {
                    worksheet.InsertColumn(i, 1, i - 1);
                    worksheet.Cells[5, i].Value = i - 4;
                }

                for (int i = 5; i < tvlData.players.Count - 1 + 6; i++)//set optimal columns width
                    worksheet.Column(i).Width = 65 / tvlData.players.Count;

                worksheet.Cells[4, 5, 4, tvlData.players.Count + 4].Merge = true;//merge opponents header

                int up_shift = 5;
                worksheet.InsertRow(up_shift + 2, tvlData.players.Count - 1, up_shift+1);//insert frmatted rows for players
                for (int pl_num = 0; pl_num < tvlData.players.Count; pl_num++)
                {
                    player pl = tvlData.players[pl_num];

                    worksheet.Cells[pl_num + 1 + up_shift, 1].Value = pl.id;
                    worksheet.Cells[pl_num + 1 + up_shift, 2].Value = pl.fio();
                    worksheet.Cells[pl_num + 1 + up_shift, 3].Value = pl.year;
                    worksheet.Cells[pl_num + 1 + up_shift, 4].Value = pl.rank;
                    for (int i = 5; i < 5 + tvlData.players.Count; i++)//results (points)
                    {
                        foreach (int g in pl.games)
                        {
                            if ((tvlData.games[g - 1].first == pl.id) && (tvlData.games[g - 1].second == i - 4))
                                worksheet.Cells[pl_num + 1 + up_shift, i].Value = tvlData.games[g - 1].pt1;
                            if ((tvlData.games[g - 1].second == pl.id) && (tvlData.games[g - 1].first == i - 4))
                                worksheet.Cells[pl_num + 1 + up_shift, i].Value = tvlData.games[g - 1].pt2;
                        }
                    }
                    worksheet.Cells[pl_num + 1 + up_shift, tvlData.players.Count + 5].Value = pl.points;
                    worksheet.Cells[pl_num + 1 + up_shift, tvlData.players.Count + 6].Value = pl.coef[2];
                    worksheet.Cells[pl_num + 1 + up_shift, tvlData.players.Count + 7].Value = pl.place;
                }
                worksheet.Cells[tvlData.players.Count + up_shift + 3, 5].Value = tvlData.tournir_main_judge;
                worksheet.Cells[tvlData.players.Count + up_shift + 5, 5].Value = tvlData.tournir_secretary;
                // save our new workbook and we are done!
                package.Save();
                Process.Start(Utils.OutputDir.FullName + Path.DirectorySeparatorChar + file_out);
            }
        }
        private void Swiss_report()
        {
            if (MainForm.st == null)
            {
                MessageBox.Show("Сначала восстановите игру", "Внимание");
                return;
            }
            if (MainForm.st.finish!= true)
            {
                MessageBox.Show("Турнир не завершен", "Внимание");
                return;
            }
            string file_out = "Турнир " + DateTime.Today.ToShortDateString() + " (швейцарская).xlsx";
            string file_in = "швейцарская.xlsx";
            FileInfo newFile = Utils.GetFileInfo(file_out);
            FileInfo templateFile = new FileInfo($"{AppDomain.CurrentDomain.BaseDirectory}шаблоны" + Path.DirectorySeparatorChar + file_in);

            using (ExcelPackage package = new ExcelPackage(newFile, templateFile))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[1];
                worksheet.Name = "Тавлея (швейцарская)";
                package.Workbook.Properties.Author = "Тавлея";
                package.Workbook.Properties.LastModifiedBy = "Тавлея";
                worksheet.Cells["A2"].Value = tvlData.tournir_name;
                worksheet.Cells["A3"].Value = tvlData.tournir_start_date + " - " + tvlData.tournir_finish_date + " " + tvlData.tournir_place;

                for (int i = 8; i < MainForm.st.tourscount - 1 + 8; i++)//add columns for tours
                {
                    worksheet.InsertColumn(i, 1, i - 1);
                    worksheet.Cells[5, i].Value = i - 6;
                    worksheet.Column(i).Width = 34 / MainForm.st.tourscount;//set optimal columns width
                }
                for (int i = 7; i < MainForm.st.tourscount -1 + 8; i++)
                    worksheet.Column(i).Width = 34 / MainForm.st.tourscount;//set optimal columns width

                worksheet.Cells[4, 7, 4, MainForm.st.tourscount + 6].Merge = true;//merge tours header

                int up_shift = 5;
                worksheet.InsertRow(up_shift + 2, tvlData.players.Count - 1, up_shift + 1);//insert frmatted rows for players
                for (int pl_num = 0; pl_num < tvlData.players.Count; pl_num++)
                {
                    player pl = tvlData.players[pl_num];

                    worksheet.Cells[pl_num + 1 + up_shift, 1].Value = pl.id;
                    worksheet.Cells[pl_num + 1 + up_shift, 2].Value = (pl.surname + " " + pl.name);
                    worksheet.Cells[pl_num + 1 + up_shift, 3].Value = pl.city;
                    worksheet.Cells[pl_num + 1 + up_shift, 4].Value = pl.year;
                    worksheet.Cells[pl_num + 1 + up_shift, 5].Value = pl.rank;
                    worksheet.Cells[pl_num + 1 + up_shift, 6].Value = pl.Adam;
                    
                    for (int i = 7; i < 7 + MainForm.st.tourscount; i++)//results (points)
                    {
                        foreach (int g in pl.games)
                        {
                            if ((tvlData.games[g - 1].first == pl.id) && (tvlData.games[g - 1].round == i - 6))
                                worksheet.Cells[pl_num + 1 + up_shift, i].Value = tvlData.games[g - 1].pt1 + "(" + tvlData.games[g - 1].second + ")";
                            if ((tvlData.games[g - 1].second == pl.id) && (tvlData.games[g - 1].round == i - 6))
                                worksheet.Cells[pl_num + 1 + up_shift, i].Value = tvlData.games[g - 1].pt2 + "(" + tvlData.games[g - 1].first + ")";
                        }
                    }
                    
                    worksheet.Cells[pl_num + 1 + up_shift, MainForm.st.tourscount + 7].Value = pl.points;
                    worksheet.Cells[pl_num + 1 + up_shift, MainForm.st.tourscount + 8].Value = pl.coef[1];
                    worksheet.Cells[pl_num + 1 + up_shift, MainForm.st.tourscount + 9].Value = pl.coef[5];
                    worksheet.Cells[pl_num + 1 + up_shift, MainForm.st.tourscount + 10].Value = pl.coef[2];
                    worksheet.Cells[pl_num + 1 + up_shift, MainForm.st.tourscount + 11].Value = pl.coef[3];
                    worksheet.Cells[pl_num + 1 + up_shift, MainForm.st.tourscount + 12].Value = pl.Adam_new;
                    worksheet.Cells[pl_num + 1 + up_shift, MainForm.st.tourscount + 13].Value = (pl.Adam_new - pl.Adam);
                    worksheet.Cells[pl_num + 1 + up_shift, MainForm.st.tourscount + 14].Value = pl.place;
                    worksheet.Cells[pl_num + 1 + up_shift, MainForm.st.tourscount + 15].Value = pl.new_rank;
                }
                worksheet.Cells[tvlData.players.Count + up_shift + 3, 5].Value = tvlData.tournir_main_judge;
                worksheet.Cells[tvlData.players.Count + up_shift + 5, 5].Value = tvlData.tournir_secretary;
                // save our new workbook and we are done!
                package.Save();
                Process.Start(Utils.OutputDir.FullName + Path.DirectorySeparatorChar + file_out);
            }
        }
        public string Ranks()
        {
            string file_out = "Выполнение разрядных норм " + DateTime.Today.ToShortDateString() + ".xlsx";
            string file_in = "разрядные нормы.xlsx";
            FileInfo newFile = Utils.GetFileInfo(file_out);
            FileInfo templateFile = new FileInfo($"{AppDomain.CurrentDomain.BaseDirectory}шаблоны" + Path.DirectorySeparatorChar + file_in); //Utils.GetFileInfo(file_in, false);

            using (ExcelPackage package = new ExcelPackage(newFile, templateFile))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[1];
                worksheet.Name = "разрядные нормы";
                package.Workbook.Properties.Author = "Тавлея";
                package.Workbook.Properties.LastModifiedBy = "Тавлея";
                worksheet.Cells["A2"].Value = tvlData.tournir_name;
                worksheet.Cells["A3"].Value = tvlData.tournir_start_date + " - " + tvlData.tournir_finish_date + " " + tvlData.tournir_place;
                for (int i = 4; i < tvlData.players.Count - 2 + 4; i++)//add columns for opponents
                {
                    worksheet.InsertColumn(i, 1, i - 1);
                    worksheet.Cells[5, i].Value = i - 2;
                }

                for (int i = 3; i < tvlData.players.Count - 1 + 4; i++)//set optimal columns width
                    worksheet.Column(i).Width = 65 / tvlData.players.Count;

                worksheet.Cells[4, 3, 4, tvlData.players.Count + 1].Merge = true;//merge opponents header

                int up_shift = 5;
                worksheet.InsertRow(up_shift + 2, tvlData.players.Count - 1, up_shift + 1);//insert frmatted rows for players
                for (int pl_num = 0; pl_num < tvlData.players.Count; pl_num++)
                {
                    player pl = tvlData.players[pl_num];

                    worksheet.Cells[pl_num + 1 + up_shift, 1].Value = pl.id;
                    worksheet.Cells[pl_num + 1 + up_shift, 2].Value = pl.fio();

                    for (int i = 3; i < 3 + tvlData.players.Count-1; i++)//results (points)
                    {

                                worksheet.Cells[pl_num + 1 + up_shift, i].Value = tvlData.players[MainForm.search_by_id(pl.opponents[i-3])].rank;
                    }
                    worksheet.Cells[pl_num + 1 + up_shift, tvlData.players.Count - 1 + 3].Value = pl.rank_INDEX;//необх кт
                    worksheet.Cells[pl_num + 1 + up_shift, tvlData.players.Count - 1 + 4].Value = pl.rank_coeft;//турн кт
                    worksheet.Cells[pl_num + 1 + up_shift, tvlData.players.Count - 1 + 5].Value = pl.point_norm;//норма очков
                    worksheet.Cells[pl_num + 1 + up_shift, tvlData.players.Count - 1 + 6].Value = pl.points;// очки
                    worksheet.Cells[pl_num + 1 + up_shift, tvlData.players.Count - 1 + 7].Value = pl.rank;//разр до
                    worksheet.Cells[pl_num + 1 + up_shift, tvlData.players.Count - 1 + 8].Value = pl.new_rank;//разр после
                    if (pl.rank_UP == 1)
                        worksheet.Cells[pl_num + 1 + up_shift, tvlData.players.Count - 1 + 8].Style.Font.Color.SetColor(System.Drawing.Color.Green);
                    if (pl.rank_UP == -1)
                        worksheet.Cells[pl_num + 1 + up_shift, tvlData.players.Count - 1 + 8].Style.Font.Color.SetColor(System.Drawing.Color.Red);

                }
                worksheet.Cells[tvlData.players.Count + up_shift + 3, 5].Value = tvlData.tournir_main_judge;
                worksheet.Cells[tvlData.players.Count + up_shift + 5, 5].Value = tvlData.tournir_secretary;
                // save our new workbook and we are done!
                package.Save();
                Process.Start(Utils.OutputDir.FullName + Path.DirectorySeparatorChar + file_out);
            }
            return newFile.FullName;
        }
        public string Year_reportold()
        {
            string file = "";
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "MS Word files|*.docx";
            openFileDialog1.Title = "Открыть годовой отчет";
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                file = (openFileDialog1.FileName);
            if (file != "")
            {
                using (DocX document = DocX.Load(file))
                {
                    var yearTable = document.Tables.FirstOrDefault(t => t.TableCaption == "YearTable");
                    if (yearTable != null)
                    {
                        if (yearTable.RowCount > 1)
                        {
                            var rowPattern = yearTable.Rows[yearTable.RowCount-1];

                            Int32.TryParse(yearTable.Rows[yearTable.RowCount - 1].Cells[0].Paragraphs[0].Text , out var num);
                            num++;
                            yearTable.InsertRow(rowPattern);
                            
                            yearTable.Rows[yearTable.RowCount - 1].Cells[0].Paragraphs[0].InsertText( num.ToString());

                            yearTable.Rows[yearTable.RowCount - 1].Cells[2].Paragraphs[0].InsertText(tvlData.tournir_name);

                            yearTable.Rows[yearTable.RowCount - 1].Cells[4].Paragraphs[0].InsertText(tvlData.tournir_start_date[0] + tvlData.tournir_start_date[1] + " - " + tvlData.tournir_finish_date);

                            yearTable.Rows[yearTable.RowCount - 1].Cells[5].Paragraphs[0].InsertText(tvlData.tournir_place);

                            //1-3pl
                            string tmpstr = "";
                            for (int i = 0; i < 3; i++)
                            {
                                tmpstr += (i + 1) + tvlData.players[i].surname + " " + tvlData.players[i].name + ";" + "\n";
                                yearTable.Rows[yearTable.RowCount - 1].Cells[8].RemoveParagraphAt(i);
                            }
                            yearTable.Rows[yearTable.RowCount - 1].Cells[8].Paragraphs[0].InsertText(tmpstr);

                        }

                        document.Save();
                        Process.Start(file);
                    }
                }
            }
            return file;
        }
        public void Year_report()
        {
            string file = "";
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "MS Excel files|*.xlsx";
            openFileDialog1.Title = "Открыть годовой отчет";
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                file = (openFileDialog1.FileName);
            if (file != "")
            {

                using (ExcelPackage package = new ExcelPackage(new FileInfo(file)))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[1];

                    package.Workbook.Properties.Author = "Тавлея";
                    package.Workbook.Properties.LastModifiedBy = "Тавлея";


                    int up_shift = 5;
                    worksheet.InsertRow(6, tvlData.players.Count - 1, 5);//insert frmatted rows for players


                    foreach (player pl in tvlData.players)
                    {
                        if (pl.gender != "F")
                        {
                            worksheet.Cells[up_shift, 1].Value = pl.place;
                            worksheet.Cells[up_shift, 2].Value = pl.id;
                            worksheet.Cells[up_shift, 3].Value = pl.surname + " " + pl.name + " " + pl.patronymic;
                            worksheet.Cells[up_shift, 4].Value = pl.group;
                            worksheet.Cells[up_shift, 5].Value = pl.rank;
                            worksheet.Cells[up_shift, 6].Value = pl.year;
                            worksheet.Cells[up_shift, 7].Value = pl.gender;
                            worksheet.Cells[up_shift, 8].Value = pl.points;
                            worksheet.Cells[up_shift, 9].Value = pl.coef[2];
                            up_shift++;
                        }
                    }
                    worksheet.Cells[up_shift + 2, 4].Value = tvlData.tournir_main_judge;
                    worksheet.Cells[up_shift + 4, 4].Value = tvlData.tournir_secretary;
                    // save our new workbook and we are done!
                    package.Save();
                    Process.Start(file);
                }
            }
        }

        public class Utils
        {
            static DirectoryInfo _outputDir = null;
            static DirectoryInfo _ref_outputDir = null;
            public static DirectoryInfo OutputDir
            {
                get
                {
                    return _outputDir;
                }
                set
                {
                    _outputDir = value;
                    if (!_outputDir.Exists)
                    {
                        _outputDir.Create();
                    }
                }
            }
            public static DirectoryInfo RefOutputDir
            {
                get
                {
                    return _ref_outputDir;
                }
                set
                {
                    _ref_outputDir = value;
                    if (!_ref_outputDir.Exists)
                    {
                        _ref_outputDir.Create();
                    }
                }
            }
            public static FileInfo GetFileInfo(string file, bool deleteIfExists = true)
            {
                var fi = new FileInfo(OutputDir.FullName + Path.DirectorySeparatorChar + file);
                if (deleteIfExists && fi.Exists)
                {
                    try
                    {
                        fi.Delete();  // ensures we create a new workbook
                    }
                    catch (System.IO.IOException e)
                    {
                        MessageBox.Show("Ошибка записи в файл, возможно он отурыт в другом приложении.\n" + e.Message);
                        fi = new FileInfo(OutputDir.FullName + Path.DirectorySeparatorChar + file + "new");
                    }
                }
                return fi;
            }
            public static FileInfo GetFileInfo(DirectoryInfo altOutputDir, string file, bool deleteIfExists = true)
            {
                var fi = new FileInfo(altOutputDir.FullName + Path.DirectorySeparatorChar + file);
                if (deleteIfExists && fi.Exists)
                {
                    fi.Delete();  // ensures we create a new workbook
                }
                return fi;
            }

            internal static DirectoryInfo GetDirectoryInfo(string directory)
            {
                var di = new DirectoryInfo(_outputDir.FullName + Path.DirectorySeparatorChar + directory);
                if (!di.Exists)
                {
                    di.Create();
                }
                return di;
            }
        }
    }
}
