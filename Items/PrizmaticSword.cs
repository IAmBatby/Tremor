using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class PrizmaticSword : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 65;
			item.melee = true;
			item.width = 35;
			item.height = 20;

			item.useTime = 20;
			item.useAnimation = 30;
			item.useStyle = 1;
			item.knockBack = 10;
			item.value = 120000;
			item.rare = 5;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Prizmatic Fang");
			Tooltip.SetDefault("Grants mana upon hitting an enemy");
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			player.statMana += damage / 6;
			player.ManaEffect(damage / 6);
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.NextBool(2))
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 27);
			}
		}
	}
}

