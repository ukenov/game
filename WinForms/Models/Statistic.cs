using System;

namespace WinForms.Models
{
    public class Statistic
    {
        public int Id { get; set; }
        public User User { get; set; }
        public GameType GameType { get; set; }
        public DateTime Created { get; set; }
        public int SuccessCount { get; set; }
        public int WrongCount { get; set; }
    }
}