using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class ShroomiteRocketLauncher : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 64;
			item.ranged = true;
			item.width = 66;
			item.height = 32;
			item.useTime = 18;
			item.useAnimation = 18;
			item.shoot = 134;
			item.shootSpeed = 10f;
			item.useAmmo = AmmoID.Rocket;
			item.useStyle = 5;
			item.knockBack = 4;
			item.value = 60000;
			item.rare = 8;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shroomite Rocket Launcher");
			Tooltip.SetDefault("");
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-18, -4);
		}

		public override bool ConsumeAmmo(Player p)
		{
			return Main.rand.NextBool(3);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.ShroomiteBar, 16);
			recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.AddRecipe();
		}
	}
}
