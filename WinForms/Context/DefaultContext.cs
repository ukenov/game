using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using WinForms.Configs;
using WinForms.Models;

namespace WinForms.Context
{
    public sealed class DefaultContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Statistic> Statistics { get; set; }
        

        public DefaultContext()
        {
            if (Database.EnsureCreated() == false)
            {
            }
            else
            {
                error();

            }
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(AppConfig.ConnectionString);
        }

        public void error()
        {
            MessageBox.Show("Установите Sql express");
        }
    }
}