using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class Doomhammer : ModItem
	{
		public override void SetDefaults()
		{
			item.CloneDefaults(367);

		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Doomhammer");
			Tooltip.SetDefault("");
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(3) == 0)
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 27);
			}
		}
	}
}
