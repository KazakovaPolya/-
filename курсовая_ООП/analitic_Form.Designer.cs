namespace курсовая_ООП
{
    partial class analitic_Form
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.return_menu_button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(25, 36);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(861, 422);
            this.dataGridView1.TabIndex = 0;
            // 
            // return_menu_button1
            // 
            this.return_menu_button1.Location = new System.Drawing.Point(940, 39);
            this.return_menu_button1.Name = "return_menu_button1";
            this.return_menu_button1.Size = new System.Drawing.Size(112, 69);
            this.return_menu_button1.TabIndex = 1;
            this.return_menu_button1.Text = "Возврат в меню";
            this.return_menu_button1.UseVisualStyleBackColor = true;
            this.return_menu_button1.Click += new System.EventHandler(this.Return_menu_button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(940, 162);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(112, 242);
            this.textBox1.TabIndex = 2;
            // 
            // analitic_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1102, 483);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.return_menu_button1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "analitic_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Аналитика";
            this.Load += new System.EventHandler(this.Analitic_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button return_menu_button1;
        public System.Windows.Forms.TextBox textBox1;
    }
}