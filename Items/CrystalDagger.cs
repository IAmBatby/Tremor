using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class CrystalDagger : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 35;
			item.thrown = true;
			item.width = 18;
			item.noUseGraphic = true;
			item.maxStack = 999;
			item.consumable = true;
			item.height = 38;
			item.useTime = 20;
			item.useAnimation = 20;
			item.shoot = mod.ProjectileType("CrystalDagger");
			item.shootSpeed = 16f;
			item.useStyle = 1;
			item.knockBack = 4;
			item.value = 60;
			item.rare = 4;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crystal Dagger");
			Tooltip.SetDefault("");
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.ThrowingKnife, 50);
			recipe.AddIngredient(ItemID.CrystalShard, 1);
			recipe.SetResult(this, 50);
			recipe.AddRecipe();
		}
	}
}
