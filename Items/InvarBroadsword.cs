using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class InvarBroadsword : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 11;
			item.melee = true;
			item.width = 36;
			item.height = 36;
			item.useTime = 21;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 3;
			item.value = 100;
			item.rare = 1;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Invar Broadsword");
			Tooltip.SetDefault("");
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "InvarBar", 9);
			recipe.SetResult(this);
			recipe.AddTile(16);
			recipe.AddRecipe();
		}
	}
}
