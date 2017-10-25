using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items.Chain
{
	public class SnowballChaingun : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 30;
			item.ranged = true;
			item.width = 40;
			item.height = 20;
			item.useTime = 7;
			item.useAnimation = 7;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 2;
			item.value = 35000;
			item.rare = 3;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.shoot = 166;
			item.shootSpeed = 8f;
			item.useAmmo = AmmoID.Snowball;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Snowball Chaingun");
			Tooltip.SetDefault("");
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-18, -4);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Minishark, 1);
			recipe.AddIngredient(ItemID.SnowballCannon, 1);
			recipe.AddIngredient(ItemID.IceBlock, 25);
			recipe.AddIngredient(ItemID.SnowBlock, 75);
			recipe.AddIngredient(ItemID.SoulofLight, 5);
			recipe.AddIngredient(ItemID.SoulofNight, 5);
			recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.AddRecipe();
		}
	}
}
