using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinForms.Context;
using WinForms.Forms.Account;
using WinForms.Models;

namespace WinForms.Forms.Games
{
    public partial class MathTimedGameLevel2 : Form
    {
        readonly DefaultContext _context = new DefaultContext();
        private readonly DateTime _start = DateTime.Now;

        public int TimerLeft;
        public int A;
        public int B;
        public int A2;
        public int B2;

        public MathTimedGameLevel2()
        {
            InitializeComponent();
        }

        private void MathTimedGameLevel2_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Stop();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            TimerLeft = 20;
            timerLabel.Text = TimerLeft.ToString();

            Random random = new Random();

            A = random.Next(50) + 1;
            B = random.Next(50) + 1;
            A2 = random.Next(50) + 1;
            B2 = random.Next(50) + 1;

            aPlusLabel.Text = A.ToString();
            bPlusLabel.Text = B.ToString();

            aPlusLabel2.Text = A2.ToString();
            bPlusLabel2.Text = B2.ToString();

            aMinusLabel.Text = A.ToString();
            bMinusLabel.Text = B.ToString();

            aMinusLabel2.Text = A2.ToString();
            bMinusLabel2.Text = B2.ToString();

            timer1.Start();

            startButton.Enabled = false;
            doneButton.Enabled = true;
        }

        private void doneButton_Click(object sender, EventArgs e)
        {
            doneButton.Enabled = false;
            startButton.Enabled = true;
            timer1.Stop();

            int resultPlus = A + A2;
            int resultPlus2 = A2 + B2;
            int resultMinus = B2 - B;
            int resultMinus2 = B - A;


            var currentUser = LoginForm.LoggedUser.Id;
            var use = _context.Users.FirstOrDefault(c => c.Id == currentUser);
            var resultGame = new Statistic { Created = _start, GameType = GameType.MathTImeGameLevel2, User = use, };
        
            if (answerPlusBox.Text == resultPlus.ToString()
                && AnswerMinusBox.Text == resultMinus.ToString()
                && AnswerPlusBox2.Text == resultPlus2.ToString()
                && AnswerMinusBox2.Text == resultMinus2.ToString())
            {
                timer1.Stop();
                timerLabel.Text = "Вы выиграли!";
                answerPlusBox.Text = "";
                AnswerMinusBox.Text = "";
                AnswerPlusBox2.Text = "";
                AnswerMinusBox2.Text = "";


                _context.Add(resultGame);
                _context.SaveChanges();

                Close();
            }
            else
            {
                timerLabel.Text = "Вы проиграли";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (TimerLeft > 0)
            {
                TimerLeft--;
                timerLabel.Text = TimerLeft.ToString();
            }

            if (TimerLeft == 0)
            {
                doneButton.Enabled = false;
                startButton.Enabled = true;
                timer1.Stop();
                timerLabel.Text = "";
            }
        }
    }
}
