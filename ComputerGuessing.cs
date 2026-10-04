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
    public partial class ComputerGuessing : Form
    {
        public ComputerGuessing()
        {
            InitializeComponent();
        }

        public string bulunacaks;

        int[] a = new int[10];
        int[] b = new int[10];
        int[] c = new int[10];
        int[] d = new int[10];

        int[] pozitif = new int[10];
        int[] negatif = new int[10];

        int m = 0;

        private void rastgelesayi(Random rnd)
        {
            string gcc;
            bool rkmfarkli;
            do
            {
                rkmfarkli = true;
                gcc = gcc = rnd.Next(1023, 10000).ToString();
                for (int i = 0; i < gcc.Length - 1; i++)
                    for (int j = i + 1; j < gcc.Length; j++)
                        if (gcc[i] == gcc[j]) rkmfarkli = false;
            } while (rkmfarkli == false);
            d[m] = Convert.ToInt32(gcc[3].ToString());
            c[m] = Convert.ToInt32(gcc[2].ToString());
            b[m] = Convert.ToInt32(gcc[1].ToString());
            a[m] = Convert.ToInt32(gcc[0].ToString());
        }

        private void artieksi()
        {
            string tahmin = textBox1.Text;
            int gdogru = 0, gyanlis = 0;
            for (int i = 0; i < bulunacaks.Length; i++)
                for (int j = 0; j < tahmin.Length; j++)
                    if (bulunacaks[i] == tahmin[j])
                        if (i == j) gdogru = gdogru + 1;
                        else gyanlis = gyanlis + 1;


            //comboBox1.Text = gdogru.ToString();//for the automatic play (user just clicks a button.)
            //comboBox2.Text = (gyanlis * -1).ToString();//for the automatic play (user just clicks a button.)
            comboBox3.Text = gdogru.ToString();
            comboBox4.Text = (gyanlis * -1).ToString();
        }
        private void Form4_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;
            label7.Text = bulunacaks;

            Random rnd = new Random();
            rastgelesayi(rnd);
            textBox1.Text = "" + a[m] + b[m] + c[m] + d[m];
            artieksi();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int gdogru = Convert.ToInt32(comboBox1.Text);//Convert.ToInt32(comboBox3.Text);//for the automatic play (user just clicks a button.)
            int gyanlis = Convert.ToInt32(comboBox2.Text) * -1;//Convert.ToInt32(comboBox4.Text) * -1;//for the automatic play (user just clicks a button.)
            int bdogru = Convert.ToInt32(comboBox3.Text);
            int byanlis = Convert.ToInt32(comboBox4.Text) * -1;

            Random rnd = new Random();

            if (gdogru + gyanlis <= 4 && gdogru == bdogru && gyanlis == byanlis)
            {
                pozitif[m] = gdogru;
                if (pozitif[m] != 4)
                {
                    negatif[m] = gyanlis;
                    m++;
                    rastgelesayi(rnd);

                    for (int n = 0; n < m; n++)
                    {
                        int gccp = 0; int gccn = 0;
                        if (a[n] == b[m] || a[n] == c[m] || a[n] == d[m]) gccn++;
                        else if (a[n] == a[m]) gccp++;
                        if (b[n] == a[m] || b[n] == c[m] || b[n] == d[m]) gccn++;
                        else if (b[n] == b[m]) gccp++;
                        if (c[n] == a[m] || c[n] == b[m] || c[n] == d[m]) gccn++;
                        else if (c[n] == c[m]) gccp++;
                        if (d[n] == a[m] || d[n] == b[m] || d[n] == c[m]) gccn++;
                        else if (d[n] == d[m]) gccp++;
                        if (gccp != pozitif[n] || gccn != negatif[n])
                        {
                            rastgelesayi(rnd);
                            n = -1;
                        }
                    }
                }
                else
                {
                    button1.Visible = false;
                    button5.Visible = false;
                    button6.Visible = false;
                    button2.Visible = true;
                    button3.Visible = true;
                    button4.Visible = true;
                    MessageBox.Show("Aklından tuttuğun sayı " + textBox1.Text + "! " + (m + 1) + ". tahminde buldum.");
                }
                textBox1.Text = "" + a[m] + b[m] + c[m] + d[m];
                if (gdogru != 4) label5.Text = (Convert.ToInt32(label5.Text) + 1).ToString();
                artieksi();
            }
            else MessageBox.Show("Girilen doğru ve yanlış yer değerleri hatalı!");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            ChooseScreen choosescreen = new ChooseScreen();
            choosescreen.Show();
            this.Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            EnterANumber enteranumber = new EnterANumber();
            enteranumber.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
