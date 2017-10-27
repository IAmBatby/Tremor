using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class InfernoSkull : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 26;
			item.height = 28;
			item.maxStack = 20;
			item.value = 100;
			item.rare = 0;
			item.useAnimation = 15;
			item.useTime = 15;
			item.useStyle = 4;
			item.consumable = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Inferno Skull");
			Tooltip.SetDefault("Summons the Andas\n" +
"Requires the hell biome and The Trinity to have been downed");
		}

		public override bool CanUseItem(Player player)
		{
			return player.position.Y / 16f > Main.maxTilesY - 200 && TremorWorld.Boss.Trinity.IsDowned() && !NPC.AnyNPCs(mod.NPCType("Andas"));
		}

		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			tooltips[0].overrideColor = new Color(238, 194, 73);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "AngeliteBar", 10);
			recipe.AddIngredient(null, "CollapsiumBar", 10);
			recipe.AddIngredient(null, "FireFragment", 12);
			recipe.AddIngredient(ItemID.HellstoneBar, 6);
			recipe.AddIngredient(ItemID.Bone, 25);
			recipe.AddIngredient(ItemID.SoulofNight, 8);
			recipe.SetResult(this);
			recipe.AddTile(null, "StarvilTile");
			recipe.AddRecipe();
		}

		public override bool UseItem(Player player)
		{
			NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("Andas"));
			Main.PlaySound(SoundID.Roar, player.position, 0);
			return true;
		}
	}
}
