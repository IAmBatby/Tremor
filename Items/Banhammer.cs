using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class Banhammer : ModItem
	{
		public override void SetDefaults()
		{

			item.autoReuse = true;
			item.useStyle = 1;
			item.useTurn = true;
			item.useAnimation = 37;
			item.useTime = 25;
			item.hammer = 100;
			item.width = 24;
			item.height = 28;
			item.damage = 485;
			item.rare = 0;
			item.knockBack = 5.5f;
			item.scale = 1.2f;
			item.UseSound = SoundID.Item1;
			item.tileBoost = +3;
			item.value = 520000;
			item.melee = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Banhammer");
			Tooltip.SetDefault("");
		}

		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			tooltips[0].overrideColor = new Color(238, 194, 73);
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.NextBool(2))
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 226);
			}
		}
	}
}
