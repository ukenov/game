using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WinForms.Context;
using WinForms.Forms.Account;
using WinForms.Forms.Games;
using WinForms.Models;

namespace WinForms.Forms
{
    public partial class Day : Form
    {
        public Day()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Day1_Load(object sender, EventArgs e)
        {
            var age = LoginForm.LoggedUser.Age;

            if (age == "6" ||
                age == "7" ||
                age == "8 ")
            {
                labelAge.Text = "6 - 8 Лет";
            }

            if (age == "9" ||
                age == "10" ||
                age == "11" ||
                age == "12")
            {
                labelAge.Text = "9 - 12 Лет";
            }

            if (age == "13" ||
                age == "14" ||
                age == "15" ||
                age == "16")
            {
                labelAge.Text = "13 - 16 Лет";
            }

            ///////////////////////////////////////////

            Day day1 = Form1.Day1;
            day1.labelDay.Text = "1 День";

            Day day2 = Form1.Day2;
            day2.labelDay.Text = "2 День";

            Day day3 = Form1.Day3;
            day3.labelDay.Text = "3 День";

            Day day4 = Form1.Day4;
            day4.labelDay.Text = "4 День";

            Day day5 = Form1.Day5;
            day5.labelDay.Text = "5 День";

            Day day6 = Form1.Day6;
            day6.labelDay.Text = "6 День";

            Day day7 = Form1.Day7;
            day7.labelDay.Text = "7 День";

            Day day8 = Form1.Day8;
            day8.labelDay.Text = "8 День";

            Day day9 = Form1.Day9;
            day9.labelDay.Text = "9 День";

            Day day10 = Form1.Day10;
            day10.labelDay.Text = "10 День";

        }

        private void RandomGame()
        {
            Random randomNum = new Random();
            int random = randomNum.Next(1, 11);

            switch (random)
            {
                case 1:
                    StringGame stringGame = new StringGame();
                    stringGame.ShowDialog();
                    break;
                case 2:
                    WordFindGame wordFindGame = new WordFindGame();
                    wordFindGame.ShowDialog();
                    break;
                case 3:
                    NumberGame numberGame = new NumberGame();
                    numberGame.ShowDialog();
                    break;
                case 4:
                    NumberFindGame numberFindGame = new NumberFindGame();
                    numberFindGame.ShowDialog();
                    break;
                case 5:
                    FindEvenAndOddNumbersGame findEvenAnd = new FindEvenAndOddNumbersGame();
                    findEvenAnd.ShowDialog();
                    break;
                case 6:
                    CoubeGame coubeGame = new CoubeGame();
                    coubeGame.ShowDialog();
                    break;
                case 7:
                    CoubeGameLevel2 coubeGameLevel2 = new CoubeGameLevel2();
                    coubeGameLevel2.ShowDialog();
                    break;
                case 8:
                    MathTimedGame mathTimedGame = new MathTimedGame();
                    mathTimedGame.ShowDialog();
                    break;
                case 9:
                    MathTimedGameLevel2 mathTimedGameLevel2 = new MathTimedGameLevel2();
                    mathTimedGameLevel2.ShowDialog();
                    break;
                case 10:
                    MathTimedGameLevel3 mathTimedGameLevel3 = new MathTimedGameLevel3();
                    mathTimedGameLevel3.ShowDialog();
                    break;
                case 11:
                    SchulteTable schultzTable = new SchulteTable();
                    schultzTable.ShowDialog();
                    break;
                case 12:
                    SchulteTableLevel2 schultzTableLevel2 = new SchulteTableLevel2();
                    schultzTableLevel2.ShowDialog();
                    break;
                case 13:
                    SchulteTableLevel3 schultzTableLevel3 = new SchulteTableLevel3();
                    schultzTableLevel3.ShowDialog();
                    break;
            }
        }
        private void LabelAge_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            CoubeGame coubeGame = new CoubeGame();
            coubeGame.ShowDialog();
            RandomGame();
            button2.Enabled = true;
            button1.Enabled = false;

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (button2.Enabled == true)
            {
                button2.Enabled = false;
                RandomGame();
                button3.Enabled = true;
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (button3.Enabled == true)
            {
                button3.Enabled = false;
                RandomGame();
                button4.Enabled = true;
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if (button4.Enabled == true)
            {
                button4.Enabled = false;
                RandomGame();
                button5.Enabled = true;
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            if (button5.Enabled == true)
            {
                button5.Enabled = false;
                RandomGame();
                button6.Enabled = true;
            }
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            if (button6.Enabled == true)
            {
                button6.Enabled = false;
                RandomGame();
                button7.Enabled = true;
            }
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            if (button7.Enabled == true)
            {
                button7.Enabled = false;
                RandomGame();
                button8.Enabled = true;
            }
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            if (button8.Enabled == true)
            {
                button8.Enabled = false;
                RandomGame();
            }
        }
    }
}
