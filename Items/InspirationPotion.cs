using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{

	public class InspirationPotion : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 38;
			item.height = 32;
			item.maxStack = 20;

			item.rare = 3;
			item.useAnimation = 15;
			item.useTime = 15;
			item.useStyle = 2;
			item.UseSound = SoundID.Item3;
			item.consumable = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Inspiration Potion");
			Tooltip.SetDefault("Increases maximum mana");
		}


		public override bool UseItem(Player player)
		{
			player.AddBuff(mod.BuffType("MaximumCharge"), 14400);
			return true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.BottledWater, 1);
			recipe.AddIngredient(314, 1);
			recipe.AddIngredient(313, 1);
			recipe.AddIngredient(null, "ManaFruit", 6);
			recipe.AddTile(13);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
