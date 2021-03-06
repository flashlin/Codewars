﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarParkEscape
{
	public class Kata
	{
		Stack<MoveType> _step = new Stack<MoveType>();
		private int[,] _gone;
		readonly int Walked = 3;
		private readonly int Staircases = 1;
		private readonly int ParkingPlace = 2;

		public string[] escape(int[,] carpark)
		{
			_gone = (int[,])carpark.Clone();
			var startPos = FindCarStartPos(carpark);
			MoveCar(carpark, startPos, MoveType.None);

			var m = _step.ToArray().Reverse()
				.Where(x => x != MoveType.None)
				.GroupAdjacentBy((prev, curr) => prev == curr)
				.Select(g => GetString(g))
				.ToArray();


			return m;
		}

		string DisplayCarPark(int[,] carpark)
		{
			var sb = new StringBuilder();
			for (int y = 0; y < carpark.GetLength(0); y++)
			{
				for (int x = 0; x < carpark.GetLength(1); x++)
				{
					sb.AppendFormat("{0}", carpark[y,x]);
				}
				sb.AppendLine();
			}
			return sb.ToString();
		}

		private string GetString(IEnumerable<MoveType> g)
		{
			return GetDirectionString(g.First()) + g.Count().ToString();
		}

		string GetDirectionString(MoveType moveType)
		{
			switch (moveType)
			{
				case MoveType.Left:
					return "L";
				case MoveType.Right:
					return "R";
				case MoveType.Down:
					return "D";
			}
			return "";
		}

		private bool MoveCar(int[,] carpark, CarPos pos, MoveType moveType)
		{
			_step.Push(moveType);

			_gone[pos.Y, pos.X] = Walked;

			if (IsEndFloor(carpark, pos))
			{
				int steps = carpark.GetLength(1) - pos.X - 1;
				for (int i = 0; i < steps; i++)
				{
					_step.Push(MoveType.Right);
				}
				return true;
			}

			if (TryDown(carpark, pos))
			{
				return true;
			}

			if (TryRight(carpark, new CarPos(pos.X + 1, pos.Y)))
			{
				return true;
			}

			if (TryLeft(carpark, new CarPos(pos.X - 1, pos.Y)))
			{
				return true;
			}

			_step.Pop();
			return false;
		}

		private bool TryLeft(int[,] carpark, CarPos nextPos)
		{
			return CanMove(carpark, nextPos) && MoveCar(carpark, nextPos, MoveType.Left);
		}

		private bool TryRight(int[,] carpark, CarPos nextPos)
		{
			return CanMove(carpark, nextPos) && MoveCar(carpark, nextPos, MoveType.Right);
		}

		private bool TryDown(int[,] carpark, CarPos pos)
		{
			var nextPos = new CarPos(pos.X, pos.Y + 1);
			return CanDown(carpark, pos) && MoveCar(carpark, nextPos, MoveType.Down);
		}

		bool IsEndFloor(int[,] carpark, CarPos pos)
		{
			for (int x = 0; x < carpark.GetLength(1); x++)
			{
				if (carpark[pos.Y, x] != 0)
				{
					return false;
				}
			}
			return true;
		}

		bool IsInCarparkRange(int[,] carpark, CarPos pos)
		{
			if (pos.X < 0) return false;
			if (pos.X >= carpark.GetLength(1)) return false;
			if (pos.Y < 0) return false;
			if (pos.Y >= carpark.GetLength(0)) return false;
			return true;
		}

		bool CanDown(int[,] carpark, CarPos pos)
		{
			if (!IsInCarparkRange(carpark, pos))
			{
				return false;
			}
			return GetItem(carpark, pos) == Staircases;
		}

		bool CanMove(int[,] carpark, CarPos pos)
		{
			if(!IsInCarparkRange(carpark, pos))
			{
				return false;
			}
			if (carpark[pos.Y, pos.X] == Staircases) return true;
			if (_gone[pos.Y, pos.X] == Walked) return false;
			return GetItem(carpark, pos) == 0;
		}

		private CarPos FindCarStartPos(int[,] carpark)
		{
			var startPos = new CarPos(0, 0);
			for (int y = 0; y < carpark.GetLength(0); y++)
			{
				for (int x = 0; x < carpark.GetLength(1); x++)
				{
					if (carpark[y, x] == ParkingPlace)
					{
						startPos.X = x;
						startPos.Y = y;
						return startPos;
					}
				}
			}
			return startPos;
		}

		int GetItem(int[,] carpark, CarPos pos)
		{
			return carpark[pos.Y, pos.X];
		}

		public enum MoveType
		{
			None,
			Left,
			Right,
			Down
		}

		public class CarPos
		{
			public CarPos(int x, int y)
			{
				X = x;
				Y = y;
			}

			public int X { get; set; }
			public int Y { get; set; }
			public override string ToString()
			{
				return $"{X},{Y}";
			}
		}
	}

	public static class LinqExtensions
	{
		public static IEnumerable<IEnumerable<T>> GroupAdjacentBy<T>(
			this IEnumerable<T> source, Func<T, T, bool> predicate)
		{
			using (var e = source.GetEnumerator())
			{
				if (e.MoveNext())
				{
					var list = new List<T> { e.Current };
					var pred = e.Current;
					while (e.MoveNext())
					{
						if (predicate(pred, e.Current))
						{
							list.Add(e.Current);
						}
						else
						{
							yield return list;
							list = new List<T> { e.Current };
						}
						pred = e.Current;
					}
					yield return list;
				}
			}
		}
	}
}
