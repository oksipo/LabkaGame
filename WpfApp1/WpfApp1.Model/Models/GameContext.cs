using System;

namespace WpfApp1.Model.Models
{
    public class GameContext
    {
        public int Religion { get; set; } = 500;

        public int Money { get; set; } = 500;

        public int Army { get; set; } = 500;

        public int People { get; set; } = 500;

        public int Years { get; set; } = 0;

        public GameContext()
        {
            Random rand = new Random();
            Religion += rand.Next(-100, 101);
            Money += rand.Next(-100, 101);
            Army += rand.Next(-100, 101);
            People += rand.Next(-100, 101);
        }
    }
}
