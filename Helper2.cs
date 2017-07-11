using Terraria;
using System;
using Microsoft.Xna.Framework;

namespace Tremor
{
	public static class Helper2
	{
		public static int GetNearestPlayer(Terraria.NPC npc)
		{
			float NearestPlayerDist = 4815162342f;
			int NearestPlayer = -1;
			foreach (Player player in Main.player)
			{
				if (player.Distance(npc.Center) < NearestPlayerDist)
				{
					NearestPlayerDist = player.Distance(npc.Center);
					NearestPlayer = player.whoAmI;
				}
			}
			return NearestPlayer;
		}

		public static int GetNearestAlivePlayer(Terraria.NPC npc)
		{
			float NearestPlayerDist = 4815162342f;
			int NearestPlayer = -1;
			foreach (Player player in Main.player)
			{
				if (player.Distance(npc.Center) < NearestPlayerDist && player.active)
				{
					NearestPlayerDist = player.Distance(npc.Center);
					NearestPlayer = player.whoAmI;
				}
			}
			return NearestPlayer;
		}

		public static Vector2 VelocityFPTP(Vector2 pos1, Vector2 pos2, float speed)
		{
			Vector2 move = pos2 - pos1;
			return move * (speed / (float)Math.Sqrt(move.X * move.X + move.Y * move.Y));
		}

		public static Vector2 RandomPositin(Vector2 pos1, Vector2 pos2)
		{
			Random rnd = new Random();
			return new Vector2(rnd.Next((int)pos1.X, (int)pos2.X) + 1, rnd.Next((int)pos1.Y, (int)pos2.Y) + 1);
		}

		public static float rotateBetween2Points(Vector2 point1, Vector2 point2)
		{
			float rotation = (float)Math.Atan2(point1.Y - (point2.Y), point1.X - (point2.X));
			return rotation;
		}
	}
}