using System;

namespace Padel
{
    public class Player
    {
        public string Name { set; get; }
        public Score Score { set; get; } = new Score(); //added new Score to fix null reference

        public Player(string name)
        {
            Name = name;
        }

        public void Point()
        {
            Score.Increase();
        }
    }
}
