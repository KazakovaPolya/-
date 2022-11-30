using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace курсовая_ООП
{
    public partial class form_menu : Form
    {
        public form_menu()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //Form1 form1 = new Form1(this);
            Form2 form2 = new Form2(this);
            form2.Show();
            //form1.Show();
            this.Hide();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            form_client form = new form_client(this);
            form.Show();
            this.Hide();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            help_Form2 form2 = new help_Form2(this);
            form2.Show();
            this.Hide();
        }
    }
}
