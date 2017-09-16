using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class Squasher : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 88;
			item.melee = true;
			item.width = 56;
			item.height = 56;
			item.useTime = 36;
			item.useAnimation = 36;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 122000;
			item.rare = 3;
			item.UseSound = SoundID.Item1;

			item.hammer = 100;
			item.autoReuse = false;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Squasher");
			Tooltip.SetDefault("Strong enough to destroy Demon Altars");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Pwnhammer, 1);
			recipe.AddIngredient(null, "DarkBulb", 15);
			recipe.AddIngredient(ItemID.Bone, 100);
			recipe.SetResult(this, 1);
			recipe.AddTile(134);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "Doomhammer", 1);
			recipe.AddIngredient(null, "DarkBulb", 15);
			recipe.AddIngredient(ItemID.Bone, 100);
			recipe.SetResult(this, 1);
			recipe.AddTile(134);
			recipe.AddRecipe();
		}
	}
}
