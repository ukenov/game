using System;
using System.Linq;
using System.Windows.Forms;
using WinForms.Context;
using WinForms.Forms.Account;
using WinForms.Models;

namespace WinForms.Forms.Games
{
    public partial class StringGame : Form
    {
        readonly DefaultContext _context = new DefaultContext();
        private int level = 0;
        private int delayTime = 300;
        private int textLength = 3;
        private int wrongCounter = 0;
        private string randomText = "";
        private DateTime start = DateTime.Now;

        public StringGame()
        {
            InitializeComponent();
            
        }
        private void StringGame_Load(object sender, EventArgs e)
        {
        }
        public  void button1_Click(object sender, EventArgs e)
        {
            var anotherDelayTime = delayTime - (level * 500);
            
            var timer = new System.Windows.Forms.Timer { Enabled = true, Interval = anotherDelayTime <= 2000 ? 2000 : anotherDelayTime };
            timer.Tick += (o, a) => { timer.Stop(); label1.Hide(); };

            string text = textBox1.Text;
            var currentUser = LoginForm.LoggedUser.Id;
            var use = _context.Users.FirstOrDefault(c => c.Id == currentUser);
            var resultGame = new Statistic { Created = start, GameType = GameType.StringGame, SuccessCount = level, User = use, WrongCount = wrongCounter };

            if (start < DateTime.Now)
            {
                var finishText = $"Вы прошли уровень!: {level} :: Неправильне : {wrongCounter}";
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
            else if ((randomText == text.ToUpper()))
            {
                ++textLength;
                ++level;
                randomText = RandomString(textLength);
                label1.Text = randomText;
                textBox1.Text = randomText;
                label1.Show();
            }
            else
            {
                wrongCounter++;
                randomText = RandomString(textLength);
                label1.Text = randomText;
                textBox1.Text = randomText;
                label1.Show();
            }
        }
        public static string RandomString(int length)
        {
            Random random = new Random();
            const string chars = "qwertyuiopasdfghjklzxcvbnm";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private void StringGame_Shown(object sender, EventArgs e)
        {
            var anotherDelayTime = delayTime - (level * 500);
            start = DateTime.Now.AddSeconds(30);

            randomText = RandomString(textLength);
            label1.Text = randomText;

            var timer = new System.Windows.Forms.Timer { Enabled = true, Interval = anotherDelayTime <= 1500 ? 1500 : anotherDelayTime };
            timer.Tick += (o, a) => { timer.Stop(); label1.Hide(); };
        }
    }
}
