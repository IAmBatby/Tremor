using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class StormJelly : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 28;
			item.height = 32;
			item.maxStack = 20;
			item.useTurn = true;
			item.autoReuse = false;
			item.useAnimation = 18;
			item.useTime = 18;
			item.useStyle = 1;
			item.consumable = true;
			item.value = 150;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Storm Jelly");
			Tooltip.SetDefault("Summons Storm Jellyfish");
		}


		public override bool CanUseItem(Player player)
		{
			return NPC.downedBoss1 && !NPC.AnyNPCs(mod.NPCType("StormJellyfish"));
		}

		public override bool UseItem(Player player)
		{
			NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("StormJellyfish"));
			Main.PlaySound(SoundID.Roar, player.position, 0);
			return true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Gel, 25);
			recipe.AddIngredient(null, "SeaFragment", 12);
			recipe.AddIngredient(ItemID.Glowstick, 15);
			recipe.AddIngredient(ItemID.Seashell, 3);
			recipe.AddTile(16);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
