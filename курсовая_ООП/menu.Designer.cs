namespace курсовая_ООП
{
    partial class menu
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
            this.components = new System.ComponentModel.Container();
            this.find = new System.Windows.Forms.TextBox();
            this.find_button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.analitic_button4 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.preparationsBindingSource6 = new System.Windows.Forms.BindingSource(this.components);
            this.preparationsDataSet = new курсовая_ООП.preparationsDataSet();
            this.preparationsBindingSource5 = new System.Windows.Forms.BindingSource(this.components);
            this.preparationsDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.preparationsBindingSource4 = new System.Windows.Forms.BindingSource(this.components);
            this.preparationsBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.preparationsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.preparationsTableAdapter1 = new курсовая_ООП.preparationsDataSetTableAdapters.preparationsTableAdapter();
            this.button5 = new System.Windows.Forms.Button();
            this.search_criteria_comboBox1 = new System.Windows.Forms.ComboBox();
            this.count_comboBox2 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.preparationsBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.preparationsDataSetBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.preparationsBindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.preparationsBindingSource6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.preparationsDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.preparationsBindingSource5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.preparationsDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.preparationsBindingSource4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.preparationsBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.preparationsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.preparationsBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.preparationsDataSetBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.preparationsBindingSource3)).BeginInit();
            this.SuspendLayout();
            // 
            // find
            // 
            this.find.Location = new System.Drawing.Point(46, 48);
            this.find.Name = "find";
            this.find.Size = new System.Drawing.Size(423, 22);
            this.find.TabIndex = 0;
            this.find.Text = "Поиск";
            this.find.Click += new System.EventHandler(this.Find_Click);
            // 
            // find_button1
            // 
            this.find_button1.Location = new System.Drawing.Point(621, 46);
            this.find_button1.Name = "find_button1";
            this.find_button1.Size = new System.Drawing.Size(118, 23);
            this.find_button1.TabIndex = 2;
            this.find_button1.Text = "Найти";
            this.find_button1.UseVisualStyleBackColor = true;
            this.find_button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(884, 146);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(97, 55);
            this.button2.TabIndex = 3;
            this.button2.Text = "Корзина";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(884, 238);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(97, 55);
            this.button3.TabIndex = 4;
            this.button3.Text = "Заказы";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // analitic_button4
            // 
            this.analitic_button4.Location = new System.Drawing.Point(884, 330);
            this.analitic_button4.Name = "analitic_button4";
            this.analitic_button4.Size = new System.Drawing.Size(97, 55);
            this.analitic_button4.TabIndex = 5;
            this.analitic_button4.Text = "Статистика";
            this.analitic_button4.UseVisualStyleBackColor = true;
            this.analitic_button4.Click += new System.EventHandler(this.Analitic_button4_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(46, 88);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(751, 312);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellContentClick);
            // 
            // preparationsBindingSource6
            // 
            this.preparationsBindingSource6.DataMember = "preparations";
            this.preparationsBindingSource6.DataSource = this.preparationsDataSet;
            // 
            // preparationsDataSet
            // 
            this.preparationsDataSet.DataSetName = "preparationsDataSet";
            this.preparationsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // preparationsBindingSource5
            // 
            this.preparationsBindingSource5.DataMember = "preparations";
            this.preparationsBindingSource5.DataSource = this.preparationsDataSetBindingSource;
            // 
            // preparationsDataSetBindingSource
            // 
            this.preparationsDataSetBindingSource.DataSource = this.preparationsDataSet;
            this.preparationsDataSetBindingSource.Position = 0;
            // 
            // preparationsTableAdapter1
            // 
            this.preparationsTableAdapter1.ClearBeforeFill = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(287, 424);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(130, 53);
            this.button5.TabIndex = 7;
            this.button5.Text = "Добавить в корзину";
            this.button5.UseCompatibleTextRendering = true;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.Button5_Click);
            // 
            // search_criteria_comboBox1
            // 
            this.search_criteria_comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.search_criteria_comboBox1.FormattingEnabled = true;
            this.search_criteria_comboBox1.Location = new System.Drawing.Point(484, 46);
            this.search_criteria_comboBox1.Name = "search_criteria_comboBox1";
            this.search_criteria_comboBox1.Size = new System.Drawing.Size(121, 24);
            this.search_criteria_comboBox1.TabIndex = 8;
            this.search_criteria_comboBox1.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
            // 
            // count_comboBox2
            // 
            this.count_comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.count_comboBox2.FormattingEnabled = true;
            this.count_comboBox2.Location = new System.Drawing.Point(212, 439);
            this.count_comboBox2.Name = "count_comboBox2";
            this.count_comboBox2.Size = new System.Drawing.Size(60, 24);
            this.count_comboBox2.TabIndex = 9;
            this.count_comboBox2.SelectedIndexChanged += new System.EventHandler(this.ComboBox2_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 442);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Выберите количество";
            // 
            // preparationsBindingSource2
            // 
            this.preparationsBindingSource2.DataMember = "preparations";
            this.preparationsBindingSource2.DataSource = this.preparationsDataSetBindingSource;
            // 
            // preparationsDataSetBindingSource1
            // 
            this.preparationsDataSetBindingSource1.DataSource = this.preparationsDataSet;
            this.preparationsDataSetBindingSource1.Position = 0;
            // 
            // preparationsBindingSource3
            // 
            this.preparationsBindingSource3.DataMember = "preparations";
            this.preparationsBindingSource3.DataSource = this.preparationsDataSetBindingSource1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(433, 9);
            this.label2.MaximumSize = new System.Drawing.Size(250, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(216, 34);
            this.label2.TabIndex = 11;
            this.label2.Text = "Выберите, по какому критерию осуществляется поиск";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(884, 46);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 56);
            this.button1.TabIndex = 12;
            this.button1.Text = "Обновить таблицу";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click_1);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(463, 424);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(206, 53);
            this.textBox1.TabIndex = 13;
            // 
            // menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 499);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.count_comboBox2);
            this.Controls.Add(this.search_criteria_comboBox1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.analitic_button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.find_button1);
            this.Controls.Add(this.find);
            this.Name = "menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Меню";
            this.Load += new System.EventHandler(this.Menu_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.preparationsBindingSource6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.preparationsDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.preparationsBindingSource5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.preparationsDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.preparationsBindingSource4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.preparationsBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.preparationsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.preparationsBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.preparationsDataSetBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.preparationsBindingSource3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox find;
        private System.Windows.Forms.Button find_button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button analitic_button4;
        public System.Windows.Forms.DataGridView dataGridView1;
        public preparationsDataSet preparationsDataSet;
        private System.Windows.Forms.BindingSource preparationsBindingSource;
        private preparationsDataSetTableAdapters.preparationsTableAdapter preparationsTableAdapter;
        private System.Windows.Forms.BindingSource preparationsDataSetBindingSource;
        private System.Windows.Forms.BindingSource preparationsBindingSource1;
        public preparationsDataSetTableAdapters.preparationsTableAdapter preparationsTableAdapter1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ComboBox search_criteria_comboBox1;
        private System.Windows.Forms.ComboBox count_comboBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource preparationsBindingSource2;
        private System.Windows.Forms.BindingSource preparationsBindingSource4;
        private System.Windows.Forms.BindingSource preparationsDataSetBindingSource1;
        private System.Windows.Forms.BindingSource preparationsBindingSource3;
        private System.Windows.Forms.BindingSource preparationsBindingSource5;
        private System.Windows.Forms.BindingSource preparationsBindingSource6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        // private preparationsDataSet1 preparationsDataSet1;
        //private System.Windows.Forms.BindingSource preparationsBindingSource7;
        // private preparationsDataSet1TableAdapters.preparationsTableAdapter preparationsTableAdapter2;
        //private preparationsDataSet preparationsDataSet;
    }
}

