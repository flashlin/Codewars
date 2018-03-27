﻿using System;
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
            List<Player> players = CreatePlayerList(startPositions, speeds);

            var meetings = new Dictionary<Meeting, List<Player>>();
            for (int i = 0; i < players.Count-1; i++)
            {
                var front = players[i];
                for (int j = i + 1; j < players.Count; j++)
                {
                    var back = players[j];
                    if (CanBump(front, back))
                    {
                        AddToMeeting(meetings, front, back);
                    }
                }
            }
            if (meetings.Count > 0)
            {
                return meetings.Values.Max(x => x.Count);
            }
            return -1;
        }

        private void AddToMeeting(Dictionary<Meeting, List<Player>> meetings, Player front, Player back)
        {
            var meeting = new Meeting(front, back);
            if (!meetings.ContainsKey(meeting))
            {
                meetings[meeting] = new List<Player>();
            }
            if (!meetings[meeting].Contains(front))
                meetings[meeting].Add(front);
            if (!meetings[meeting].Contains(back))
                meetings[meeting].Add(back);
        }

        private static List<Player> CreatePlayerList(int[] startPositions, int[] speeds)
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

            players = players.OrderByDescending(x => x.StartPosition).ToList();

            return players;
        }

        protected bool CanBump(Player front, Player back)
        {
            return front.Speed < back.Speed;
        }

        public struct Meeting
        {
            public Meeting(Player front, Player back)
            {
                Time = (front.StartPosition - back.StartPosition) / (back.Speed - front.Speed);
                Position = front.StartPosition + front.Speed * Time;
            }

            public double Position { get; }

            public double Time { get; }

            public override string ToString()
            {
                return $"{Time} {Position}";
            }
        }

        public class Player
        {
            public int StartPosition { get; set; }
            public int Speed { get; set; }

            public override string ToString()
            {
                return $"{StartPosition} {Speed}";
            }
        }
    }
}
