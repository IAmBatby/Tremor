using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items.Coral
{
	public class CoralSlasher : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 12;
			item.melee = true;
			item.width = 48;
			item.height = 48;
			item.useTime = 100;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 2;
			item.value = 100;
			item.rare = 1;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Coral Slasher");
			Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Coral, 15);
			recipe.SetResult(this);
			recipe.AddTile(18);
			recipe.AddRecipe();
		}
	}
}
