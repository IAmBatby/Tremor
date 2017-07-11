using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{

	public class DeadlyTreats : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 20;
			item.height = 30;
			item.maxStack = 20;
			item.rare = 2;
			item.useAnimation = 15;
			item.useTime = 15;
			item.useStyle = 2;
			item.UseSound = SoundID.Item3;
			item.consumable = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Deadly Treats");
			Tooltip.SetDefault("Increases life regeneration\nLowers visibilty");
		}


		public override bool UseItem(Player player)
		{
			player.AddBuff(22, 10000, true);
			player.AddBuff(2, 14400, true);
			player.AddBuff(6, 14400, true);
			return true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Bowl, 1);
			recipe.AddIngredient(null, "SpiderMeat", 1);
			recipe.AddIngredient(ItemID.VileMushroom, 2);
			recipe.SetResult(this);
			recipe.AddTile(96);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Bowl, 1);
			recipe.AddIngredient(null, "SpiderMeat", 1);
			recipe.AddIngredient(ItemID.ViciousMushroom, 2);
			recipe.SetResult(this);
			recipe.AddTile(96);
			recipe.AddRecipe();
		}
	}
}
