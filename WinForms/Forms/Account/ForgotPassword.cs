using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WinForms.Context;
using WinForms.Models;

namespace WinForms.Forms.Account
{
    public partial class ForgotPassword : Form
    {
        readonly DefaultContext _context = new DefaultContext();
        public static User LoggedUser;

        public ForgotPassword()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var currentPassword = textBox1.Text;
            LoggedUser = _context.Users.FirstOrDefault(c => c.Password == currentPassword);
            if (LoggedUser != null)
            {
                var newPassword = textBox2.Text;
                LoggedUser.Password = newPassword;
                _context.Update(LoggedUser);
                _context.SaveChanges();
                Close();
            }
            else
            {
                MessageBox.Show("введите старый пароль правильно");
            }
        }
        private void ForgotPass_Load(object sender, EventArgs e)
        {
            label1.BackColor = Color.FromArgb(34, 36, 49);
            label2.BackColor = Color.FromArgb(34, 36, 49);
            BackColor = Color.FromArgb(34, 36, 49);
        }
    }
}
