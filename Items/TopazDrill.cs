using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{

	public class TopazDrill : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 9;
			item.melee = true;
			item.width = 20;
			item.height = 12;
			item.useTime = 8;
			item.useAnimation = 25;
			item.channel = true;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.pick = 85;
			item.useStyle = 5;
			item.knockBack = 6;
			item.value = Item.buyPrice(0, 0, 50, 0);
			item.rare = 2;
			item.UseSound = SoundID.Item23;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("TopazDrillPro");
			item.shootSpeed = 40f;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Topaz Drill");
			Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Obsidian, 25);
			recipe.AddIngredient(ItemID.MeteoriteBar, 16);
			recipe.AddIngredient(ItemID.Topaz, 12);
			recipe.SetResult(this);
			recipe.AddTile(16);
			recipe.AddRecipe();
		}
	}
}
