using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class FrostJavelin : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 12;
			item.width = 14;
			item.height = 84;
			item.noUseGraphic = true;
			item.thrown = true;
			item.useTime = 30;
			item.shoot = mod.ProjectileType("FrostJavelinPro");
			item.shootSpeed = 15f;
			item.useAnimation = 30;
			item.useStyle = 1;
			item.knockBack = 4;
			item.maxStack = 999;
			item.consumable = true;
			item.value = 10;
			item.rare = 1;
			item.UseSound = SoundID.Item5;
			item.autoReuse = false;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Frost Javelin");
			Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "FrostCore", 1);
			recipe.SetResult(this, 25);
			recipe.AddTile(16);
			recipe.AddRecipe();
		}
	}
}
