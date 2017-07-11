using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class ShadowBow : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 18;
			item.width = 16;
			item.height = 32;
			item.useTime = 25;
			item.ranged = true;
			item.shoot = 1;
			item.shootSpeed = 10f;
			item.useAnimation = 25;
			item.useStyle = 5;
			item.knockBack = 5;
			item.value = 5040;
			item.useAmmo = AmmoID.Arrow;
			item.rare = 3;
			item.UseSound = SoundID.Item5;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shadow Bow");
			Tooltip.SetDefault("");
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "LongBow", 1);
			recipe.AddIngredient(null, "PhantomSoul", 5);
			recipe.AddTile(18);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
