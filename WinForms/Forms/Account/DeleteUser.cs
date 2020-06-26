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
using WinForms.Models;

namespace WinForms.Forms.Account
{
    public partial class DeleteUser : Form
    {
        readonly DefaultContext _context = new DefaultContext();
        public static User LoggedUser;

        public DeleteUser()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var currentLogin = textBox1.Text;
            LoggedUser = _context.Users.FirstOrDefault(c => c.Login == currentLogin);
            if (LoggedUser != null)
            {
                _context.Remove(LoggedUser);
                _context.SaveChanges();
                MessageBox.Show("Пользователь успешно удален");
                Close();
            }
            else
            {
                MessageBox.Show("Пользователь не найден");
            }
        }
    }
}
