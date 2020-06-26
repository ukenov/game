using System.Collections.Generic;
using System.Linq;

namespace WinForms.Models
{
    public enum GameType
    {
        NumberGame = 0,
        StringGame = 1,

        WordFindGame = 2,
        NumberFindGame = 3,

        FindEvenAndOddNumbers = 4,

        MathTImeGame = 5,
        MathTImeGameLevel2 = 6,
        MathTImeGameLevel3 = 7,

        CoubeGame = 8,
        CoubeGameLevel2 = 9 ,
        
        SchulteTable = 10,
        SchulteTableLevel2 = 11,
        SchulteTableLevel3 = 12,
       
    }

    public class GameTypeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public static class Games
    {
        private static readonly List<GameTypeModel> GameTypesList = new List<GameTypeModel>()
        {
            new GameTypeModel { Id = 0, Name = "Введи числа" },
            new GameTypeModel { Id = 1, Name = "Введи буквы" },

            new GameTypeModel { Id = 2, Name = "Найди буквы" },
            new GameTypeModel { Id = 3, Name = "Найди числа" },

            new GameTypeModel { Id = 4, Name = "Четные и не четные числа" },

            new GameTypeModel { Id = 5, Name = "Математика на время" },
            new GameTypeModel { Id = 6, Name = "Математика на время уровень-2" },
            new GameTypeModel { Id = 7, Name = "Математика на время уровень-3" },

            new GameTypeModel { Id = 8, Name = "Куб гейм" },
            new GameTypeModel { Id = 9, Name = "Куб гейм" },

            new GameTypeModel { Id = 10, Name = "Таблица шульта" },
            new GameTypeModel { Id = 11, Name = "Таблица шульта уровень-2" },
            new GameTypeModel { Id = 12, Name = "Таблица шульта уровень-3" },
          
        };

        public static string GetNameById(GameType gameType)
        {
            var gameName = GameTypesList
                .FirstOrDefault(_ => _.Id == (int)gameType)?.Name;

            return gameName;
        }
    }
}