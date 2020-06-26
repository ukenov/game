using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WinForms.Context;
using WinForms.Models;

namespace WinForms.Forms.Account
{
    public partial class LoginForm : Form
    {
        readonly DefaultContext _context = new DefaultContext();
        public static User LoggedUser;
        public LoginForm()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var currentLogin = textBox1.Text;
            var currentPassword = textBox2.Text;
            var currentAge = comboBox1.Text;

            LoggedUser =
                _context.Users.FirstOrDefault(c => c.Login == currentLogin && c.Password == currentPassword && c.Age == currentAge);


            if (LoggedUser == null)
            {
                var errorText = $"Error";
                MessageBox.Show(errorText);
            }
            else
            {
                Hide();
                Form1 form1 = new Form1();
                form1.ShowDialog();
                Close();
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            label1.BackColor = Color.FromArgb(34, 36, 49);
            label2.BackColor = Color.FromArgb(34, 36, 49);
            label3.BackColor = Color.FromArgb(34, 36, 49);
            label4.BackColor = Color.FromArgb(34, 36, 49);
            BackColor = Color.FromArgb(34, 36, 49);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            var currentLogin = textBox1.Text;
            var searchUser = _context.Users.FirstOrDefault(c => c.Login == currentLogin);
            if (searchUser != null)
            {
                ForgotPassword forgotPassword = new ForgotPassword();
                forgotPassword.ShowDialog();
            }
            else
            {
                MessageBox.Show("Пользователь с таким именем не найден");
            }
        }
        private void label4_Click(object sender, EventArgs e)
        {
            AddNewUser add = new AddNewUser();
            add.ShowDialog();
        }
    }
}