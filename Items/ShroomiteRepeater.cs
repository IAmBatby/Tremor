using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class ShroomiteRepeater : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 36;
			item.ranged = true;
			item.width = 62;
			item.height = 30;
			item.useTime = 10;
			item.useAnimation = 10;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 6;
			item.value = 50000;
			item.rare = 6;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.shoot = 8;
			item.shootSpeed = 30f;
			item.useAmmo = AmmoID.Arrow;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shroomite Repeater");
			Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.ShroomiteBar, 16);
			recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.AddRecipe();
		}
	}
}
