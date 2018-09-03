using System;
using System.Windows.Forms;

namespace Tavleya2
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.новыйToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.соревнованияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.данныеТурнираToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.посчитатьМестаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.генерироватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкиОРазрядахToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.протоколТураToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.итоговыйПротоколToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выполненияподтвержденияРазрядныхНормToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.дополнитьГодовойОтчетToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.рейтингЛистToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.тестированиеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.восстановлениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tours = new System.Windows.Forms.GroupBox();
            this.System_count_btn = new System.Windows.Forms.Button();
            this.Nextbutton = new System.Windows.Forms.Button();
            this.Xbutton = new System.Windows.Forms.Button();
            this.game_table = new System.Windows.Forms.ListView();
            this.winget_button = new System.Windows.Forms.Button();
            this.Tour_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.system = new System.Windows.Forms.GroupBox();
            this.SystemResults_listBox = new System.Windows.Forms.ListBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.Gone_button = new System.Windows.Forms.Button();
            this.Editbutton = new System.Windows.Forms.Button();
            this.Addbutton = new System.Windows.Forms.Button();
            this.PlayerslistView = new System.Windows.Forms.ListView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Del_button = new System.Windows.Forms.Button();
            this.up_button = new System.Windows.Forms.Button();
            this.down_button = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.tours.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Tour_numericUpDown)).BeginInit();
            this.system.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.соревнованияToolStripMenuItem,
            this.отчетыToolStripMenuItem,
            this.справкаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1154, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.новыйToolStripMenuItem,
            this.открытьToolStripMenuItem,
            this.сохранитьToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // новыйToolStripMenuItem
            // 
            this.новыйToolStripMenuItem.Name = "новыйToolStripMenuItem";
            this.новыйToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.новыйToolStripMenuItem.Text = "Новый";
            this.новыйToolStripMenuItem.Click += new System.EventHandler(this.новыйToolStripMenuItem_Click);
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.открытьToolStripMenuItem.Text = "Открыть";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // соревнованияToolStripMenuItem
            // 
            this.соревнованияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.данныеТурнираToolStripMenuItem,
            this.посчитатьМестаToolStripMenuItem});
            this.соревнованияToolStripMenuItem.Name = "соревнованияToolStripMenuItem";
            this.соревнованияToolStripMenuItem.Size = new System.Drawing.Size(99, 20);
            this.соревнованияToolStripMenuItem.Text = "Соревнования";
            // 
            // данныеТурнираToolStripMenuItem
            // 
            this.данныеТурнираToolStripMenuItem.Name = "данныеТурнираToolStripMenuItem";
            this.данныеТурнираToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.данныеТурнираToolStripMenuItem.Text = "Данные турнира";
            this.данныеТурнираToolStripMenuItem.Click += new System.EventHandler(this.данныеТурнираToolStripMenuItem_Click);
            // 
            // посчитатьМестаToolStripMenuItem
            // 
            this.посчитатьМестаToolStripMenuItem.Name = "посчитатьМестаToolStripMenuItem";
            this.посчитатьМестаToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.посчитатьМестаToolStripMenuItem.Text = "Посчитать места и разряды";
            this.посчитатьМестаToolStripMenuItem.Click += new System.EventHandler(this.посчитатьМестаToolStripMenuItem_Click);
            // 
            // отчетыToolStripMenuItem
            // 
            this.отчетыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.генерироватьToolStripMenuItem,
            this.справкиОРазрядахToolStripMenuItem,
            this.протоколТураToolStripMenuItem,
            this.итоговыйПротоколToolStripMenuItem,
            this.выполненияподтвержденияРазрядныхНормToolStripMenuItem,
            this.дополнитьГодовойОтчетToolStripMenuItem});
            this.отчетыToolStripMenuItem.Name = "отчетыToolStripMenuItem";
            this.отчетыToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.отчетыToolStripMenuItem.Text = "Отчеты";
            // 
            // генерироватьToolStripMenuItem
            // 
            this.генерироватьToolStripMenuItem.Name = "генерироватьToolStripMenuItem";
            this.генерироватьToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.генерироватьToolStripMenuItem.Text = "Итоговый";
            this.генерироватьToolStripMenuItem.Click += new System.EventHandler(this.генерироватьToolStripMenuItem_Click);
            // 
            // справкиОРазрядахToolStripMenuItem
            // 
            this.справкиОРазрядахToolStripMenuItem.Name = "справкиОРазрядахToolStripMenuItem";
            this.справкиОРазрядахToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.справкиОРазрядахToolStripMenuItem.Text = "Справки о разрядах";
            this.справкиОРазрядахToolStripMenuItem.Click += new System.EventHandler(this.справкиОРазрядахToolStripMenuItem_Click);
            // 
            // протоколТураToolStripMenuItem
            // 
            this.протоколТураToolStripMenuItem.Name = "протоколТураToolStripMenuItem";
            this.протоколТураToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.протоколТураToolStripMenuItem.Text = "Протокол тура";
            this.протоколТураToolStripMenuItem.Click += new System.EventHandler(this.протоколТураToolStripMenuItem_Click);
            // 
            // итоговыйПротоколToolStripMenuItem
            // 
            this.итоговыйПротоколToolStripMenuItem.Name = "итоговыйПротоколToolStripMenuItem";
            this.итоговыйПротоколToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.итоговыйПротоколToolStripMenuItem.Text = "Итоговый протокол";
            this.итоговыйПротоколToolStripMenuItem.Click += new System.EventHandler(this.итоговыйПротоколToolStripMenuItem_Click);
            // 
            // выполненияподтвержденияРазрядныхНормToolStripMenuItem
            // 
            this.выполненияподтвержденияРазрядныхНормToolStripMenuItem.Name = "выполненияподтвержденияРазрядныхНормToolStripMenuItem";
            this.выполненияподтвержденияРазрядныхНормToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.выполненияподтвержденияРазрядныхНормToolStripMenuItem.Text = "Выполнение разрядных норм ";
            this.выполненияподтвержденияРазрядныхНормToolStripMenuItem.Click += new System.EventHandler(this.выполненияподтвержденияРазрядныхНормToolStripMenuItem_Click);
            // 
            // дополнитьГодовойОтчетToolStripMenuItem
            // 
            this.дополнитьГодовойОтчетToolStripMenuItem.Name = "дополнитьГодовойОтчетToolStripMenuItem";
            this.дополнитьГодовойОтчетToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.дополнитьГодовойОтчетToolStripMenuItem.Text = "Дополнить годовой отчет";
            this.дополнитьГодовойОтчетToolStripMenuItem.Click += new System.EventHandler(this.дополнитьГодовойОтчетToolStripMenuItem_Click);
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.рейтингЛистToolStripMenuItem,
            this.тестированиеToolStripMenuItem,
            this.оПрограммеToolStripMenuItem,
            this.восстановлениеToolStripMenuItem});
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(107, 20);
            this.справкаToolStripMenuItem.Text = "Дополнительно";
            // 
            // рейтингЛистToolStripMenuItem
            // 
            this.рейтингЛистToolStripMenuItem.Name = "рейтингЛистToolStripMenuItem";
            this.рейтингЛистToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.рейтингЛистToolStripMenuItem.Text = "Рейтинг лист";
            this.рейтингЛистToolStripMenuItem.Click += new System.EventHandler(this.рейтингЛистToolStripMenuItem_Click);
            // 
            // тестированиеToolStripMenuItem
            // 
            this.тестированиеToolStripMenuItem.Name = "тестированиеToolStripMenuItem";
            this.тестированиеToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.тестированиеToolStripMenuItem.Text = "Тестирование";
            this.тестированиеToolStripMenuItem.Click += new System.EventHandler(this.тестированиеToolStripMenuItem_Click);
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.оПрограммеToolStripMenuItem_Click);
            // 
            // восстановлениеToolStripMenuItem
            // 
            this.восстановлениеToolStripMenuItem.Enabled = false;
            this.восстановлениеToolStripMenuItem.Name = "восстановлениеToolStripMenuItem";
            this.восстановлениеToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.восстановлениеToolStripMenuItem.Text = "Восстановление";
            this.восстановлениеToolStripMenuItem.Click += new System.EventHandler(this.восстановлениеToolStripMenuItem_Click);
            // 
            // tours
            // 
            this.tours.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tours.Controls.Add(this.System_count_btn);
            this.tours.Controls.Add(this.Nextbutton);
            this.tours.Controls.Add(this.Xbutton);
            this.tours.Controls.Add(this.game_table);
            this.tours.Controls.Add(this.winget_button);
            this.tours.Controls.Add(this.Tour_numericUpDown);
            this.tours.Location = new System.Drawing.Point(12, 263);
            this.tours.Name = "tours";
            this.tours.Size = new System.Drawing.Size(334, 286);
            this.tours.TabIndex = 1;
            this.tours.TabStop = false;
            this.tours.Text = "Туры";
            // 
            // System_count_btn
            // 
            this.System_count_btn.Location = new System.Drawing.Point(89, 15);
            this.System_count_btn.Name = "System_count_btn";
            this.System_count_btn.Size = new System.Drawing.Size(238, 27);
            this.System_count_btn.TabIndex = 3;
            this.System_count_btn.Text = "Составить пары";
            this.System_count_btn.UseVisualStyleBackColor = true;
            this.System_count_btn.Click += new System.EventHandler(this.System_count_Click);
            // 
            // Nextbutton
            // 
            this.Nextbutton.Location = new System.Drawing.Point(258, 15);
            this.Nextbutton.Name = "Nextbutton";
            this.Nextbutton.Size = new System.Drawing.Size(69, 27);
            this.Nextbutton.TabIndex = 4;
            this.Nextbutton.Text = "След. тур";
            this.Nextbutton.UseVisualStyleBackColor = true;
            this.Nextbutton.Click += new System.EventHandler(this.Nextbutton_Click);
            // 
            // Xbutton
            // 
            this.Xbutton.Location = new System.Drawing.Point(55, 15);
            this.Xbutton.Name = "Xbutton";
            this.Xbutton.Size = new System.Drawing.Size(28, 27);
            this.Xbutton.TabIndex = 3;
            this.Xbutton.Text = "X";
            this.Xbutton.UseVisualStyleBackColor = true;
            this.Xbutton.Click += new System.EventHandler(this.Xbutton_Click);
            // 
            // game_table
            // 
            this.game_table.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.game_table.FullRowSelect = true;
            this.game_table.Location = new System.Drawing.Point(7, 51);
            this.game_table.MultiSelect = false;
            this.game_table.Name = "game_table";
            this.game_table.Size = new System.Drawing.Size(320, 229);
            this.game_table.TabIndex = 2;
            this.game_table.UseCompatibleStateImageBehavior = false;
            this.game_table.View = System.Windows.Forms.View.Details;
            this.game_table.SelectedIndexChanged += new System.EventHandler(this.game_table_SelectedIndexChanged);
            // 
            // winget_button
            // 
            this.winget_button.Location = new System.Drawing.Point(89, 15);
            this.winget_button.Name = "winget_button";
            this.winget_button.Size = new System.Drawing.Size(163, 27);
            this.winget_button.TabIndex = 1;
            this.winget_button.Text = "Ввести результаты тура";
            this.winget_button.UseVisualStyleBackColor = true;
            this.winget_button.Click += new System.EventHandler(this.winget_button_Click);
            // 
            // Tour_numericUpDown
            // 
            this.Tour_numericUpDown.Location = new System.Drawing.Point(7, 20);
            this.Tour_numericUpDown.Name = "Tour_numericUpDown";
            this.Tour_numericUpDown.Size = new System.Drawing.Size(41, 20);
            this.Tour_numericUpDown.TabIndex = 0;
            this.Tour_numericUpDown.ValueChanged += new System.EventHandler(this.Tour_numericUpDown_ValueChanged);
            // 
            // system
            // 
            this.system.Controls.Add(this.SystemResults_listBox);
            this.system.Location = new System.Drawing.Point(13, 28);
            this.system.Name = "system";
            this.system.Size = new System.Drawing.Size(333, 229);
            this.system.TabIndex = 2;
            this.system.TabStop = false;
            this.system.Text = "Система";
            // 
            // SystemResults_listBox
            // 
            this.SystemResults_listBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SystemResults_listBox.FormattingEnabled = true;
            this.SystemResults_listBox.HorizontalScrollbar = true;
            this.SystemResults_listBox.Location = new System.Drawing.Point(7, 20);
            this.SystemResults_listBox.Name = "SystemResults_listBox";
            this.SystemResults_listBox.Size = new System.Drawing.Size(319, 199);
            this.SystemResults_listBox.TabIndex = 0;
            this.SystemResults_listBox.SelectedIndexChanged += new System.EventHandler(this.SystemResults_listBox_SelectedIndexChanged);
            this.SystemResults_listBox.DoubleClick += new System.EventHandler(this.SystemResults_listBox_DoubleClick);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(352, 28);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(790, 521);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.down_button);
            this.tabPage1.Controls.Add(this.up_button);
            this.tabPage1.Controls.Add(this.Del_button);
            this.tabPage1.Controls.Add(this.Gone_button);
            this.tabPage1.Controls.Add(this.Editbutton);
            this.tabPage1.Controls.Add(this.Addbutton);
            this.tabPage1.Controls.Add(this.PlayerslistView);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(782, 495);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Данные игроков";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // Gone_button
            // 
            this.Gone_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Gone_button.Location = new System.Drawing.Point(207, 457);
            this.Gone_button.Name = "Gone_button";
            this.Gone_button.Size = new System.Drawing.Size(94, 32);
            this.Gone_button.TabIndex = 5;
            this.Gone_button.Text = "Отсутствует";
            this.Gone_button.UseVisualStyleBackColor = true;
            this.Gone_button.Click += new System.EventHandler(this.Gone_button_Click);
            // 
            // Editbutton
            // 
            this.Editbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Editbutton.Location = new System.Drawing.Point(107, 457);
            this.Editbutton.Name = "Editbutton";
            this.Editbutton.Size = new System.Drawing.Size(94, 32);
            this.Editbutton.TabIndex = 2;
            this.Editbutton.Text = "Редактировать";
            this.Editbutton.UseVisualStyleBackColor = true;
            this.Editbutton.Click += new System.EventHandler(this.Editbutton_Click);
            // 
            // Addbutton
            // 
            this.Addbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Addbutton.Location = new System.Drawing.Point(7, 457);
            this.Addbutton.Name = "Addbutton";
            this.Addbutton.Size = new System.Drawing.Size(94, 32);
            this.Addbutton.TabIndex = 1;
            this.Addbutton.Text = "Добавить";
            this.Addbutton.UseVisualStyleBackColor = true;
            this.Addbutton.Click += new System.EventHandler(this.Addbutton_Click);
            // 
            // PlayerslistView
            // 
            this.PlayerslistView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PlayerslistView.FullRowSelect = true;
            this.PlayerslistView.GridLines = true;
            this.PlayerslistView.HideSelection = false;
            this.PlayerslistView.Location = new System.Drawing.Point(7, 7);
            this.PlayerslistView.Name = "PlayerslistView";
            this.PlayerslistView.Size = new System.Drawing.Size(769, 444);
            this.PlayerslistView.TabIndex = 0;
            this.PlayerslistView.UseCompatibleStateImageBehavior = false;
            this.PlayerslistView.View = System.Windows.Forms.View.Details;
            this.PlayerslistView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.PlayerslistView_ColumnClick);
            this.PlayerslistView.SelectedIndexChanged += new System.EventHandler(this.PlayerslistView_SelectedIndexChanged);
            this.PlayerslistView.DoubleClick += new System.EventHandler(this.PlayerslistView_DoubleClick);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.linkLabel1);
            this.tabPage2.Controls.Add(this.numericUpDown1);
            this.tabPage2.Controls.Add(this.chart1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(761, 495);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Прогресс";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.LinkColor = System.Drawing.Color.Black;
            this.linkLabel1.Location = new System.Drawing.Point(350, 35);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(47, 13);
            this.linkLabel1.TabIndex = 6;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Игрок 1";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDown1.Location = new System.Drawing.Point(22, 24);
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(38, 24);
            this.numericUpDown1.TabIndex = 5;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Alignment = System.Drawing.StringAlignment.Center;
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(6, 54);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SemiTransparent;
            series1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            series1.BorderColor = System.Drawing.Color.Black;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
            series1.Color = System.Drawing.Color.Red;
            series1.IsValueShownAsLabel = true;
            series1.Legend = "Legend1";
            series1.Name = "Рейтинг Адамовича";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(700, 434);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Controls.Add(this.comboBox1);
            this.tabPage3.Controls.Add(this.chart2);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(761, 495);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Сводка";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(64, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Коэффициент";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(147, 26);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(156, 21);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // chart2
            // 
            this.chart2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea2.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea2);
            legend2.Alignment = System.Drawing.StringAlignment.Center;
            legend2.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend2.Name = "Legend1";
            this.chart2.Legends.Add(legend2);
            this.chart2.Location = new System.Drawing.Point(6, 53);
            this.chart2.Name = "chart2";
            this.chart2.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            this.chart2.PaletteCustomColors = new System.Drawing.Color[] {
        System.Drawing.Color.Aqua};
            series2.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.HorizontalCenter;
            series2.BorderColor = System.Drawing.Color.Red;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            series2.Color = System.Drawing.Color.Red;
            series2.IsValueShownAsLabel = true;
            series2.Legend = "Legend1";
            series2.MarkerBorderColor = System.Drawing.Color.White;
            series2.Name = "Итоговый";
            this.chart2.Series.Add(series2);
            this.chart2.Size = new System.Drawing.Size(700, 436);
            this.chart2.TabIndex = 1;
            this.chart2.Text = "chart2";
            // 
            // Del_button
            // 
            this.Del_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Del_button.Location = new System.Drawing.Point(307, 457);
            this.Del_button.Name = "Del_button";
            this.Del_button.Size = new System.Drawing.Size(94, 32);
            this.Del_button.TabIndex = 6;
            this.Del_button.Text = "Удалить";
            this.Del_button.UseVisualStyleBackColor = true;
            this.Del_button.Click += new System.EventHandler(this.Del_button_Click);
            // 
            // up_button
            // 
            this.up_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.up_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.up_button.Location = new System.Drawing.Point(706, 456);
            this.up_button.Name = "up_button";
            this.up_button.Size = new System.Drawing.Size(32, 32);
            this.up_button.TabIndex = 7;
            this.up_button.Text = "˄";
            this.up_button.UseVisualStyleBackColor = true;
            this.up_button.Click += new System.EventHandler(this.up_button_Click);
            // 
            // down_button
            // 
            this.down_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.down_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.down_button.Location = new System.Drawing.Point(744, 456);
            this.down_button.Name = "down_button";
            this.down_button.Size = new System.Drawing.Size(32, 32);
            this.down_button.TabIndex = 8;
            this.down_button.Text = "˅";
            this.down_button.UseVisualStyleBackColor = true;
            this.down_button.Click += new System.EventHandler(this.down_button_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BackgroundImage = global::Tavleya2.Properties.Resources.fon;
            this.ClientSize = new System.Drawing.Size(1154, 561);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.system);
            this.Controls.Add(this.tours);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Тавлея";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tours.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Tour_numericUpDown)).EndInit();
            this.system.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem новыйToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem соревнованияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem данныеТурнираToolStripMenuItem;
        private System.Windows.Forms.GroupBox tours;
        private System.Windows.Forms.NumericUpDown Tour_numericUpDown;
        private System.Windows.Forms.GroupBox system;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ToolStripMenuItem отчетыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem генерироватьToolStripMenuItem;
        private System.Windows.Forms.ListView PlayerslistView;
        private System.Windows.Forms.Button Addbutton;
        private System.Windows.Forms.ListView game_table;
        private System.Windows.Forms.Button winget_button;
        private System.Windows.Forms.Button Editbutton;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox SystemResults_listBox;
        private System.Windows.Forms.Button Xbutton;
        private System.Windows.Forms.Button Nextbutton;
        private System.Windows.Forms.Button System_count_btn;
        private System.Windows.Forms.Button Gone_button;
        private ToolStripMenuItem справкиОРазрядахToolStripMenuItem;
        private ToolStripMenuItem справкаToolStripMenuItem;
        private ToolStripMenuItem тестированиеToolStripMenuItem;
        private ToolStripMenuItem оПрограммеToolStripMenuItem;
        private ToolStripMenuItem посчитатьМестаToolStripMenuItem;
        private ToolStripMenuItem протоколТураToolStripMenuItem;
        private ToolStripMenuItem итоговыйПротоколToolStripMenuItem;
        private ToolStripMenuItem выполненияподтвержденияРазрядныхНормToolStripMenuItem;
        private ToolStripMenuItem рейтингЛистToolStripMenuItem;
        private ToolStripMenuItem дополнитьГодовойОтчетToolStripMenuItem;
        private ToolStripMenuItem восстановлениеToolStripMenuItem;
        private Button down_button;
        private Button up_button;
        private Button Del_button;
    }
}

