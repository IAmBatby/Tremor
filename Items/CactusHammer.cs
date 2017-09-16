using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class CactusHammer : ModItem
	{
		public override void SetDefaults()
		{

			item.autoReuse = true;
			item.useStyle = 1;
			item.useTurn = true;
			item.useAnimation = 30;
			item.useTime = 20;
			item.hammer = 38;
			item.width = 24;
			item.height = 28;
			item.damage = 9;
			item.knockBack = 5.5f;
			item.scale = 1.2f;
			item.UseSound = SoundID.Item1;
			item.value = 1600;
			item.melee = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cactus Hammer");
			Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Cactus, 16);
			recipe.AddTile(16);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
