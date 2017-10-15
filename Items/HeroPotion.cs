using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{

	public class HeroPotion : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 38;
			item.height = 32;
			item.maxStack = 20;
			item.rare = 0;
			item.useAnimation = 15;
			item.useTime = 15;
			item.useStyle = 2;
			item.UseSound = SoundID.Item3;
			item.consumable = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hero Potion");
			Tooltip.SetDefault("Grants 10000 defense\n" +
"Grants immunity to all debuffs\n" +
"Increases movement speed\n" +
"Makes you priority target for enemies\n" +
"'Feel like a real hero! At least for 15 seconds.'");
		}

		public override bool UseItem(Player player)
		{
			player.AddBuff(mod.BuffType("HeroBuff"), 900);
			return true;
		}

		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			tooltips[0].overrideColor = new Color(238, 194, 73);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.BottledWater, 1);
			recipe.AddIngredient(null, "MultidimensionalFragment", 10);
			recipe.AddIngredient(null, "NightmareOre", 25);
			recipe.AddIngredient(ItemID.RegenerationPotion, 5);
			recipe.AddIngredient(ItemID.IronskinPotion, 5);
			recipe.AddIngredient(ItemID.SwiftnessPotion, 5);
			recipe.AddIngredient(ItemID.ObsidianSkinPotion, 5);
			recipe.AddIngredient(3456, 5);
			recipe.AddIngredient(3457, 5);
			recipe.AddIngredient(3458, 5);
			recipe.AddIngredient(3459, 5);
			recipe.AddIngredient(null, "TrueEssense", 1);
			recipe.AddTile(null, "AlchemyStationTile");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
