using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class HallowedSpray : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 56;
			item.magic = true;
			item.width = 28;
			item.height = 30;
			item.useTime = 10;
			item.useAnimation = 30;
			item.shoot = mod.ProjectileType("HallowedSprayPro");
			item.shootSpeed = 7.5f;
			item.mana = 6;
			item.noMelee = true;
			item.useStyle = 5;
			item.knockBack = 3;
			item.value = 99999;
			item.rare = 5;
			item.UseSound = SoundID.Item21;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hallowed Spray");
			Tooltip.SetDefault("");
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SpellTome, 1);
			recipe.AddIngredient(ItemID.HallowedBar, 12);
			recipe.SetResult(this);
			recipe.AddTile(101);
			recipe.AddRecipe();
		}
	}
}
