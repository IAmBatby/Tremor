using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class GarnetGlove : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 26;
			item.thrown = true;
			item.width = 40;
			item.height = 20;
			item.noUseGraphic = true;
			item.useTime = 30;

			item.useAnimation = 20;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 6;
			item.value = 10000;
			item.rare = 3;
			item.UseSound = SoundID.Item45;
			item.autoReuse = false;
			item.shoot = mod.ProjectileType("GarnetGlovePro");
			item.shootSpeed = 9f;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Garnet Glove");
			Tooltip.SetDefault("'Made of love'");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MeteoriteBar, 15);
			recipe.AddIngredient(ItemID.Ruby, 13);
			recipe.AddIngredient(ItemID.Sapphire, 13);
			recipe.SetResult(this);
			recipe.AddTile(16);
			recipe.AddRecipe();
		}
	}
}
