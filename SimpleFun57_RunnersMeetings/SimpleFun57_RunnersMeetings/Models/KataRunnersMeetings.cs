using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFun57_RunnersMeetings.Models
{
    public class KataRunnersMeetings
    {
        public int RunnersMeetings(int[] startPositions, int[] speeds)
        {
            var players = new List<Player>();
            for (int i=0; i<startPositions.Length; i++)
            {
                var player = new Player()
                {
                    StartPosition = startPositions[i],
                    Speed = speeds[i]
                };
                players.Add(player);
            }

            int time = 1;
            int a1 = players[0].GetDistance(time);
            int b1 = players[1].GetDistance(time);
            int c1 = players[2].GetDistance(time);

            int ab1 = Math.Abs(a1 - b1);
            int ac1 = Math.Abs(a1 - c1);
            int bc1 = Math.Abs(b1 - c1);

            time = 2;
            int a2 = players[0].GetDistance(time);
            int b2 = players[1].GetDistance(time);
            int c2 = players[2].GetDistance(time);

            int ab2 = Math.Abs(a2 - b2);
            int ac2 = Math.Abs(a2 - c2);
            int bc2 = Math.Abs(b2 - c2);

            if (ab2 < ab1 && ac2 >= ac1)
            {
                return 2;
            }

            return -1;
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
