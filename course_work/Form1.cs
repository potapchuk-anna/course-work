using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace course_work
{
    public partial class Form1 : Form
    {
        public GenerationForm generarionForm = new GenerationForm();
        public Form1()
        {
            InitializeComponent();
            AddOwnedForm(generarionForm);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            generarionForm.StartPosition = FormStartPosition.CenterScreen;
            generarionForm.Show();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
