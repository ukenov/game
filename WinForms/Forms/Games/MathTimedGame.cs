using System;
using System.Linq;
using System.Windows.Forms;
using WinForms.Context;
using WinForms.Forms.Account;
using WinForms.Models;

namespace WinForms.Forms.Games
{
    public partial class MathTimedGame : Form
    {
        readonly DefaultContext _context = new DefaultContext();
        private readonly DateTime _start = DateTime.Now;

        public int TimerLeft;
        public int A;
        public int B;
        public MathTimedGame()
        {
            InitializeComponent();
        }
        private void startButton_Click(object sender, EventArgs e)
        {
            TimerLeft = 15;
            timerLabel.Text = TimerLeft.ToString();

            Random random = new Random();

            A = random.Next(10) + 1;
            B = random.Next(10) + 1;


            aPlusLabel.Text = A.ToString();
            bPlusLabel.Text = B.ToString();

            aMinusLabel.Text = A.ToString();
            bMinusLabel.Text = B.ToString();

            timer1.Start();

            startButton.Enabled = false;
            doneButton.Enabled = true;
        }
        private void doneButton_Click(object sender, EventArgs e)
        {
            doneButton.Enabled = false;
            startButton.Enabled = true;
            timer1.Stop();

            int resultPlus = A + B;
            int resultMinus = A - B;

            var currentUser = LoginForm.LoggedUser.Id;
            var use = _context.Users.FirstOrDefault(c => c.Id == currentUser);
            var resultGame = new Statistic { Created = _start, GameType = GameType.MathTImeGame, User = use, };

            if (answerPlusBox.Text == resultPlus.ToString()
                && AnswerMinusBox.Text == resultMinus.ToString())
            {
                timer1.Stop();
                timerLabel.Text = "Вы выиграли!";
                answerPlusBox.Text = "";
                AnswerMinusBox.Text = "";
              

                _context.Add(resultGame);
                _context.SaveChanges();

                Hide();
            }
            else
            {
                timerLabel.Text = "Вы проиграли";
            }

        }

        private void MathTimedGame_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Stop();
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
        private void answerBox_TextChanged(object sender, EventArgs e)
        {
        }

        private void timerLabel_Click(object sender, EventArgs e)
        {
        }
    }
}
