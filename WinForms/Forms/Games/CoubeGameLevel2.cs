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
    public partial class CoubeGameLevel2 : Form
    {
        private readonly DefaultContext _context;
        private readonly DateTime _start = DateTime.Now;
        private readonly Random _random;
        private readonly List<string> _numbers;

        private int _successCount = 0;
        private int _wrongCounter = 0;
        private Label _firstClicked;
        private Label _secondClicked;
        public CoubeGameLevel2()
        {
            InitializeComponent();
            _context = new DefaultContext();
            _random = new Random();
            _numbers = new List<string>()
            {
                "0" ,"0" , "1" , "1" , "2" ,"2" , "3" , "3" ,
                "4" ,"4" , "5" , "5" , "6" ,"6" , "7" , "7" , 
                "8" , "8" , "9" , "9" , "10" , "10" , "11" , "11",
                "12" , "12" , "13" , "13" ,"14" ,"14"
            };

            AssignNumbersToSquare();
        }

        private void CoubeGameLevel2_Load(object sender, EventArgs e)
        {

        }

        private void label_Click(object sender, EventArgs e)
        {
            if (_firstClicked != null && _secondClicked != null)
            {
                return;
            }

            var clickedLabel = sender as Label;

            if (clickedLabel == null)
                return;

            if (clickedLabel.ForeColor == Color.Black)
                return;

            if (_firstClicked == null)
            {
                _firstClicked = clickedLabel;
                _firstClicked.ForeColor = Color.Black;
                return;
            }

            _secondClicked = clickedLabel;
            _secondClicked.ForeColor = Color.Black;

            CheckForWinner();

            if (_firstClicked.Text == _secondClicked.Text)
            {
                _firstClicked = null;
                _secondClicked = null;
                _successCount++;

            }
            else
            {
                timer1.Start();
                _wrongCounter++;

            }

        }
        private void CheckForWinner()
        {
            for (var i = 0; i < tableLayoutPanel1.Controls.Count; i++)
            {
                var label = tableLayoutPanel1.Controls[i] as Label;
                if (label != null && label.ForeColor == label.BackColor)
                    return;
            }
            var currentUser = LoginForm.LoggedUser.Id;

            var use = _context.Users.FirstOrDefault(c => c.Id == currentUser);
            var resultGame = new Statistic { Created = _start, GameType = GameType.CoubeGameLevel2, SuccessCount = _successCount, User = use, WrongCount = _wrongCounter };
            var finishText = $"Успешные завершений: {_successCount} :: Неправильные: {_wrongCounter}";

            _context.Add(resultGame);
            _context.SaveChanges();

            MessageBox.Show(finishText);

            Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            _firstClicked.ForeColor = _firstClicked.BackColor;
            _secondClicked.ForeColor = _secondClicked.BackColor;

            _firstClicked = null;
            _secondClicked = null;
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

                var randomNumber = _random.Next(0, _numbers.Count);
                label.Text = _numbers[randomNumber];

                _numbers.RemoveAt(randomNumber);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CoubeGame coubeGame = new CoubeGame();
            coubeGame.Show();
            this.Close();
        }
    }
}
