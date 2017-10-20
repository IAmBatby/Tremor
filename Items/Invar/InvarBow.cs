using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items.Invar
{
	public class InvarBow : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 9;
			item.width = 16;
			item.height = 32;
			item.useTime = 30;
			item.ranged = true;
			item.shoot = 1;
			item.shootSpeed = 12f;
			item.useAnimation = 28;
			item.useStyle = 5;
			item.useTime = 28;
			item.knockBack = 5;
			item.value = 250;
			item.useAmmo = AmmoID.Arrow;
			item.rare = 1;
			item.UseSound = SoundID.Item5;
			item.autoReuse = false;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Invar Bow");
			Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "InvarBar", 7);
			recipe.AddTile(16);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
