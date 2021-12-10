using System;

namespace Final_Project.Models
{
    public class Game
    {
        public int GameID {get; set;}
        [Required]
        public int Title {get; set;}
        [Required]
        public DateTime ReleaseDate {get; set;}
        [Required]
        public string Genre {get; set;}
        [Required]
        public string Publisher {get; set;}
        [Required]

        public string Rating {get; set}
        [Required]
    }
}