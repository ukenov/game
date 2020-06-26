using System;
using System.Linq;
using System.Windows.Forms;
using WinForms.Context;
using WinForms.Forms.Account;
using WinForms.Models;

namespace WinForms.Forms.Games
{
    public partial class NumberGame : Form
    {
        readonly DefaultContext _context = new DefaultContext();

        private int level = 0;
        private int delayTime = 3000;
        private int textLength = 3;
        private int _wrongCounter ;
        private string _randomText = "";
        private DateTime _start = DateTime.Now;

        public NumberGame()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            var currentUser = LoginForm.LoggedUser.Id;

            var use = _context.Users.FirstOrDefault(c => c.Id == currentUser);
            var resultGame = new Statistic { Created = _start, GameType = GameType.NumberGame, SuccessCount = level, User = use, WrongCount = _wrongCounter };

            var anotherDelayTime = delayTime - (level * 500);

            var timer = new Timer { Enabled = true, Interval = anotherDelayTime <= 2000 ? 2000 : anotherDelayTime };
            timer.Tick += (o, a) => { timer.Stop(); label1.Hide(); };

            var text = textBox1.Text;

            if (_start < DateTime.Now)
            {
                var finishText = $"Вы прошли уровень: {level} :: Неправильные: {_wrongCounter}";
                MessageBox.Show(finishText);
                label1.Text = finishText;
                button1.Enabled = false;
                textBox1.Enabled = false;
                label1.Show();
                timer.Enabled = false;
                _context.Add(resultGame);
                _context.SaveChanges();

                Close();
            }
            else if ((_randomText == text.ToUpper()))
            {
                ++textLength;
                ++level;
                _randomText = RandomString(textLength);
                label1.Text = _randomText;
                label1.Show();
            }
            else
            {
                _wrongCounter++;
                _randomText = RandomString(textLength);
                label1.Text = _randomText;
                label1.Show();
            }
        }
        public static string RandomString(int length)
        {
            Random random = new Random();
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private void NumberGame_Shown(object sender, EventArgs e)
        {
            var anotherDelayTime = delayTime - (level * 500);
            _start = DateTime.Now.AddSeconds(10);

            _randomText = RandomString(textLength);
            label1.Text = _randomText;

            var timer = new System.Windows.Forms.Timer { Enabled = true, Interval = anotherDelayTime <= 1500 ? 1500 : anotherDelayTime };
            timer.Tick += (o, a) => { timer.Stop(); label1.Hide(); };
        }

        private void NumberGame_Load(object sender, EventArgs e)
        {
        }
    }
}