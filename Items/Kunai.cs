using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class Kunai : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 14;
			item.height = 32;
			item.thrown = true;
			item.width = 18;
			item.noUseGraphic = true;
			item.maxStack = 999;
			item.consumable = true;
			item.useTime = 19;
			item.useAnimation = 19;
			item.shoot = mod.ProjectileType("Kunai");
			item.shootSpeed = 15f;
			item.useStyle = 1;
			item.knockBack = 4;
			item.value = 60;
			item.rare = 1;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Kunai");
			Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Wood, 3);
			recipe.AddIngredient(ItemID.IronBar, 4);
			recipe.SetResult(this, 50);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Wood, 3);
			recipe.AddIngredient(ItemID.LeadBar, 4);
			recipe.SetResult(this, 50);
			recipe.AddRecipe();
		}
	}
}
