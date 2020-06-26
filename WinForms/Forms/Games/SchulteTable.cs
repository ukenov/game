using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WinForms.Context;
using WinForms.Forms.Account;
using WinForms.Models;

namespace WinForms.Forms.Games
{
    public partial class SchulteTable : Form
    {
        private readonly DefaultContext _context;
        private readonly DateTime _start = DateTime.Now;

        private int _successCount = 0;
        private int _wrongCount = 0;
        private int _nextNumber = 0;

        private int timerLeft;


        public SchulteTable()
        {
            InitializeComponent();
            _context = new DefaultContext();
            AssignNumbersToSquare();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timerLeft > 0)
            {
                timerLeft--;
                Time.Text = timerLeft.ToString();
            }

            if (timerLeft == 0)
            {
                timer1.Stop();

                MessageBox.Show(Time.Text = "Successful : " + _successCount +
                             "\nUnsuccessful : " + _wrongCount);
            }
        }
        void AssignNumbersToSquare()
        {
            List<int> labelList = new List<int>();

            int labelIndex = 0;

            Random rand = new Random();
            foreach (Button btn in panel1.Controls)
            {
                while (labelList.Contains(labelIndex))
                    labelIndex = rand.Next(25);

                btn.Text = labelIndex + "";
                labelList.Add(labelIndex);
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            var clickButton = (Control) sender;

            if (clickButton.Text == Convert.ToString(_nextNumber))
            {
                ++_nextNumber;

                ++_successCount;

                clickButton.Enabled = false;

                if (_nextNumber == 25)
                {
                    timer1.Stop();
                    MessageBox.Show("Вы выиграли!");
                    var currentUser = LoginForm.LoggedUser.Id;
                    var use = _context.Users.FirstOrDefault(c => c.Id == currentUser);
                    var resultGame = new Statistic { Created = _start, GameType = GameType.SchulteTable, User = use, };

                    _context.Add(resultGame);
                    _context.SaveChanges();

                    MessageBox.Show(Time.Text = "Успешные ходы : " + _successCount +
                                                "\nНеуспешные : " + _wrongCount);

                   

                    Close();
                }
            }
            else
            {
                ++_wrongCount;
            }
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            timerLeft = 30;
            Time.Text = timerLeft.ToString();

            StartGame.Enabled = false;
            panel1.Enabled = true;

            timer1.Start();
        }

        private void SchulteTable_Shown(object sender, EventArgs e)
        {
            _wrongCount = 0;
            _successCount = 0;
            _nextNumber = 0;

           AssignNumbersToSquare();
        }

        private void SchulteTable_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Stop();
        }
  
        private void NewGame_Click(object sender, EventArgs e)
        {
            SchulteTable newGame = new SchulteTable();
            newGame.Show();

            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
