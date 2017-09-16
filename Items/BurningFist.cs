using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class BurningFist : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 29;
			item.magic = true;
			item.width = 28;
			item.height = 30;
			item.useTime = 42;
			item.useAnimation = 42;
			item.shoot = mod.ProjectileType("BurningFist");
			item.shootSpeed = 15f;
			item.mana = 16;
			item.useStyle = 5;
			item.knockBack = 3;
			item.value = 30000;
			item.noUseGraphic = true;
			item.rare = 3;
			item.UseSound = SoundID.Item116;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Burning Fist");
			Tooltip.SetDefault("Shoots a burning fist that explodes on contact and erupts burning bolts");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HellstoneBar, 12);
			recipe.AddIngredient(ItemID.MeteoriteBar, 12);
			recipe.AddIngredient(null, "DemonBlood", 10);
			recipe.AddTile(null, "DevilForge");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
