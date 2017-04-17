using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FSMCalc
{
    public partial class Form1 : Form
    {
        States s = new States();
     
        void ChangeTextBox(string text)
        {
            textBox1.Text = text;
        }
        public Form1()
        {
            InitializeComponent();
            s.invoker = ChangeTextBox;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
             
        }

        private void digitbtnclck(object sender, EventArgs ar)
        {
            Button btn = sender as Button;
            char item = btn.Text[0];
           
                s.Process(item);
        }

        private void opbtn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            char item = btn.Name[0];

            if (item == 'A')
            {
                s.result = "";
                textBox1.Text = "";
            }
            else if (item == 'p')
            {
                Glob.saved = textBox1.Text;
              
            }
            else if (item == 'u')
            {
                string k = s.result;
                s.result = "-";
                for (int i = 0; i < k.Length; i++)
                {
                    s.result += k[i];
                }
                textBox1.Text = s.result;
            }
            else if (item == 'z')
            {

                textBox1.Text = Glob.saved;
                s.result = textBox1.Text;
                s.Compute('=', true);
            }
            else if (item == 'c')
            {
                Glob.saved = "";
            }
            else if (item == 'v')
            {
                double k = double.Parse(textBox1.Text);
                double f = double.Parse(Glob.saved);
                s.number = s.result;
                s.result = "";
                textBox1.Text = (f + k).ToString();
            }
            else if (item == 'l')
            {
                double k = double.Parse(textBox1.Text);
                double f = double.Parse(Glob.saved);
                s.number = s.result;
                s.result = "";
                textBox1.Text = (k - f).ToString();
            }
            else s.Process(item);
        }

        private void sprtbtn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            char item = btn.Name[0];
            
            
                s.Process(item);
      
        }

        private void eqbtn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            char item = btn.Name[0];
            if(item!='k') s.Process(item);
            else
            {
                string k = s.result;
                s.result = "";
                for (int i = 0; i < k.Length - 1; i++)
                {
                    s.result += k[i];
                }
                textBox1.Text = s.result.ToString();
            }

        }
    }
}
