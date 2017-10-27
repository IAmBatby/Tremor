using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class HunterRevolver : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 26;
			item.ranged = true;
			item.width = 40;
			item.height = 20;
			item.useTime = 32;
			item.useAnimation = 32;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 7;
			item.value = 10000;
			item.rare = 1;
			item.UseSound = SoundID.Item36;
			item.autoReuse = false;
			item.shoot = 10;
			item.shootSpeed = 5f;
			item.useAmmo = AmmoID.Bullet;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hunter Revolver");
			Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FlintlockPistol, 1);
			recipe.AddIngredient(ItemID.DynastyWood, 15);
			recipe.AddIngredient(ItemID.TungstenBar, 8);
			recipe.AddIngredient(ItemID.SilverBar, 8);
			recipe.SetResult(this);
			recipe.AddTile(16);
			recipe.AddRecipe();
		}
	}
}
