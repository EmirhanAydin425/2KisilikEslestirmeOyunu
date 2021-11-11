using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eşleştirme
{
    public partial class Form1 : Form
    {
        List<string> icons = new List<string>()
        {
            "!",",","b","k","v","w","z","N",
            "!",",","b","k","v","w","z","N",
        };
        Random rnd = new Random();
        int randomindex;
        Timer t = new Timer();
        Timer t2 = new Timer();
        Button ilk, ikinci;
        public Form1()
        {
            InitializeComponent();
            t.Tick += T_Tick;
            t.Start();
            t.Interval = 10000;
            Göster();
            t2.Tick += T2_Tick;
        }

        private void T2_Tick(object sender, EventArgs e)
        {
            t2.Stop();
            ilk.ForeColor = ilk.BackColor;
            ikinci.ForeColor = ikinci.BackColor;
            ilk = null;
            ikinci = null;
        }

        private void T_Tick(object sender, EventArgs e)
        {
            t.Stop();
            foreach(Button item in Controls)
            {
                item.ForeColor = item.BackColor;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void Göster()
        {
            Button btn;
            foreach (Button item in Controls)
            {
                btn = item as Button;
                randomindex = rnd.Next(icons.Count);
                btn.Text = icons[randomindex];
                btn.ForeColor = Color.Black;
                icons.RemoveAt(randomindex);
            }

        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if(ilk == null)
            {
                ilk = btn;
                ilk.ForeColor = Color.Black;
                return;
            }
            ikinci = btn;
            ikinci.ForeColor = Color.Black;
            if(ilk.Text == ikinci.Text)
            {
                ilk.ForeColor = Color.Black;
                ikinci.ForeColor = Color.Black;
                ilk = null;
                ikinci = null;
            }
            else
            {
                t2.Start();
                t2.Interval = 1000;
            }
        }
    }
}
