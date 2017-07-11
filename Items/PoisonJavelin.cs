using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class PoisonJavelin : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 23;
			item.thrown = true;
			item.width = 18;
			item.noUseGraphic = true;
			item.maxStack = 999;
			item.consumable = true;
			item.height = 38;
			item.useTime = 32;
			item.useAnimation = 32;
			item.shoot = mod.ProjectileType("PoisonJavelinPro");
			item.shootSpeed = 16f;
			item.useStyle = 1;
			item.knockBack = 4;
			item.value = 60;
			item.rare = 3;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Poison Javelin");
			Tooltip.SetDefault("");
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "JungleAlloy", 1);
			recipe.AddIngredient(ItemID.Stinger, 1);
			recipe.AddIngredient(ItemID.Vine, 1);
			recipe.SetResult(this, 50);
			recipe.AddTile(null, "GreatAnvilTile");
			recipe.AddRecipe();
		}
	}
}
