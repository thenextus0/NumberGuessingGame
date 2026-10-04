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
    public partial class UserGuessing : Form
    {
        public UserGuessing()
        {
            InitializeComponent();
        }

        private string bulunacaks;
        
        private void rastgelesayi()
        {
            bool rkmfarkli;
            Random rastgeles = new Random();
            do
            {
                rkmfarkli = true;
                bulunacaks = rastgeles.Next(1023, 10000).ToString();
                for (int i = 0; i < bulunacaks.Length - 1; i++)
                    for (int j = i + 1; j < bulunacaks.Length; j++)
                        if (bulunacaks[i] == bulunacaks[j]) rkmfarkli = false;
            } while (rkmfarkli == false);
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
                int dogruyer = 0, yanlisyer = 0;
                for (int i = 0; i < bulunacaks.Length; i++)
                    for (int j = 0; j < kontrol.Length; j++)
                        if (bulunacaks[i] == kontrol[j])
                            if (i == j) dogruyer++;
                            else yanlisyer++;
                label2.Text = "Doğru Yer: " + dogruyer + " | Yanlış Yer: " + yanlisyer;
                label4.Text = (Convert.ToInt32(label4.Text) + 1).ToString();
                textBox1.Focus();

                if (dogruyer == 4)
                {
                    button1.Visible = false;
                    button5.Visible = false;
                    button6.Visible = false;
                    textBox1.Enabled = false;
                    button2.Visible = true;
                    button3.Visible = true;
                    button4.Visible = true;
                    MessageBox.Show("Tebrikler, tahminin doğru. Oyun bitti.");

                }
            }
            else MessageBox.Show("Girdiğiniz tahmin hatalı. Lütfen tekrar deneyiniz.");
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) button1.PerformClick();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            rastgelesayi();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ChooseScreen choosescreen = new ChooseScreen();
            choosescreen.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            textBox1.Text = "";
            textBox1.Enabled = true;
            button1.Visible = true;
            button5.Visible = true;
            button6.Visible = true;
            label4.Text = "0";
            label2.Text = "Doğru Yer: 0 | Yanlış Yer: 0";
            rastgelesayi();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
