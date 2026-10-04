using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp33
{
    public partial class EnterANumber : Form
    {
        public EnterANumber()
        {
            InitializeComponent();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) button1.PerformClick();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string kontrol = textBox1.Text;
            bool rkmfarkli = true;
            for (int i = 0; i < kontrol.Length - 1; i++)
                for (int j = i + 1; j < kontrol.Length; j++)
                    if (kontrol[i] == kontrol[j]) rkmfarkli = false;

            if (textBox1.Text.Length == 4 && kontrol[0] != '0' && rkmfarkli == true)
            {
                ComputerGuessing computerguessing = new ComputerGuessing();
                computerguessing.bulunacaks = kontrol;
                computerguessing.Show();
                this.Close();
            }
            else MessageBox.Show("Girdiğiniz sayı hatalı lütfen yeni bir sayı giriniz.");
        }

        private void label2_Click(object sender, EventArgs e)
        {
            if (textBox2.Visible == false) textBox2.Visible = true;
            else textBox2.Visible = false;
        }
    }
}
