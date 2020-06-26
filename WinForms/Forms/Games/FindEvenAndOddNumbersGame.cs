using System;
using System.Linq;
using System.Windows.Forms;
using WinForms.Context;
using WinForms.Forms.Account;
using WinForms.Models;

namespace WinForms.Forms.Games
{
    public partial class FindEvenAndOddNumbersGame : Form
    {

        private readonly DefaultContext _context = new DefaultContext();
        private readonly DateTime _start = DateTime.Now;
        private readonly Random _random = new Random();

        private int _even = 0;
        private int _odd = 0;
        private int _timerLeft = 0;

        public FindEvenAndOddNumbersGame()
        {
            InitializeComponent();
            AssignNumbersToSquare();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void label_Click(object sender, EventArgs e)
        {
            int numbers = _random.Next(100);
           

            var control = (Control)sender;

            if (numbers % 2 == 0)
            {
                _odd++;
                control.Enabled = false;
            }
            else
            {
                _even++;
            }
           
        }

        void AssignNumbersToSquare()
        {
            for (var i = 0; i < tableLayoutPanel1.Controls.Count; i++)
            {
                Label label;
                if (tableLayoutPanel1.Controls[i] is Label)
                    label = (Label)tableLayoutPanel1.Controls[i];
                else
                    continue;
                label.Text = _random.Next(1000).ToString();
            }
        }
        private void FindEvenAndOddNumbersGame_Load(object sender, EventArgs e)
        {
            time.Enabled = true;
            time.Stop();
        }
        private void startGame_button(object sender, EventArgs e)
        {
            _timerLeft = 15;
            Timer.Text = _timerLeft.ToString();

            StartGame.Enabled = false;
            tableLayoutPanel1.Enabled = true;

            time.Start();
        }
        private void Timer_tick(object sender, EventArgs e)
        {
            if (_timerLeft > 0)
            {
                _timerLeft--;
                Timer.Text = _timerLeft.ToString();
            }

            if (_timerLeft == 0)
            {
                time.Stop();

                var currentUser = LoginForm.LoggedUser.Id;
                var use = _context.Users.FirstOrDefault(c => c.Id == currentUser);
                var resultGame = new Statistic
                {
                    Created = _start,
                    GameType = GameType.FindEvenAndOddNumbers,
                    SuccessCount = _even,
                    User = use,
                    WrongCount = _odd
                };

                _context.Add(resultGame);
                _context.SaveChanges();

                MessageBox.Show(Timer.Text = " Четные : " + _even +
                                             "\n Нечетные : " + _odd);
                Close();
            }
        }
        private void FindEvenAndOddNumbersGame_Shown(object sender, EventArgs e)
        {
            _odd = 0;
            _even = 0;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            FindEvenAndOddNumbersGame findEvenAndOdd = new FindEvenAndOddNumbersGame();
            findEvenAndOdd.Show();
            this.Close();
        }
    }
}
