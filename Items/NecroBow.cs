using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class NecroBow : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 36;
			item.width = 16;
			item.height = 32;
			item.useTime = 38;
			item.ranged = true;
			item.shoot = 1;
			item.shootSpeed = 22f;
			item.useAnimation = 30;
			item.useStyle = 5;
			item.knockBack = 5;
			item.value = 12540;
			item.useAmmo = AmmoID.Arrow;
			item.rare = 3;
			item.UseSound = SoundID.Item5;
			item.autoReuse = false;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Necro Bow");
			Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Bone, 25);
			recipe.AddIngredient(ItemID.Cobweb, 30);
			recipe.SetResult(this);
			recipe.AddTile(16);
			recipe.AddRecipe();
		}
	}
}
