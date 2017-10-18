using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class HonestBlade : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 140;
			item.melee = true;
			item.width = 32;
			item.height = 32;
			item.useTime = 11;
			item.useAnimation = 9;
			item.useStyle = 3;
			item.knockBack = 2;
			item.value = 400000;
			item.rare = 0;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Honest Blade");
			Tooltip.SetDefault("");
		}

		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			tooltips[0].overrideColor = new Color(238, 194, 73);
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(24, 60);
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.NextBool(3))
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 6);
			}
		}
	}
}
