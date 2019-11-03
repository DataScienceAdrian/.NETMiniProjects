using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Double wartosc = 0;
        string operation = "";
        bool operator_klikniety = false;

        int zliczKropki = 0;


        private void operator_click(object sender, EventArgs e)
        {

            Button b = (Button)sender;
            operation = b.Text;

            Int64 R;
            double R2;
            
            if (Int64.TryParse(inputBox.Text, out R))
            {

                wartosc = R;
                operator_klikniety = true;
                rownanie.Text = wartosc + " " + operation;


            }

            

            else if (double.TryParse(inputBox.Text, out R2))
            {


                wartosc = R2;
                operator_klikniety = true;
                rownanie.Text = wartosc + " " + operation;
                
            }
            else
            {

            }

        }

        private void button_click(object sender, EventArgs e)
        {
            if ((inputBox.Text == "0") || (operator_klikniety))
            {


                inputBox.Clear();
                
                zliczKropki = 0;
            }



            operator_klikniety = false;
            Button b = (Button)sender;
            if (b.Text == "," && zliczKropki < 1)
            {
                if (inputBox.TextLength <= 15)
                {
                    zliczKropki++;
                    inputBox.Text = inputBox.Text + b.Text;
                }
            }
            if (b.Text != ",")
            {
                if (inputBox.TextLength <= 15)
                {
                    inputBox.Text = inputBox.Text + b.Text;
                }
            }

        }

        private void clear_click(object sender, EventArgs e)
        {
            inputBox.Text = "0";
            zliczKropki = 0;
        }

        private void clear_all(object sender, EventArgs e)
        {
            inputBox.Text = "0";
            wartosc = 0;
            zliczKropki = 0;
        }

        private void equal_click(object sender, EventArgs e)
        {
            rownanie.Text = "";

            switch (operation)
            {
                case "+":
                    inputBox.Text = (wartosc + Double.Parse(inputBox.Text)).ToString();
                    break;
                case "-":
                    inputBox.Text = (wartosc - Double.Parse(inputBox.Text)).ToString();
                    break;
                case "*":
                    inputBox.Text = (wartosc * Double.Parse(inputBox.Text)).ToString();
                    break;
                case "/":
                    inputBox.Text = (wartosc / Double.Parse(inputBox.Text)).ToString();
                    break;
                default:
                    break;
            }
            double ans = double.Parse(inputBox.Text);
            if (ans == (double)ans)
            {
                zliczKropki = 1;
            }
            else
                zliczKropki = 0;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void equation_Click(object sender, EventArgs e)
        {

        }

       

        private void button17_Click(object sender, EventArgs e)
        {
            inputBox.Text = "0";
            wartosc = 0;
            zliczKropki = 0;
            rownanie.Text = "";
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }
    }
}
