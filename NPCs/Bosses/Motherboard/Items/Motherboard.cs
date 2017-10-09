using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.NPCs.Bosses.Motherboard.Items
{
	public class Motherboard : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 38;
			item.height = 38;
			item.maxStack = 20;

			item.rare = 9;
			item.useAnimation = 45;
			item.useTime = 45;
			item.useStyle = 4;
			item.UseSound = SoundID.Item44;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Motherboard");
			Tooltip.SetDefault("You shouldn't have this");
		}

		public override bool UseItem(Player player)
		{
			summonWallOfShadows(player);
			//NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("CogLord"));
			return true;
		}

		public void summonWallOfShadows(Player player)
		{
			Vector2 spawnPos;
			int dir;
			if (player.Center.X > Main.rightWorld / 2)
			{
				spawnPos = new Vector2(player.Center.X + Main.screenWidth / 2 + 25, player.Center.Y + 1050);
				dir = -1;
			}
			else
			{
				spawnPos = new Vector2(player.Center.X - Main.screenWidth / 2 - 25, player.Center.Y + 1050);
				dir = 1;
			}
			int newWall = NPC.NewNPC((int)spawnPos.X, (int)spawnPos.Y, mod.NPCType("WallOfShadow"), 0, dir, 0, 0, 0, player.whoAmI);
		}
	}
}
