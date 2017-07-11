using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{

	public class NanoDrill : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 18;
			item.melee = true;
			item.width = 20;
			item.height = 12;
			item.useTime = 8;
			item.useAnimation = 8;
			item.channel = true;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.pick = 200;
			item.tileBoost++;
			item.useStyle = 5;
			item.knockBack = 6;
			item.value = Item.buyPrice(0, 4, 50, 0);
			item.rare = 6;
			item.UseSound = SoundID.Item23;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("NanoDrillPro");
			item.shootSpeed = 26f;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nano Drill");
			Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "NanoBar", 16);
			recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.AddRecipe();
		}
	}
}
