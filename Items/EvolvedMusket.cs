using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{

	public class EvolvedMusket : ModItem
	{
		public override void SetDefaults()
		{
			item.useStyle = 5;
			item.autoReuse = true;
			item.useAnimation = 36;
			item.useTime = 36;

			item.width = 44;
			item.height = 14;
			item.shoot = 10;
			item.useAmmo = AmmoID.Bullet;
			item.UseSound = SoundID.Item11;
			item.damage = 333;
			item.shootSpeed = 9f;
			item.noMelee = true;
			item.value = 100000;
			item.knockBack = 5.25f;
			item.rare = 11;
			item.ranged = true;
			item.crit = 7;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Evolved Musket");
			Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Musket, 1);
			recipe.AddIngredient(null, "WhiteGoldBar", 12);
			recipe.SetResult(this);
			recipe.AddTile(null, "DivineForgeTile");
			recipe.AddRecipe();
		}
	}
}
