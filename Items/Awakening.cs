using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class Awakening : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 300;
			item.melee = true;
			item.width = 70;
			item.height = 70;
			item.useTime = 23;
			item.useAnimation = 23;
			item.useStyle = 1;
			item.knockBack = 10;
			item.value = 1000000;
			item.rare = 11;

			item.UseSound = SoundID.Item71;
			item.autoReuse = true;
			item.useTurn = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Awakening");
			Tooltip.SetDefault("Hitting enemies temporarily increases maximum health");
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.NextBool(3))
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 13);
			}
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			player.AddBuff(113, 120);
		}
	}
}
