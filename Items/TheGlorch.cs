using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class TheGlorch : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 72;
			item.melee = true;
			item.width = 40;
			item.height = 52;
			item.useTime = 21;
			item.useAnimation = 21;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 660;
			item.rare = 5;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Glorch");
			Tooltip.SetDefault("");
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			if (Main.rand.NextBool(3))
			{
				target.AddBuff(70, 1200);
			}
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.NextBool(3))
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 74);
			}
		}
	}
}
