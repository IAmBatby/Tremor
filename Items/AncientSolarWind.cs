using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class AncientSolarWind : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 120;
			item.width = 72;
			item.height = 72;
			item.noUseGraphic = true;
			item.melee = true;
			item.useTime = 30;
			item.shoot = mod.ProjectileType("AncientSolarWindPro");
			item.shootSpeed = 3f;
			item.useAnimation = 30;
			item.useStyle = 5;
			item.knockBack = 4;
			item.value = 210000;
			item.rare = 10;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ancient Solar Wind");
			Tooltip.SetDefault("");
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.NextBool(3))
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 64);
			}
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "AncientTablet", 10);
			recipe.AddIngredient(null, "FireFragment", 6);
			recipe.SetResult(this);
			recipe.AddTile(412);
			recipe.AddRecipe();
		}
	}
}
