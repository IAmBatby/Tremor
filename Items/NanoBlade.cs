using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class NanoBlade : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 72;
			item.melee = true;
			item.width = 50;
			item.height = 55;
			item.useTime = 25;
			item.useAnimation = 25;
			item.useStyle = 1;
			item.shootSpeed = 10f;
			item.knockBack = 8;
			item.value = 10000;
			item.rare = 8;
			item.UseSound = SoundID.Item1;
			item.useTurn = false;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nano Blade");
			Tooltip.SetDefault("");
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(144, 1200);
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 59);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "NanoBar", 15);
			recipe.AddIngredient(ItemID.HallowedBar, 5);
			recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.AddRecipe();
		}
	}
}
