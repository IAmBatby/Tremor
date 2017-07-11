using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{

	public class CrystalDrill : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 18;
			item.melee = true;
			item.width = 20;
			item.height = 12;
			item.useTime = 8;
			item.useAnimation = 25;
			item.channel = true;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.pick = 150;
			item.tileBoost++;
			item.useStyle = 5;
			item.knockBack = 6;
			item.value = Item.buyPrice(0, 1, 50, 0);
			item.rare = 5;
			item.UseSound = SoundID.Item23;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("CrystalDrill");
			item.shootSpeed = 40f;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crystal Drill");
			Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "ChaosBar", 15);
			recipe.AddIngredient(ItemID.CrystalShard, 22);
			recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.AddRecipe();
		}
	}
}
