using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WinForms
{
    public partial class FindGame : Form
    {
        readonly Random _random = new Random();

        private readonly Label _firstClick;

        readonly List<string> _numbers = new List<string>()
        {
            "0" ,"1" , "2" , "3" , "4" ,"5" , "6" , "7" , "8" ,"9",
            "0" ,"1" , "2" , "3" , "4" ,"5" , "6" , "7" , "8" ,"9",
            "0" ,"1" , "2" , "3" , "4" ,"5" , "6" , "7" , "8" ,"9"
        };
        public FindGame()
        {
            InitializeComponent();
            AssignNumbersToSquare();
           

        }
        
        private void LabelClick(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        void AssignNumbersToSquare()
        {
            for (int i = 0; i < tableLayoutPanel1.Controls.Count; i++)
            {
                Label label;
                if (tableLayoutPanel1.Controls[i] is Label)
                    label = (Label)tableLayoutPanel1.Controls[i];
                else
                    continue;

                var randomNumber = _random.Next(0, _numbers.Count);
                label.Text = _numbers[randomNumber];
                _numbers.RemoveAt(randomNumber);
            }
        }
    }
}
