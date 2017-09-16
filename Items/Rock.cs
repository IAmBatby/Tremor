using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class Rock : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 9;
			item.thrown = true;
			item.width = 18;
			item.height = 18;
			item.useTime = 14;
			item.useAnimation = 14;
			item.useStyle = 1;
			item.knockBack = 5;
			item.rare = 0;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
			item.shoot = mod.ProjectileType("Rock");
			item.shootSpeed = 10f;
			item.maxStack = 999;
			item.consumable = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Rock");
			Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.StoneBlock, 1);
			recipe.SetResult(this, 15);
			recipe.AddRecipe();
		}
	}
}
