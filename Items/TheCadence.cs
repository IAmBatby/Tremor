using Terraria.ID;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class TheCadence : ModItem
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Cadence");
			Tooltip.SetDefault("Flasks attack your enemies with souls");
		}
		public override void SetDefaults()
		{
			item.width = 30;
			item.height = 26;
			item.value = 1000000;
			item.rare = 11;
			item.accessory = true;
			item.defense = 7;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.AddBuff(mod.BuffType("TheCadenceBuff"), 2);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "DragonCapsule", 10);
			recipe.AddIngredient(null, "EarthFragment", 8);
			recipe.AddIngredient(ItemID.Sapphire, 6);
			recipe.SetResult(this);
			recipe.AddTile(412);
			recipe.AddRecipe();
		}
	}
}