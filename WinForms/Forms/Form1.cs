using System;
using System.Buffers.Text;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using WinForms.Context;
using WinForms.Forms.Account;
using WinForms.Models;

namespace WinForms.Forms
{
    public partial class Form1 : Form
    {
        private readonly DefaultContext _context;
        private readonly ForgotPassword _forgotPassword;
        private readonly DeleteUser _deleteUser;

        public static Day Day1;
        public static Day Day2;
        public static Day Day3;
        public static Day Day4;
        public static Day Day5;
        public static Day Day6;
        public static Day Day7;
        public static Day Day8;
        public static Day Day9;
        public static Day Day10;

        public Form1()
        {
            InitializeComponent();
            timerTime.Start();

            _context = new DefaultContext();
            _forgotPassword = new ForgotPassword();
            _deleteUser = new DeleteUser();
            LoadData();

            Day1 = new Day();
            Day2 = new Day();
            Day3 = new Day();
            Day4 = new Day();
            Day5 = new Day();
            Day6 = new Day();
            Day7 = new Day();
            Day8 = new Day();
            Day9 = new Day();
            Day10 = new Day();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource =
                _context.Statistics.Where(c => c.User.Id == LoginForm.LoggedUser.Id).ToList();
            //////////////////////

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

            var userList = _context.Users.GroupBy(c => c.Name).ToList();

            foreach (var list in userList)
            {
                comboBoxUserName.Items.Add(list.Key);
            }

            foreach (GameType game in Enum.GetValues(typeof(GameType)))
            {
                comboBoxTask.Items.Add(game);
            }
        }
        public void LoadData()
        {
            comboBox2.Items.AddRange(new[] 
            {
                "List of All Students",
                "List of Boys",
                "List of Girls",
                "List of Age",
                "Kazakh group",
                "Russian group",
            });
        }
        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e )
        {
           
            var list = comboBox2.Text;
            switch (list)
            {
                case "List of All Students":
                    dataGridView1.DataSource = _context.Users.OrderBy(c => c.Name).ToList();
                    break;
                case "List of Boys":
                    dataGridView1.DataSource = _context.Users.Where(c => c.Gender == "М").ToList();
                    break;
                case "List of Girls":
                    dataGridView1.DataSource = _context.Users.Where(c => c.Gender == "Ж").ToList();
                    break;
                case "List of Age":
                    dataGridView1.DataSource = _context.Users.OrderBy(c => c.Age.ToUpper()).ToList();
                    break;
                case "Kazakh group":
                    dataGridView1.DataSource = _context.Users.Where(c => c.Language == "Kaz").ToList();
                    break;
                case "Russian group":
                    dataGridView1.DataSource = _context.Users.Where(c => c.Language == "Rus").ToList();
                    break;
            }
        }
        private void button11_Click(object sender, EventArgs e)
        {
            chart2.Series["Name"].Points.Clear();
            var currentGame = comboBoxTask.SelectedItem.ToString();
            
            var currentGameAndSuccessList = _context.Statistics.OrderBy(c => c.SuccessCount == currentGame.Length).ToList();

            foreach (var successlist in currentGameAndSuccessList)
            {
                chart2.Series["Name"].Points.AddXY(currentGame, successlist.SuccessCount);
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var language = comboBox1.Text;

            switch (language)
            {
                case "English":
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-EN");
                    break;
                case "Russian":
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("ru-RU");
                    break;
                case "Kazakh":
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("ru-KZ");
                    break;
            }
            Hide();

            var form1 = new Form1();
            form1.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            _forgotPassword.ShowDialog();
        }
        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
        private void chart2_Click(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Enabled == true)
            {
                button1.Enabled = false;
                Day1.ShowDialog();
                button2.Enabled = true;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Enabled == true)
            {
                button2.Enabled = false;
                Day2.ShowDialog();
                button3.Enabled = true;
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.Enabled == true)
            {
                button3.Enabled = false;
                Day3.ShowDialog();
                button4.Enabled = true;
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.Enabled == true)
            {
                button4.Enabled = false;
                Day4.ShowDialog();
                button5.Enabled = true;
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (button5.Enabled == true)
            {
                button5.Enabled = false;
                Day5.ShowDialog();
                button6.Enabled = true;
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            if (button6.Enabled == true)
            {
                button6.Enabled = false;
                Day6.ShowDialog();
                button7.Enabled = true;
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            if (button7.Enabled == true)
            {
                button7.Enabled = false;
                Day7.ShowDialog();
                button8.Enabled = true;
            }
        }
        private void button8_Click(object sender, EventArgs e)
        {
            if (button8.Enabled == true)
            {
                button8.Enabled = false;
                Day8.ShowDialog();
                button9.Enabled = true;
            }
        }
        private void button9_Click(object sender, EventArgs e)
        {
            if (button9.Enabled == true)
            {
                button9.Enabled = false;
                Day9.ShowDialog();
                button12.Enabled = true;
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (button12.Enabled == true)
            {
                button12.Enabled = false;
                Day10.ShowDialog();
                MessageBox.Show("Поздравляю вы прошли все дни развития!");
            }
        }
        private void labelAge_Click(object sender, EventArgs e)
        {

        }
        private void Timer(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            labelTimer.Text = dt.ToString("HH:MM:ss");
        }
        private void labelTimer_Click(object sender, EventArgs e)
        {

        }
        private void tabPage3_Click(object sender, EventArgs e)
        {

        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void buttonPrint_Click(object sender, EventArgs e)
        {
            printDocument1.Print(); //Начинаем процесс печати
        }
        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Bitmap bmp = new Bitmap(chart2.Size.Width + 716, chart2.Size.Height + 317);
            chart2.DrawToBitmap(bmp, chart2.Bounds);
            e.Graphics.DrawImage(bmp, 0, 0);
        }
        private void printDocument2_PrintPage(object sender, PrintPageEventArgs e)
        {
            Bitmap bmp = new Bitmap(dataGridView1.Size.Width + 716, dataGridView1.Size.Height + 317);
            dataGridView1.DrawToBitmap(bmp, dataGridView1.Bounds);
            e.Graphics.DrawImage(bmp, 0, 0);
        }
        private void button13_Click(object sender, EventArgs e)
        {
            printDocument2.Print(); //Начинаем процесс печати

        }
        private void statisticsBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
        private void button14_Click(object sender, EventArgs e)
        {
            _deleteUser.ShowDialog();
        }
    }
}
