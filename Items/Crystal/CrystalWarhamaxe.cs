using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items.Crystal
{
	public class CrystalWarhamaxe : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 20;
			item.melee = true;
			item.width = 44;
			item.height = 44;
			item.useTime = 20;
			item.useAnimation = 20;
			item.hammer = 100;
			item.axe = 22;
			item.tileBoost++;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 15000;
			item.rare = 5;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crystal Warhamaxe");
			Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "ChaosBar", 15);
			recipe.AddIngredient(ItemID.CrystalShard, 22);
			recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.AddRecipe();
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.NextBool(3))
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 71);
			}
		}
		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(31, 60);
		}
	}
}
