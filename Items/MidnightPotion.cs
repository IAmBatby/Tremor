using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{

	public class MidnightPotion : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 38;
			item.height = 32;
			item.maxStack = 20;

			item.rare = 11;
			item.useAnimation = 15;
			item.useTime = 15;
			item.useStyle = 2;
			item.UseSound = SoundID.Item3;
			item.consumable = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Midnight Potion");
			Tooltip.SetDefault("Increases all stats during night time");
		}

		public override bool UseItem(Player player)
		{
			player.AddBuff(mod.BuffType("NightHunting"), 14400);
			return true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.BottledWater, 1);
			recipe.AddIngredient(null, "LapisLazuli", 1);
			recipe.AddIngredient(null, "AlienTongue", 1);
			recipe.AddIngredient(null, "PinkGelCube", 1);
			recipe.AddTile(null, "AlchemyStationTile");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
