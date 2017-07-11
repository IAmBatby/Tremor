using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{

	public class SavingPotion : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 38;
			item.height = 32;
			item.maxStack = 20;

			item.rare = 10;
			item.useAnimation = 15;
			item.useTime = 15;
			item.useStyle = 2;
			item.UseSound = SoundID.Item3;
			item.consumable = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Saving Potion");
			Tooltip.SetDefault("Greatly reduces mana cost");
		}


		public override bool UseItem(Player player)
		{
			player.AddBuff(mod.BuffType("ManaSaving"), 14400);
			return true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.BottledWater, 1);
			recipe.AddIngredient(314, 2);
			recipe.AddIngredient(null, "ClusterShard", 1);
			recipe.AddIngredient(null, "ManaFruit", 5);
			recipe.AddTile(null, "AlchemyStationTile");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
