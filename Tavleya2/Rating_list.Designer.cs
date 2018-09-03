namespace Tavleya2
{
    partial class Rating_list
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.save_btn = new System.Windows.Forms.Button();
            this.open_btn = new System.Windows.Forms.Button();
            this.concat_btn = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.search_textBox = new System.Windows.Forms.TextBox();
            this.search_btn = new System.Windows.Forms.Button();
            this.Add_to_pl_btn = new System.Windows.Forms.Button();
            this.Add_pl_btn = new System.Windows.Forms.Button();
            this.del_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // save_btn
            // 
            this.save_btn.Location = new System.Drawing.Point(13, 13);
            this.save_btn.Name = "save_btn";
            this.save_btn.Size = new System.Drawing.Size(155, 23);
            this.save_btn.TabIndex = 0;
            this.save_btn.Text = "Сохранить как новый";
            this.save_btn.UseVisualStyleBackColor = true;
            this.save_btn.Click += new System.EventHandler(this.save_btn_Click);
            // 
            // open_btn
            // 
            this.open_btn.Location = new System.Drawing.Point(335, 13);
            this.open_btn.Name = "open_btn";
            this.open_btn.Size = new System.Drawing.Size(75, 23);
            this.open_btn.TabIndex = 1;
            this.open_btn.Text = "Открыть";
            this.open_btn.UseVisualStyleBackColor = true;
            this.open_btn.Click += new System.EventHandler(this.open_btn_Click);
            // 
            // concat_btn
            // 
            this.concat_btn.Location = new System.Drawing.Point(174, 13);
            this.concat_btn.Name = "concat_btn";
            this.concat_btn.Size = new System.Drawing.Size(155, 23);
            this.concat_btn.TabIndex = 2;
            this.concat_btn.Text = "Обновить существующий";
            this.concat_btn.UseVisualStyleBackColor = true;
            this.concat_btn.Click += new System.EventHandler(this.concat_btn_Click);
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.CheckBoxes = true;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(15, 42);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(785, 407);
            this.listView1.TabIndex = 3;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // search_textBox
            // 
            this.search_textBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.search_textBox.Location = new System.Drawing.Point(572, 15);
            this.search_textBox.Name = "search_textBox";
            this.search_textBox.Size = new System.Drawing.Size(147, 20);
            this.search_textBox.TabIndex = 4;
            // 
            // search_btn
            // 
            this.search_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.search_btn.Location = new System.Drawing.Point(725, 13);
            this.search_btn.Name = "search_btn";
            this.search_btn.Size = new System.Drawing.Size(75, 23);
            this.search_btn.TabIndex = 5;
            this.search_btn.Text = "Поиск";
            this.search_btn.UseVisualStyleBackColor = true;
            this.search_btn.Click += new System.EventHandler(this.search_btn_Click);
            // 
            // Add_to_pl_btn
            // 
            this.Add_to_pl_btn.Location = new System.Drawing.Point(13, 455);
            this.Add_to_pl_btn.Name = "Add_to_pl_btn";
            this.Add_to_pl_btn.Size = new System.Drawing.Size(174, 23);
            this.Add_to_pl_btn.TabIndex = 6;
            this.Add_to_pl_btn.Text = "Добавить в список игроков";
            this.Add_to_pl_btn.UseVisualStyleBackColor = true;
            this.Add_to_pl_btn.Click += new System.EventHandler(this.Add_btn_Click);
            // 
            // Add_pl_btn
            // 
            this.Add_pl_btn.Location = new System.Drawing.Point(193, 455);
            this.Add_pl_btn.Name = "Add_pl_btn";
            this.Add_pl_btn.Size = new System.Drawing.Size(167, 23);
            this.Add_pl_btn.TabIndex = 7;
            this.Add_pl_btn.Text = "Добавить из списка игроков";
            this.Add_pl_btn.UseVisualStyleBackColor = true;
            this.Add_pl_btn.Click += new System.EventHandler(this.Add_pl_btn_Click);
            // 
            // del_button
            // 
            this.del_button.Location = new System.Drawing.Point(366, 455);
            this.del_button.Name = "del_button";
            this.del_button.Size = new System.Drawing.Size(75, 23);
            this.del_button.TabIndex = 8;
            this.del_button.Text = "Удалить";
            this.del_button.UseVisualStyleBackColor = true;
            this.del_button.Click += new System.EventHandler(this.del_button_Click);
            // 
            // Rating_list
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 487);
            this.Controls.Add(this.del_button);
            this.Controls.Add(this.Add_pl_btn);
            this.Controls.Add(this.Add_to_pl_btn);
            this.Controls.Add(this.search_btn);
            this.Controls.Add(this.search_textBox);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.concat_btn);
            this.Controls.Add(this.open_btn);
            this.Controls.Add(this.save_btn);
            this.Name = "Rating_list";
            this.Text = "Рейтинг Лист";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button save_btn;
        private System.Windows.Forms.Button open_btn;
        private System.Windows.Forms.Button concat_btn;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.TextBox search_textBox;
        private System.Windows.Forms.Button search_btn;
        private System.Windows.Forms.Button Add_to_pl_btn;
        private System.Windows.Forms.Button Add_pl_btn;
        private System.Windows.Forms.Button del_button;
    }
}