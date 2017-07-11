using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{

	public class BloodmoonPotion : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 38;
			item.height = 32;
			item.maxStack = 20;

			item.rare = 6;
			item.useAnimation = 15;
			item.useTime = 15;
			item.useStyle = 2;
			item.UseSound = SoundID.Item3;
			item.consumable = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bloodmoon Potion");
			Tooltip.SetDefault("Summons Blood Moon");
		}


		public override bool CanUseItem(Player player)
		{
			if (!Main.dayTime && !Main.bloodMoon)
				return true;
			return false;
		}

		public override bool UseItem(Player player)
		{
			Main.bloodMoon = true;
			return true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Bottle, 1);
			recipe.AddIngredient(520, 1);
			recipe.AddIngredient(521, 1);
			recipe.AddIngredient(null, "SkullTeeth", 1);
			recipe.AddTile(13);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
