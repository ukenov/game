using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WinForms.Context;
using WinForms.Forms.Account;
using WinForms.Models;

namespace WinForms.Forms.Games
{
    public partial class WordFindGame : Form
    {
        readonly DefaultContext _context = new DefaultContext();
        private readonly Random _random;
        private readonly List<string> _numbers;
        private int _successCount = 0;
        private int _wrongCount = 0;
        private int timerLeft;
        private DateTime _start = DateTime.Now;

        public WordFindGame()
        {
            InitializeComponent();
            _random = new Random();
            _numbers = new List<string>()
            {
                "Q" ,"W" , "E" , "R" , "T" ,
                "Y" , "U" , "I" , "O" , "P" ,
                "A" ,"S" , "D" , "F" , "G" ,
                "H" , "J" , "K", "L" ,"Z" ,
                "X" , "C" , "V" , "B" ,"N" , "M"
            };
        }

        void AssignStringToSquare()
        {
            var randomString = 0;

            for (int i = 0; i < tableLayoutPanel1.Controls.Count; i++)
            {
                Label label;
                if (tableLayoutPanel1.Controls[i] is Label)
                    label = (Label)tableLayoutPanel1.Controls[i];
                else
                    continue;

                randomString = _random.Next(0, _numbers.Count);

                label.Text = _numbers[randomString];
            }

            for (int s = 0; s < tableLayoutPanel2.Controls.Count; s++)
            {
                Label labelSymbol;
                if (tableLayoutPanel2.Controls[s] is Label)
                    labelSymbol = (Label)tableLayoutPanel2.Controls[s];
                else
                    continue;

                randomString = _random.Next(0, _numbers.Count);

                labelSymbol.Text = _numbers[randomString];

                _numbers.RemoveAt(randomString);
            }
        }

        private void label_Click(object sender, EventArgs e)
        {
            var control = (Control)sender;
            var text = label26.Text;

            var wordFindGameControl = IsAnyLabelExist(text);

            if (wordFindGameControl.Any)
            {
                if (label26.Text == control.Text)
                {
                    ++_successCount;
                    control.Enabled = false;
                }
                else
                {
                    ++_wrongCount;
                }
            }
            else
            {
                AssignStringToSquare();
                EnableAllLables();
            }
        }

        private void EnableAllLables()
        {
            foreach (var control in tableLayoutPanel1.Controls)
            {
                var label = (Label)control;
                label.Enabled = true;
            }
        }

        private WordFindGameControl IsAnyLabelExist(string text)
        {
            var wordFindGameControl = new WordFindGameControl();

            foreach (var control2 in tableLayoutPanel1.Controls)
            {
                var label = (Label)control2;
                if (label.Text == text && label.Enabled)
                {
                    wordFindGameControl.Controls.Add(label);
                    wordFindGameControl.Texts.Add(label.Text);
                    wordFindGameControl.Count++;
                }
            }

            wordFindGameControl.Any = wordFindGameControl.Count != 0;

            return wordFindGameControl;
        }

        private void label_Click2(object sender, EventArgs e)
        {

        }

        private void WordFindGame_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Stop();
        }

        private void WordFindGame_Shown(object sender, EventArgs e)
        {
            _wrongCount = 0;
            _successCount = 0;
            AssignStringToSquare();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var currentUser = LoginForm.LoggedUser.Id;
            var use = _context.Users.FirstOrDefault(c => c.Id == currentUser);
            var resultGame = new Statistic { Created = _start, GameType = GameType.WordFindGame, SuccessCount = _successCount, User = use, WrongCount = _wrongCount };
            if (timerLeft > 0)
            {
                timerLeft--;
                Timer.Text = timerLeft.ToString();
            }

            if (timerLeft == 0)
            {
                timer1.Stop();

                Timer.Text = "Успешные ходы: " + _successCount + 
                             "\nНеуспешные : " + _wrongCount;
                _context.Add(resultGame);
                _context.SaveChanges();

                Close();
            }
        }

        private void StartGame_Click(object sender, EventArgs e)
        {
            timerLeft = 30;
            Timer.Text = timerLeft.ToString();

            StartGame.Enabled = false;
            tableLayoutPanel1.Enabled = true;

            timer1.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WordFindGame wordFindGame = new WordFindGame();
            wordFindGame.Show();
            this.Close();
        }
    }
}
