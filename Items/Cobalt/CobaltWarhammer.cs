using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items.Cobalt
{
	public class CobaltWarhammer : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 38;
			item.melee = true;
			item.width = 44;
			item.height = 40;
			item.useTime = 39;
			item.useAnimation = 39;
			item.hammer = 80;
			item.useStyle = 1;
			item.knockBack = 5;
			item.value = 13800;
			item.rare = 4;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cobalt Warhammer");
			Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.CobaltBar, 10);
			recipe.SetResult(this);
			recipe.AddTile(16);
			recipe.AddRecipe();
		}
	}
}
