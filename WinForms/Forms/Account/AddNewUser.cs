using System;
using System.Linq;
using System.Windows.Forms;
using WinForms.Context;
using WinForms.Models;

namespace WinForms.Forms.Account
{
    public partial class AddNewUser : Form
    {
        private readonly DefaultContext _context;

        public AddNewUser()
        {
            InitializeComponent();
            _context = new DefaultContext();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var login = textBox1.Text.Trim();
            var password = textBox2.Text;
            var name = textBox3.Text;
            var surname = textBox4.Text;
            var patronymicName = textBox5.Text;
            var age = comboBox1.Text;
            var gender = comboBox2.Text;
            var language = comboBox3.Text;

            var newUserLogin = _context.Users.FirstOrDefault(c => c.Login == login);

            if (newUserLogin != null)
            {
                MessageBox.Show("Пользователь с таким именем уже существует");
                return;
            }

            var newUser = new User()
            {
                Login = login,
                Password = password,
                Name = name,
                Surname = surname,
                PatronymicName = patronymicName,
                Age = age,
                Gender = gender,
                Language = language,
            };

            _context.Add(newUser);
            _context.SaveChanges();

            MessageBox.Show("Вы успешно создали аккаунт");
            Close();
        }

        private void AddNewUser_Load(object sender, EventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
