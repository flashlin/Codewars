using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFun57_RunnersMeetings.Models
{
    public class Kata
    {
        public int RunnersMeetings(int[] startPositions, int[] speeds)
        {
            var players = new List<Player>();
            for (int i = 0; i < startPositions.Length; i++)
            {
                var player = new Player()
                {
                    StartPosition = startPositions[i],
                    Speed = speeds[i]
                };
                players.Add(player);
            }
            return Bump(players);
        }

        private int Bump(List<Player> players)
        {
            int bumpCount = 0;
            if (IsBump(players[0], players[1]))
            {
                bumpCount++;
            }

            if (players.Count <= 2)
            {
                if (bumpCount > 0) return 2;
                return -1;
            }

            if (IsBump(players[0], players[2]))
            {
                bumpCount++;
            }

            if (IsBump(players[1], players[2]))
            {
                bumpCount++;
            }

            if (bumpCount == 3)
            {
                return 3;
            }

            if (bumpCount > 0)
            {
                return 2;
            }

            return -1;
        }

        private void Bump(List<Player> players, int start)
        {
            if ((start + 1) < players.Count)
            {
                IsBump(players[start], players[start + 1]);
                Bump(players, start + 1);
            }
        }

        protected bool IsBump(Player p1, Player p2)
        {
            double speed = p1.Speed - p2.Speed;
            int distance = p2.StartPosition - p1.StartPosition;
            if (speed == 0 && distance != 0)
            {
                return false;
            }
            double time = (p2.StartPosition - p1.StartPosition) / speed;
            return (time > 0);
        }

        public class Player
        {
            public int StartPosition { get; set; }
            public int Speed { get; set; }

            public int GetDistance(int time)
            {
                return StartPosition + Speed * time;
            }
        }
    }
}
