using Terraria.ID;

using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class FrostbittenBall : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 30;
			item.height = 10;
			item.value = Item.sellPrice(0, 1, 0, 0);
			item.rare = 1;
			item.noMelee = true;
			item.useStyle = 5;
			item.useAnimation = 40;
			item.useTime = 40;
			item.knockBack = 7.5F;
			item.damage = 18;
			item.scale = 1.1F;
			item.noUseGraphic = true;
			item.shoot = mod.ProjectileType("FrostbittenBallPro");
			item.shootSpeed = 15.9F;
			item.UseSound = SoundID.Item1;
			item.melee = true;
			item.channel = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Frostbitten Ball");
			Tooltip.SetDefault("");
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "FrostCore", 20);
			recipe.SetResult(this);
			recipe.AddTile(16);
			recipe.AddRecipe();
		}
	}
}
