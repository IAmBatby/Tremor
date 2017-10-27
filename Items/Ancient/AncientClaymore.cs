using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items.Ancient
{
	public class AncientClaymore : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 110;
			item.melee = true;
			item.width = 88;
			item.height = 88;
			item.useTime = 45;
			item.useAnimation = 45;
			item.useStyle = 1;
			item.shoot = mod.ProjectileType("AncientClaymorePro");
			item.shootSpeed = 10f;
			item.knockBack = 4;
			item.value = 250000;
			item.rare = 10;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = false;

		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ancient Claymore");
			Tooltip.SetDefault("Shoots out a ghostly sword that inflicts Ichor on enemies");
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
			recipe.AddIngredient(null, "AncientTablet", 14);
			recipe.AddIngredient(ItemID.BrokenHeroSword);
			recipe.SetResult(this);
			recipe.AddTile(412);
			recipe.AddRecipe();
		}
	}
}
