using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class ShadowRelic : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 14;
			item.height = 26;
			item.rare = 7;
			item.value = 50000;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shadow Relic");
			Tooltip.SetDefault("'Can be used in ritual of shadows if thrown into lava in underground and the Dryad is alive...'\nSummons Wall of Shadows");
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SoulofNight, 16);
			recipe.AddIngredient(null, "PhantomSoul", 5);
			recipe.AddIngredient(null, "SteelBar", 12);
			recipe.AddIngredient(ItemID.Amethyst, 7);
			recipe.AddIngredient(ItemID.ChlorophyteBar, 15);
			recipe.AddTile(26);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override void PostUpdate()
		{
			if (item.lavaWet)
			{
				//if (Main.netMode != 1)
				//{
				for (int i = 0; i < 200; ++i)
				{
					if (Main.npc[i].type == NPCID.Dryad && NPC.downedPlantBoss)
					{
						SpawnShadowWall(item.position);
						Main.npc[i].StrikeNPCNoInteraction(9999, 10f, -Main.npc[i].direction, false, false, false);
						item.active = false;
						item.type = 0;
						//item.name = ""; 
						item.stack = 0;
						Main.NewText("The shadows are gathering around you...", 42, 10, 74);
					}
				}
				//}
			}
		}

		public void SpawnShadowWall(Vector2 pos)
		{
			if (pos.Y / 16.0 < (Main.maxTilesY - 205) || Main.wof >= 0 || Main.netMode == 1)
				return;
			int num1 = (int)Player.FindClosest(pos, 16, 16);
			int num2 = 1;
			if (pos.X / 16.0 > (Main.maxTilesX / 2))
				num2 = -1;
			bool flag = false;
			int X = (int)pos.X;
			while (!flag)
			{
				flag = true;
				for (int index = 0; index < 255; ++index)
				{
					if (Main.player[index].active && Main.player[index].position.X > (X - 1200) && Main.player[index].position.X < (X + 1200))
					{
						X -= num2 * 16;
						flag = false;
					}
				}
				if (X / 16 < 20 || X / 16 > Main.maxTilesX - 20)
					flag = true;
			}
			int num3 = (int)pos.Y;
			int i = X / 16;
			int num4 = num3 / 16;
			int num5 = 0;
			try
			{
				for (; WorldGen.SolidTile(i, num4 - num5) || (int)Main.tile[i, num4 - num5].liquid >= 100; ++num5)
				{
					if (!WorldGen.SolidTile(i, num4 + num5) && (int)Main.tile[i, num4 + num5].liquid < 100)
					{
						num4 += num5;
						goto label_21;
					}
				}
				num4 -= num5;
			}
			catch
			{
			}
			label_21:
			int Y = num4 * 16;
			NPC.SpawnOnPlayer(Main.myPlayer, mod.NPCType("WallOfShadow"));
		}


	}
}
